using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design;
using System.Reflection;
using Microsoft.Windows.Design.PropertyEditing;
using System.ComponentModel;
using Ext = System.Windows.Controls.Design.Common.Extensions;
#if SILVERLIGHT
[assembly: ProvideMetadata(typeof(SLShaderEffectLibrary.Design.MetadataRegistration))]
namespace SLShaderEffectLibrary.Design
#else
[assembly: ProvideMetadata(typeof(WPFShaderEffectLibrary.Design.MetadataRegistration))]
namespace WPFShaderEffectLibrary.Design
#endif
{
    public partial class MetadataRegistration : MetadataRegistrationBase, IProvideAttributeTable
    {
        /// <summary>
        /// Design time metadata registration class.
        /// </summary>
        public MetadataRegistration()
            : base()
        {

            // Generates documentation based on the assembly file name
            AssemblyName asmName = typeof(ShaderEffectLibrary.BandedSwirlEffect).Assembly.GetName();
            XmlResourceName = asmName.Name + ".Design." + asmName.Name + ".XML"; // "Microsoft.Windows.Controls.Design.Microsoft.Windows.Controls.XML"
            //XmlResourceName = asmName.Name + ".XML"; 
            AssemblyFullName = ", " + asmName.FullName;
        }

        /// <summary>
        /// Gets the AttributeTable for design time metadata.
        /// </summary>
        public AttributeTable AttributeTable
        {
            get
            {
                return BuildAttributeTable();
            }
        }


        /// <summary>
        /// Provide a place to add custom attributes without creating a AttributeTableBuilder subclass.
        /// </summary>
        /// <param name="builder">The assembly attribute table builder.</param>
        protected override void AddAttributes(AttributeTableBuilder builder)
        {
            //builder.AddCustomAttributes(
            //    typeof(BandedSwirlEffect)
            //    , Ext.GetMemberName<BrightExtractEffect>(o => o.Threshold)
            //    , new NumberRangesAttribute(null, 0, 1, null, null)
            //    , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            //    , new NumberFormatAttribute("0'%'", null, 100)
            //    );

            #region BandedSwirlEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.BandedSwirlEffect)
                , b => b.AddCustomAttributes
                (
                      new ToolboxBrowsableAttribute(true)
                    , new DefaultPropertyAttribute(Ext.GetMemberName<ShaderEffectLibrary.BandedSwirlEffect>(o => o.SwirlStrength))
                )
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BandedSwirlEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BandedSwirlEffect>(o => o.SwirlStrength)
                , new DisplayNameAttribute(@"Swirl Strength")
                , new NumberRangesAttribute(null, -10, 10, null, null)
                , new NumberIncrementsAttribute(.01, .1, 1)
                
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BandedSwirlEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BandedSwirlEffect>(o => o.DistanceThreshold)
                , new DisplayNameAttribute(@"Distance Threshold")
                , new NumberRangesAttribute(null, 0, 1, null, null)
                , new NumberIncrementsAttribute(.01, .1, 1)
            );

            #endregion

            #region BloomEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.BloomEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BloomEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BloomEffect>(o => o.BloomIntensity)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BloomEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BloomEffect>(o => o.BaseIntensity)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BloomEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BloomEffect>(o => o.BloomSaturation)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BloomEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BloomEffect>(o => o.BaseSaturation)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );
            #endregion

            #region BrightExtractEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.BrightExtractEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.BrightExtractEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.BrightExtractEffect>(o => o.Threshold)
                , new NumberRangesAttribute(null, 0, 1, null, null)
                , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
                , new NumberFormatAttribute("0'%'", null, 100)
                );
            #endregion

            #region ColorKeyAlphaEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorKeyAlphaEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            #endregion

            #region ColorToneEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorToneEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ColorToneEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ColorToneEffect>(o => o.Desaturation)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ColorToneEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ColorToneEffect>(o => o.Toned)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );
            #endregion

            #region ColorToneAlphaEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorToneAlphaEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ColorToneAlphaEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ColorToneAlphaEffect>(o => o.Desaturation)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ColorToneAlphaEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ColorToneAlphaEffect>(o => o.Toned)
                , new NumberRangesAttribute(null, 0, 10, null, null)
                , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            #endregion

            #region ContrastAdjustEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ContrastAdjustEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ContrastAdjustEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ContrastAdjustEffect>(o => o.Brightness)
                , new NumberRangesAttribute(null, 0, 1, null, null)
                , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
                , new NumberFormatAttribute("0'%'", null, 100)
                );

            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.ContrastAdjustEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.ContrastAdjustEffect>(o => o.Contrast)
                , new NumberRangesAttribute(null, 0, 1, null, null)
                , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
                , new NumberFormatAttribute("0'%'", null, 100)
                );
            #endregion

            #region DirectionalBlurEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.DirectionalBlurEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.DirectionalBlurEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.DirectionalBlurEffect>(o => o.Angle)
               , new NumberRangesAttribute(0, 0, 10, 360, null)
               , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );


            builder.AddCustomAttributes(
                typeof(ShaderEffectLibrary.DirectionalBlurEffect)
                , Ext.GetMemberName<ShaderEffectLibrary.DirectionalBlurEffect>(o => o.BlurAmount)
                , new NumberRangesAttribute(null, 0, 1, null, null)
                , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
                , new NumberFormatAttribute("0'%'", null, 100)
                );
            #endregion

            #region EmbossedEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.EmbossedEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.EmbossedEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.EmbossedEffect>(o => o.Amount)
              , new NumberRangesAttribute(0, 0, 10, 30, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.EmbossedEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.EmbossedEffect>(o => o.Width)
              , new NumberRangesAttribute(0, 0, 0.005, 0.005, null)
              , new NumberIncrementsAttribute(0.0001, 0.001, 0.1)
            );


            #endregion

            #region GloomEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.GloomEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.GloomEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.GloomEffect>(o => o.GloomIntensity)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.GloomEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.GloomEffect>(o => o.BaseIntensity)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.GloomEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.GloomEffect>(o => o.GloomSaturation)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.GloomEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.GloomEffect>(o => o.BaseSaturation)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            #endregion

            #region GrowablePoissonDiskEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.GrowablePoissonDiskEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.GrowablePoissonDiskEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.GrowablePoissonDiskEffect>(o => o.Radius)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.GrowablePoissonDiskEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.GrowablePoissonDiskEffect>(o => o.Width)
              , new NumberRangesAttribute(0, 0, 10, 50, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.GrowablePoissonDiskEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.GrowablePoissonDiskEffect>(o => o.Height)
              , new NumberRangesAttribute(0, 0, 10, 50, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            #endregion

            #region InvertColorEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.InvertColorEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            #endregion

            #region LightStreakEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.LightStreakEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.LightStreakEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.LightStreakEffect>(o => o.BrightThreshold)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.LightStreakEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.LightStreakEffect>(o => o.Scale)
              , new NumberRangesAttribute(0, 0, 10, 4, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.LightStreakEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.LightStreakEffect>(o => o.Attenuation)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            #endregion

            #region MagnifyEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.MagnifyEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.MagnifyEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.MagnifyEffect>(o => o.ShrinkFactor)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );
            #endregion

            #region MonochromeEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.MonochromeEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            #endregion

            #region PinchEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.PinchEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.PinchEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.PinchEffect>(o => o.Radius)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.PinchEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.PinchEffect>(o => o.Amount)
              , new NumberRangesAttribute(0, 0, 10, 4, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.PinchEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.PinchEffect>(o => o.CenterX)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.PinchEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.PinchEffect>(o => o.CenterY)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            #endregion

            #region PixelateEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.PixelateEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.PixelateEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.PixelateEffect>(o => o.HorizontalPixelCounts)
              , new NumberRangesAttribute(0, 0, 10, 800, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );
            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.PixelateEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.PixelateEffect>(o => o.VerticalPixelCounts)
              , new NumberRangesAttribute(0, 0, 10, 800, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );
            #endregion

            #region RippleEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.RippleEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.RippleEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.RippleEffect>(o => o.Amplitude)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.RippleEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.RippleEffect>(o => o.Amplitude)
               , new NumberRangesAttribute(null, 0, 100, null, null)
               , new NumberIncrementsAttribute(0.10, 0.25, 1.0)
            );

            builder.AddCustomAttributes(
              typeof(ShaderEffectLibrary.RippleEffect)
              , Ext.GetMemberName<ShaderEffectLibrary.RippleEffect>(o => o.Phase)
              , new NumberRangesAttribute(0, 0, 10, 10, null)
              , new NumberIncrementsAttribute(0.01, 0.020, 0.1)
            );
            #endregion

            #region SharpenEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.SharpenEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SharpenEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SharpenEffect>(o => o.Amount)
               , new NumberRangesAttribute(null, 0, 100, null, null)
               , new NumberIncrementsAttribute(0.10, 0.25, 1.0)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SharpenEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SharpenEffect>(o => o.Width)
               , new NumberRangesAttribute(null, 0, 100, null, null)
               , new NumberIncrementsAttribute(0.10, 0.25, 1.0)
            );

            #endregion

            #region SmoothMagnifyEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.SmoothMagnifyEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SmoothMagnifyEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SmoothMagnifyEffect>(o => o.InnerRadius)
               , new NumberRangesAttribute(0, 0, 0.6, 0.6, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SmoothMagnifyEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SmoothMagnifyEffect>(o => o.OuterRadius)
               , new NumberRangesAttribute(0, 0, 1.0, 1.0, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SmoothMagnifyEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SmoothMagnifyEffect>(o => o.Magnification)
               , new NumberRangesAttribute(0, 0, 10.0, 10.0, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            );


            #endregion

            #region SwirlEffect

            builder.AddCallback(
                typeof(ShaderEffectLibrary.SwirlEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.SwirlEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.SwirlEffect>(o => o.SwirlStrength)
               , new NumberRangesAttribute(-20, 0, 10.0, 20.0, null)
               , new NumberIncrementsAttribute(0.1, 0.25, 1.0)
            );

            #endregion

            #region ToneMappingEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ToneMappingEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ToneMappingEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ToneMappingEffect>(o => o.Exposure)
               , new NumberRangesAttribute(0, 0, 1.0, 3.0, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ToneMappingEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ToneMappingEffect>(o => o.Gamma)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ToneMappingEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ToneMappingEffect>(o => o.Defog)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ToneMappingEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ToneMappingEffect>(o => o.VignetteRadius)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ToneMappingEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ToneMappingEffect>(o => o.BlueShift)
               , new NumberRangesAttribute(null, 0, 1, null, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
               , new NumberFormatAttribute("0'%'", null, 100)
            );

            #endregion

            #region ToonShaderEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ToonShaderEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
            #endregion

            #region ZoomBlurEffect
            builder.AddCallback(
                typeof(ShaderEffectLibrary.ZoomBlurEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCustomAttributes(
               typeof(ShaderEffectLibrary.ZoomBlurEffect)
               , Ext.GetMemberName<ShaderEffectLibrary.ZoomBlurEffect>(o => o.BlurAmount)
               , new NumberRangesAttribute(0, 0, 1.0, 10.0, null)
               , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            );

            #endregion
        }
    }
}
