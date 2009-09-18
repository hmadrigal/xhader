//--------------------------------------------------------------------------------------
// 
// ShaderEffect HLSL -- HatchingEffect by Charles Bissonnette (chabiss@digitalepiphania.com)
//
//--------------------------------------------------------------------------------------

//-----------------------------------------------------------------------------------------
// Shader constant register mappings (scalars - float, double, Point, Color, Point3D, etc.)
//-----------------------------------------------------------------------------------------

float transparencyToneThreshold : register(C0);
float lightToneThreshold : register(C1);
float middleToneThreshold : register(C2);
float darkToneThreshold : register(C3);


//--------------------------------------------------------------------------------------
// Sampler Inputs (Brushes, including ImplicitInput)
//--------------------------------------------------------------------------------------

sampler2D implicitInputSampler : register(S0);
sampler2D lightTextureSampler : register(S1);
sampler2D middleTextureSampler : register(S2);
sampler2D darkTextureSampler : register(S3);


//--------------------------------------------------------------------------------------
// Hatching Pixel Shader
//--------------------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
   // This particular shader starts by computing the luminance
   // for a particular pixel. 
   float4 color = tex2D(implicitInputSampler, uv);
   float lum = 0.3*color.x + 0.59*color.y + 0.11*color.z;
   
   //We then scale the luminance to a factor of 4
   lum = lum*4;
   float4 intensity = 0;
   float4 transparentcolor = 0;
   
   //Depending on the luminance, we determine the 4 different intensities
   //for the three textures and the transparency color when luminance is at the top
   if(lum > transparencyToneThreshold)
   {
	 intensity.x = 1;
   }
   else if(lum > lightToneThreshold)
   {
	 intensity.x = 1 - ((transparencyToneThreshold - lum)/(transparencyToneThreshold-lightToneThreshold));
	 intensity.y = 1 - intensity.x;
   }
   else if(lum > middleToneThreshold && lum <= lightToneThreshold)
   {
    intensity.y = 1 - ((lightToneThreshold - lum)/(lightToneThreshold-middleToneThreshold));
    intensity.z = 1 - intensity.y;
   }
   else if (lum > darkToneThreshold && lum <= middleToneThreshold)
   {
	intensity.z = 1 - ((middleToneThreshold - lum)/(middleToneThreshold-darkToneThreshold));
	intensity.w = 1 - intensity.z;
   }
   else
   {
	intensity.w = 1; 
   }
   
   //We then combine the 3 textures + transparency with their
   //respective intensities. 
   float4 outputcolor = (transparentcolor *intensity.x) +
						(tex2D(lightTextureSampler, uv) * intensity.y) +
						(tex2D(middleTextureSampler, uv) * intensity.z) +
						(tex2D(darkTextureSampler, uv) * intensity.w);
						
   outputcolor *=  color.w;				
   
   return outputcolor;
}


