using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderEffectLibrary.EffectFiles
{
    public class TextEffect : ShaderEffect
    {
        #region Constructors

        static TextEffect()
        {
            _pixelShader.UriSource = Global.MakePackUri("ShaderSource/TextEffect.ps");
        }

        public TextEffect()
        {
            this.PixelShader = _pixelShader;

            // Update each DependencyProperty that's registered with a shader register.  This
            // is needed to ensure the shader gets sent the proper default value.
            UpdateShaderValue(InputProperty);
            //UpdateShaderValue(ColorFilterProperty);
        }

        #endregion

        #region Dependency Properties
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        [System.ComponentModel.BrowsableAttribute(false)]
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(TextEffect), 0);
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }



        ///// <summary>
        ///// Scalar-valued properties turn into shader constants with the register
        ///// number sent into PixelShaderConstantCallback().
        ///// </summary>
        //public static readonly DependencyProperty ColorFilterProperty =
        //    DependencyProperty.Register("ColorFilter", typeof(Color), typeof(ASCIIEffect),
        //            new UIPropertyMetadata(Colors.Yellow, PixelShaderConstantCallback(0)));
        ///// <summary>
        ///// Scalar-valued properties turn into shader constants with the register
        ///// number sent into PixelShaderConstantCallback().
        ///// </summary>
        //public Color ColorFilter
        //{
        //    get { return (Color)GetValue(ColorFilterProperty); }
        //    set { SetValue(ColorFilterProperty, value); }
        //}

        #endregion

        #region Member Data

        private static PixelShader _pixelShader = new PixelShader();

        #endregion

    }
}
