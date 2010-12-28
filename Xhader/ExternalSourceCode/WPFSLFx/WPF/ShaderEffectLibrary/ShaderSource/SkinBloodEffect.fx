sampler2D input : register(s0);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>05/minValue>
/// <maxValue>10</maxValue>
/// <defaultValue>3.5</defaultValue>
sampler2D stroke1 : register(s1);

/// <summary>Explain the purpose of this variable.</summary>
/// <minValue>1,1/minValue>
/// <maxValue>100,100</maxValue>
/// <defaultValue>7,7</defaultValue>
float2 Tile : register(C1);

float4 main(float2 uv : TEXCOORD) : COLOR 
{ 
	float4 I = tex2D(input, uv); 
	float2 newUv = uv * Tile % 1;
	float4 M = tex2D(stroke1, newUv);  // texture
	float4 resultColor;

	resultColor.rgb = 1-(  ((1-I.rgb)) /(1.0/256+M.rgb) );
	resultColor.a = 1;

	return resultColor;
}

