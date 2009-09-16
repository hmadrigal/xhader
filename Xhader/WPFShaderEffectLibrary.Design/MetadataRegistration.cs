using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design;
using System.Reflection;
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
            //    , System.Windows.Controls.Design.Common.Extensions.GetMemberName<BrightExtractEffect>(o => o.Threshold)
            //    , new NumberRangesAttribute(null, 0, 1, null, null)
            //    , new NumberIncrementsAttribute(0.01, 0.025, 0.1)
            //    , new NumberFormatAttribute("0'%'", null, 100)
            //    );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.BandedSwirlEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.BloomEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.BrightExtractEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorKeyAlphaEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorToneAlphaEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ColorToneEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ContrastAdjustEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.DirectionalBlurEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.EmbossedEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.GloomEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.GrowablePoissonDiskEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.InvertColorEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.LightStreakEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.MagnifyEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.MonochromeEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.PinchEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.PixelateEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            //builder.AddCallback(
            //    typeof(ShaderEffectLibrary.RippleEffect)
            //    , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            //);

            builder.AddCallback(
                typeof(ShaderEffectLibrary.SharpenEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.SmoothMagnifyEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.SwirlEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ToneMappingEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ToonShaderEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(ShaderEffectLibrary.ZoomBlurEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );
        }
    }
}
