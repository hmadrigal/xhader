using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderEffectLibrary
{
    /// <summary>
    /// Display several images next to each other - relatively harder, but might end up being faster than the pixel shader.
    /// </summary>
    public class TileEffect : ShaderEffect
    {
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TileEffect), 0);
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public Brush Input
        {
            get
            {
                return ((Brush)(this.GetValue(InputProperty)));
            }
            set
            {
                this.SetValue(InputProperty, value);
            }
        }
        
        /// <summary>
        /// Amount of tiling in the X and Y direction
        /// </summary>
        public static readonly DependencyProperty TileCountProperty = DependencyProperty.Register("TileCount", typeof(Point), typeof(TileEffect), new PropertyMetadata(new Point(0, 0), PixelShaderConstantCallback(0)));
        /// <summary>
        /// Amount of tiling in the X and Y direction
        /// </summary>
        public Point TileCount
        {
            get
            {
                return ((Point)(this.GetValue(TileCountProperty)));
            }
            set
            {
                this.SetValue(TileCountProperty, value);
            }
        }

        public TileEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/TileEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(TileCountProperty);
        }
        
        
    }
}
