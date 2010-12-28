sampler2D input : register(s0);
sampler2D permSampler2d : register(s1);
sampler1D permGradSampler : register(s2);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>0.5</maxValue>
/// <defaultValue>0</defaultValue>
float xTime : register(C0);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>4</maxValue>
/// <defaultValue>1</defaultValue>
float freq : register(C1);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>0/minValue>
/// <maxValue>4</maxValue>
/// <defaultValue>1</defaultValue>
float amp : register(C2);

/*
 * To create offsets of one texel and one half texel in the
 * texture lookup, we need to know the texture image size.
 */
#define ONE 0.00390625
#define ONEHALF 0.001953125
// The numbers above are 1/256 and 0.5/256, change accordingly
// if you change the code to use another texture size.


float snoise(float2 P) 
{

// Skew and unskew factors are a bit hairy for 2D, so define them as constants
// This is (sqrt(3.0)-1.0)/2.0
#define F2 0.366025403784
// This is (3.0-sqrt(3.0))/6.0
#define G2 0.211324865405

  // Skew the (x,y) space to determine which cell of 2 simplices we're in
  float s = (P.x + P.y) * F2;   // Hairy factor for 2D skewing
  float2 Pi = floor(P + s);
  float t = (Pi.x + Pi.y) * G2; // Hairy factor for unskewing
  float2 P0 = Pi - t; // Unskew the cell origin back to (x,y) space
  Pi = Pi * ONE + ONEHALF; // Integer part, scaled and offset for texture lookup

  float2 Pf0 = P - P0;  // The x,y distances from the cell origin

  // For the 2D case, the simplex shape is an equilateral triangle.
  // Find out whether we are above or below the x=y diagonal to
  // determine which of the two triangles we're in.
  float2 o1;
  if(Pf0.x > Pf0.y) o1 = float2(1.0, 0.0);  // +x, +y traversal order
  else o1 = float2(0.0, 1.0);               // +y, +x traversal order

  // Noise contribution from simplex origin
  float2 grad0 = tex2D(permSampler2d, Pi).rg * 4.0 - 1.0;
  float t0 = 0.5 - dot(Pf0, Pf0);
  float n0;
  if (t0 < 0.0) n0 = 0.0;
  else {
    t0 *= t0;
    n0 = t0 * t0 * dot(grad0, Pf0);
  }

  // Noise contribution from middle corner
  float2 Pf1 = Pf0 - o1 + G2;
  float2 grad1 = tex2D(permSampler2d, Pi + o1*ONE).rg * 4.0 - 1.0;
  float t1 = 0.5 - dot(Pf1, Pf1);
  float n1;
  if (t1 < 0.0) n1 = 0.0;
  else {
    t1 *= t1;
    n1 = t1 * t1 * dot(grad1, Pf1);
  }
  
  // Noise contribution from last corner
  float2 Pf2 = Pf0 - float2(1.0-2.0*G2,1.0-2.0*G2);
  float2 grad2 = tex2D(permSampler2d, Pi + float2(ONE, ONE)).rg * 4.0 - 1.0;
  float t2 = 0.5 - dot(Pf2, Pf2);
  float n2;
  if(t2 < 0.0) n2 = 0.0;
  else {
    t2 *= t2;
    n2 = t2 * t2 * dot(grad2, Pf2);
  }

  // Sum up and scale the result to cover the range [-1,1]
  return 70.0 * (n0 + n1 + n2);
}

float snoise(float3 P) 
{

// The skewing and unskewing factors are much simpler for the 3D case
#define F3 0.333333333333
#define G3 0.166666666667

  // Skew the (x,y,z) space to determine which cell of 6 simplices we're in
 	float s = (P.x + P.y + P.z) * F3; // Factor for 3D skewing
  float3 Pi = floor(P + s);
  float t = (Pi.x + Pi.y + Pi.z) * G3;
  float3 P0 = Pi - t; // Unskew the cell origin back to (x,y,z) space
  Pi = Pi * ONE + ONEHALF; // Integer part, scaled and offset for texture lookup

  float3 Pf0 = P - P0;  // The x,y distances from the cell origin

  // For the 3D case, the simplex shape is a slightly irregular tetrahedron.
  // To find out which of the six possible tetrahedra we're in, we need to
  // determine the magnitude ordering of x, y and z components of Pf0.
  // The method below is explained briefly in the C code. It uses a small
  // 1D texture as a lookup table. The table is designed to work for both
  // 3D and 4D noise, so only 8 (only 6, actually) of the 64 indices are
  // used here.
  float c1 = (Pf0.x > Pf0.y) ? 0.5078125 : 0.0078125; // 1/2 + 1/128
  float c2 = (Pf0.x > Pf0.z) ? 0.25 : 0.0;
  float c3 = (Pf0.y > Pf0.z) ? 0.125 : 0.0;
  float sindex = c1 + c2 + c3;
  float3 offsets = tex1D(permGradSampler, sindex).rgb;
  float3 o1 = step(0.375, offsets);
  float3 o2 = step(0.125, offsets);

  // Noise contribution from simplex origin
  float perm0 = tex2D(permSampler2d, Pi.xy).a;
  float3  grad0 = tex2D(permSampler2d, float2(perm0, Pi.z)).rgb * 4.0 - 1.0;
  float t0 = 0.6 - dot(Pf0, Pf0);
  float n0;
  if (t0 < 0.0) n0 = 0.0;
  else {
    t0 *= t0;
    n0 = t0 * t0 * dot(grad0, Pf0);
  }

  // Noise contribution from second corner
  float3 Pf1 = Pf0 - o1 + G3;
  float perm1 = tex2D(permSampler2d, Pi.xy + o1.xy*ONE).a;
  float3  grad1 = tex2D(permSampler2d, float2(perm1, Pi.z + o1.z*ONE)).rgb * 4.0 - 1.0;
  float t1 = 0.6 - dot(Pf1, Pf1);
  float n1;
  if (t1 < 0.0) n1 = 0.0;
  else {
    t1 *= t1;
    n1 = t1 * t1 * dot(grad1, Pf1);
  }
  
  // Noise contribution from third corner
  float3 Pf2 = Pf0 - o2 + 2.0 * G3;
  float perm2 = tex2D(permSampler2d, Pi.xy + o2.xy*ONE).a;
  float3  grad2 = tex2D(permSampler2d, float2(perm2, Pi.z + o2.z*ONE)).rgb * 4.0 - 1.0;
  float t2 = 0.6 - dot(Pf2, Pf2);
  float n2;
  if (t2 < 0.0) n2 = 0.0;
  else {
    t2 *= t2;
    n2 = t2 * t2 * dot(grad2, Pf2);
  }
  
  // Noise contribution from last corner
  float3 Pf3 = Pf0 - float3(1.0-3.0*G3,1.0-3.0*G3,1.0-3.0*G3);
  float perm3 = tex2D(permSampler2d, Pi.xy + float2(ONE, ONE)).a;
  float3  grad3 = tex2D(permSampler2d, float2(perm3, Pi.z + ONE)).rgb * 4.0 - 1.0;
  float t3 = 0.6 - dot(Pf3, Pf3);
  float n3;
  if(t3 < 0.0) n3 = 0.0;
  else {
    t3 *= t3;
    n3 = t3 * t3 * dot(grad3, Pf3);
  }

  // Sum up and scale the result to cover the range [-1,1]
  return 32.0 * (n0 + n1 + n2 + n3);
}

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	//return tex2D(permSampler2d, uv);
	//return tex1D(permGradSampler, uv);

	float4 original = tex2D(input, uv);
    uv.x += xTime;
    uv.y += xTime;
    uv*=freq;
    //float randomVal = snoise(float3(uv.x, uv.y, xTime))/amp;
    float randomVal = (snoise(uv))/amp;
    //original -= 0.5; // in the -0.5..0.5 range
    randomVal *= 0.5; // in the -0.5..0.5 range
    original = original + float4(randomVal, randomVal, randomVal, 0);// + 0.5;
    return original;
}
