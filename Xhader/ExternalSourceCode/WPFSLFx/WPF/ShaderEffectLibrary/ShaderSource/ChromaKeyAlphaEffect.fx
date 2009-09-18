
// Object Declarations
float4 InputColor : register(C0);

float Tolerance : register(C1);

SamplerState  ImageSampler : register(S0);

//--------------------------------------------------------------------------------------
struct VS_INPUT
{
    float4 Position : POSITION;
    float4 Diffuse  : COLOR0;
    float2 UV0      : TEXCOORD0;
    float2 UV1      : TEXCOORD1;
};

struct VS_OUTPUT
{
    float4 Position  : POSITION;
    float4 Color     : COLOR0;
    float2 UV        : TEXCOORD0;
};


float4 main( VS_OUTPUT input ) : SV_Target
{
	float4 color = tex2D( ImageSampler, input.UV );
   
	if (abs(InputColor.r - color.r) <= Tolerance && abs(InputColor.g - color.g) <= Tolerance && abs(InputColor.b - color.b) <= Tolerance)
	{
      color.rgba = 0;
	}
   
   return color;
 
}
