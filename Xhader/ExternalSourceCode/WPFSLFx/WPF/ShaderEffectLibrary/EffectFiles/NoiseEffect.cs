using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace ShaderEffectLibrary
{
    /// <summary>
    /// Perlin noise is a procedural texture primitive, 
    /// used by visual effects artists to increase the appearance of realism in computer graphics. 
    /// This is a type of gradient noise. The function has a pseudo-random appearance, 
    /// yet all of its visual details are the same size
    /// </summary>
    public class NoiseEffect : ShaderEffect
    {
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(NoiseEffect), 0);
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        [System.ComponentModel.BrowsableAttribute(false)]
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

        /// <summary>s
        /// Noise contribution from simplex origin (2D noise)
        /// </summary>
        public static DependencyProperty PermSampler2dProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("PermSampler2d", typeof(NoiseEffect), 1);
        /// <summary>s
        /// Noise contribution from simplex origin (3D Noise)
        /// </summary>
        public virtual System.Windows.Media.Brush PermSampler2d
        {
            get
            {
                return ((System.Windows.Media.Brush)(GetValue(PermSampler2dProperty)));
            }
            set
            {
                SetValue(PermSampler2dProperty, value);
            }
        }

        /// <summary>s
        /// Noise contribution from simplex origin
        /// </summary>
        public static DependencyProperty PermGradSamplerProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("PermGradSampler", typeof(NoiseEffect), 2);
        /// <summary>s
        /// Noise contribution from simplex origin
        /// </summary>
        public virtual System.Windows.Media.Brush PermGradSampler
        {
            get
            {
                return ((System.Windows.Media.Brush)(GetValue(PermGradSamplerProperty)));
            }
            set
            {
                SetValue(PermGradSamplerProperty, value);
            }
        }

        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>0.5</maxValue>
        /// <defaultValue>0</defaultValue>
        public static readonly DependencyProperty XTimeProperty = DependencyProperty.Register("XTime", typeof(double), typeof(NoiseEffect), new PropertyMetadata(((double)(0)), PixelShaderConstantCallback(0)));
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>0.5</maxValue>
        /// <defaultValue>0</defaultValue>
        public double XTime
        {
            get
            {
                return ((double)(this.GetValue(XTimeProperty)));
            }
            set
            {
                this.SetValue(XTimeProperty, value);
            }
        }
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>4</maxValue>
        /// <defaultValue>1</defaultValue>
        public static readonly DependencyProperty FreqProperty = DependencyProperty.Register("Freq", typeof(double), typeof(NoiseEffect), new PropertyMetadata(((double)(1)), PixelShaderConstantCallback(1)));
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>4</maxValue>
        /// <defaultValue>1</defaultValue>
        public double Freq
        {
            get
            {
                return ((double)(this.GetValue(FreqProperty)));
            }
            set
            {
                this.SetValue(FreqProperty, value);
            }
        }
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>4</maxValue>
        /// <defaultValue>1</defaultValue>
        public static readonly DependencyProperty AmpProperty = DependencyProperty.Register("Amp", typeof(double), typeof(NoiseEffect), new PropertyMetadata(((double)(1)), PixelShaderConstantCallback(2)));
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>0/minValue>
        /// <maxValue>4</maxValue>
        /// <defaultValue>1</defaultValue>
        public double Amp
        {
            get
            {
                return ((double)(this.GetValue(AmpProperty)));
            }
            set
            {
                this.SetValue(AmpProperty, value);
            }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public NoiseEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/NoiseEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(PermSampler2dProperty);
            this.UpdateShaderValue(PermGradSamplerProperty);
            this.UpdateShaderValue(XTimeProperty);
            this.UpdateShaderValue(FreqProperty);
            this.UpdateShaderValue(AmpProperty);

            ImageBrush brush;
            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(Global.MakePackUri("Textures/SimplexTexture.png"));
            this.PermGradSampler = brush;

            brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(Global.MakePackUri("Textures/SimplexPermTexture.png"));
            this.PermSampler2d = brush;
        }

        

        

        

    }
}
