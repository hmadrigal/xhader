﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace ShaderEffectLibrary
{
    /// <summary>
    /// This particular shader just multiplies the color at 
    /// a point by the colorFilter shader constant.
    /// </summary>
    public class ShiftHueEffect : ShaderEffect
    {
        /// <summary>
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ShiftHueEffect), 0);
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

        /// <summary>
        /// Hue shift
        /// </summary>
        public static readonly DependencyProperty HueShiftProperty = DependencyProperty.Register("HueShift", typeof(double), typeof(ShiftHueEffect), new PropertyMetadata(((double)(0)), PixelShaderConstantCallback(0)));
        /// <summary>
        /// Hue shift
        /// </summary>
        public double HueShift
        {
            get
            {
                return ((double)(this.GetValue(HueShiftProperty)));
            }
            set
            {
                this.SetValue(HueShiftProperty, value);
            }
        }


        /// <summary>
        /// Default Constructor
        /// </summary>
        public ShiftHueEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/ShiftHueEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(HueShiftProperty);
        }

    }
}
