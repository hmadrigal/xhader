using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Metadata;
using System.Windows.Controls.Design.Common;
using Microsoft.Windows.Design;
using System.Reflection;
#if SILVERLIGHT
[assembly: ProvideMetadata(typeof(SLTransitionEffects.Design.MetadataRegistration))]
namespace SLTransitionEffects.Design
#else
[assembly: ProvideMetadata(typeof(WPFTransitionEffects.Design.MetadataRegistration))]
namespace WPFTransitionEffects.Design
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
            AssemblyName asmName = typeof(TransitionEffects.BandedSwirlTransitionEffect).Assembly.GetName();
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
                typeof(TransitionEffects.BandedSwirlTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.BlindsTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.BloodTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CircleRevealTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CircleStretchTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CircularBlurTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CloudRevealTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CloudyTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.CrumbleTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.DisolveTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.DropFadeTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.FadeTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.LeastBrightTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.LineRevealTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.MostBrightTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.PixelateInTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.PixelateOutTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.PixelateTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RadialBlurTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RadialWiggleTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RandomCircleRevealTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RandomizedTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RippleTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.RotateCrumbleTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.SaturateTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.ShrinkTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.SlideInTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.SmoothSwirlGridTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.SwirlGridTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.SwirlTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.TransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.WaterTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );

            builder.AddCallback(
                typeof(TransitionEffects.WaveTransitionEffect)
                , b => b.AddCustomAttributes(new ToolboxBrowsableAttribute(true))
            );


        }
    }
}
