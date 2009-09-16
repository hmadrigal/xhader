//--------------------------------------------------------------------------------------
// 
// WPF ShaderEffect HLSL -- ColorToneEffect
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float Desaturation : register(C0);
float Toned : register(C1);
float4 LightColor : register(C2);
float4 DarkColor : register(C3);

//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);


//--------------------------------------------------------------------------------------
// Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 scnColor = tex2D(implicitInputSampler, uv);
    
    // Creates a RGBA instead of an AR,AG,AB,A
    float alpha = scnColor.a;
    scnColor.r = scnColor.r / alpha;
    scnColor.g = scnColor.g / alpha;
    scnColor.b = scnColor.b / alpha;
    
    scnColor = scnColor * LightColor ;
    float gray = dot(float3(0.3, 0.59, 0.11), scnColor.rgb);
    
    float3 muted = lerp(scnColor.rgb, gray.xxx, Desaturation);
    float3 middle = lerp(DarkColor, LightColor, gray);
    
    scnColor.rgb = lerp(muted, middle, Toned);
    
    // restores the AR,AG,AB,A instead of an RGBA 
    scnColor.r = scnColor.r * alpha;
    scnColor.g = scnColor.g * alpha;
    scnColor.b = scnColor.b * alpha;
    
    return scnColor;
}


