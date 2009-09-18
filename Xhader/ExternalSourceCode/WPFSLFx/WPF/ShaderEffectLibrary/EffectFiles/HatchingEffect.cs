/********************************************************************
	created:	2009/07/02
	created:	2:7:2009   10:00
	filename: 	HatchingEffect\HatchingEffect.cs
	file path:	HatchingEffect
	file base:	HatchingEffect
	author:		Charles Bissonnette (chabiss@digitalepiphania.com)
	
	purpose:
 
	The hatching effect is a multi texture sampler shader that combines
	three textures based on the luminance of the input pixel sampler. Each texture
	match a luminance intensity and then blended together. 
	
	The shader has three textures:LightToneTexture, MiddleToneTexture and
	DarkToneTexture and for Threshold setting that control the dominance
	of each texture. The default textures used for the three input can
	be overridden in XAML by specifying a different image brush to the inputs. 
	
	Note that this cs file is shared across HatchingEffectWPF.csprog and 
 *	HatchingEffectSL.csprog.  
*********************************************************************/
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ShaderEffectLibrary
{
#if SILVERLIGHT
    using UIPropertyMetadata = System.Windows.PropertyMetadata;    
#endif
    /// <summary>
    /// Hatching Effect is a simple multi-texture sampler that takes the luminance level 
    /// of the implicit input and uses thresholds to determine which tone texture to use.
    /// </summary>
    public class HatchingEffect : ShaderEffect
    {
        #region Constructors

        static HatchingEffect()
        {
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/HatchingEffect.ps");
        }

        public HatchingEffect()
        {
            this.PixelShader = pixelShader;

            this.LightToneTexture = this.LoadImageBrush("Textures/LightToneTexture.png");
            this.MiddleToneTexture = this.LoadImageBrush("Textures/MiddleToneTexture.png");
            this.DarkToneTexture = this.LoadImageBrush("Textures/DarkToneTexture.png");

            // Update each DependencyProperty that's registered with a shader register.  This
            // is needed to ensure the shader gets sent the proper default value.
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(LightToneTextureProperty);
            UpdateShaderValue(MiddleToneTextureProperty);
            UpdateShaderValue(DarkToneTextureProperty);

            UpdateShaderValue(TransparentToneThresholdProperty);
            UpdateShaderValue(LightToneThresholdProperty);
            UpdateShaderValue(MiddleToneThresholdProperty);
            UpdateShaderValue(DarkToneThresholdProperty);
        }

        #endregion

        #region Dependency Properties

        [System.ComponentModel.BrowsableAttribute(false)]
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(HatchingEffect), 0);

        [System.ComponentModel.BrowsableAttribute(false)]
        public Brush LightToneTexture
        {
            get { return (Brush)GetValue(LightToneTextureProperty); }
            set { SetValue(LightToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty LightToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("LightToneTexture", typeof(HatchingEffect), 1);

        [System.ComponentModel.BrowsableAttribute(false)]
        public Brush MiddleToneTexture
        {
            get { return (Brush)GetValue(MiddleToneTextureProperty); }
            set { SetValue(MiddleToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty MiddleToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("MiddleToneTexture", typeof(HatchingEffect), 2);

        [System.ComponentModel.BrowsableAttribute(false)]
        public Brush DarkToneTexture
        {
            get { return (Brush)GetValue(DarkToneTextureProperty); }
            set { SetValue(DarkToneTextureProperty, value); }
        }

        // Brush-valued properties turn into sampler-property in the shader.
        // This helper sets "ImplicitInput" as the default, meaning the default
        // sampler is whatever the rendering of the element it's being applied to is.
        public static readonly DependencyProperty DarkToneTextureProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("DarkToneTexture", typeof(HatchingEffect), 3);

        //////////////////////////////////////////////////////////////////////////
        // Thresholds 
        //////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Define the threshold (1-4) for transparency to predominate
        /// </summary>
        public double TransparentToneThreshold
        {
            get { return (double)GetValue(TransparentToneThresholdProperty); }
            set { SetValue(TransparentToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty TransparentToneThresholdProperty =
            DependencyProperty.Register("TransparentToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(4.0, PixelShaderConstantCallback(0)));

        /// <summary>
        /// Define the threshold (1-4) for light tone texture to predominate
        /// </summary>
        public double LightToneThreshold
        {
            get { return (double)GetValue(LightToneThresholdProperty); }
            set { SetValue(LightToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty LightToneThresholdProperty =
            DependencyProperty.Register("LightToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(3.0, PixelShaderConstantCallback(1)));

        /// <summary>
        /// Define the threshold (1-4) for middle tone texture to predominate
        /// </summary>
        public double MiddleToneThreshold
        {
            get { return (double)GetValue(MiddleToneThresholdProperty); }
            set { SetValue(MiddleToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty MiddleToneThresholdProperty =
            DependencyProperty.Register("MiddleToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(2.0, PixelShaderConstantCallback(2)));

        /// <summary>
        /// Define the threshold (1-4) for dark tone texture to predominate
        /// </summary>
        public double DarkToneThreshold
        {
            get { return (double)GetValue(DarkToneThresholdProperty); }
            set { SetValue(DarkToneThresholdProperty, value); }
        }

        // Scalar-valued properties turn into shader constants with the register
        // number sent into PixelShaderConstantCallback().
        public static readonly DependencyProperty DarkToneThresholdProperty =
            DependencyProperty.Register("DarkToneThreshold", typeof(double), typeof(HatchingEffect),
                    new PropertyMetadata(1.0, PixelShaderConstantCallback(3)));

        #endregion

        #region Member Data

        private static PixelShader pixelShader = new PixelShader();

        ImageBrush LoadImageBrush(string imageSource)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(Global.MakePackUri(imageSource));
            return brush;
        }

        #endregion

    }
}
