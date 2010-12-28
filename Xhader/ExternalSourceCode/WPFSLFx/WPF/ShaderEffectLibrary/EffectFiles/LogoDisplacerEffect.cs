using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderEffectLibrary
{
#if SILVERLIGHT 
    using UIPropertyMetadata = System.Windows.PropertyMetadata ;      
#endif
    /// <summary>
    /// LogoDisplacer Effect known as "displacement mapping", and makes 
    /// for a subtle yet distinctive effect as opposed to simply alpha 
    /// blending the icon on top.
    /// </summary>
    public class LogoDisplacerEffect : ShaderEffect
    {
        #region Constructors

        /// <summary>
        /// Statict Constructor
        /// </summary>
        static LogoDisplacerEffect()
        {
            _pixelShader.UriSource = Global.MakePackUri("ShaderSource/LogoDisplacerEffect.ps");
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LogoDisplacerEffect()
        {
            this.PixelShader = _pixelShader;
            this.DdxUvDdyUvRegisterIndex = 6;

            // Update each DependencyProperty that's registered with a shader register.  This
            // is needed to ensure the shader gets sent the proper default value.
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(LogoProperty);
            UpdateShaderValue(DisplacementProperty);
            UpdateShaderValue(AdditionalLogoOpacityProperty);
        }

        #endregion

        #region Dependency Properties

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

        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(LogoDisplacerEffect), 0);

        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public Brush Logo
        {
            get { return (Brush)GetValue(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }

        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty LogoProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Logo", typeof(LogoDisplacerEffect), 1, SamplingMode.Bilinear);

        /// <summary>
        /// Scalar-valued properties turn into shader constants with the register
        /// number sent into PixelShaderConstantCallback().
        /// </summary>
        public double Displacement
        {
            get { return (double)GetValue(DisplacementProperty); }
            set { SetValue(DisplacementProperty, value); }
        }

        /// <summary>
        /// Scalar-valued properties turn into shader constants with the register
        /// number sent into PixelShaderConstantCallback().
        /// </summary>
        public static readonly DependencyProperty DisplacementProperty =
            DependencyProperty.Register("Displacement", typeof(double), typeof(LogoDisplacerEffect),
                    new UIPropertyMetadata(5.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Scalar-valued properties turn into shader constants with the register
        /// number sent into PixelShaderConstantCallback().
        /// </summary>
        public double AdditionalLogoOpacity
        {
            get { return (double)GetValue(AdditionalLogoOpacityProperty); }
            set { SetValue(AdditionalLogoOpacityProperty, value); }
        }

        /// <summary>
        /// Scalar-valued properties turn into shader constants with the register
        /// number sent into PixelShaderConstantCallback().
        /// </summary>
        public static readonly DependencyProperty AdditionalLogoOpacityProperty =
            DependencyProperty.Register("AdditionalLogoOpacity", typeof(double), typeof(LogoDisplacerEffect),
                    new UIPropertyMetadata(5.0, PixelShaderConstantCallback(1)));

        #endregion

        #region Member Data
        /// <summary>
        /// 
        /// </summary>
        private static PixelShader _pixelShader = new PixelShader();

        #endregion

    }
}
