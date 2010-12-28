
// Amount of tiling in the X and Y direction
float2 TileCount : register(C0);
sampler2D implicitInput : register(s0);

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	return tex2D(implicitInput, frac(uv.xy * TileCount.xy));
}
