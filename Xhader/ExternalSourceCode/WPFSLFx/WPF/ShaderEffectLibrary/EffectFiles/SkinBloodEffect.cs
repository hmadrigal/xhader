namespace ShaderEffectLibrary
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;
    using System.Windows.Media.Imaging;
#if SILVERLIGHT 
    using UIPropertyMetadata = System.Windows.PropertyMetadata ;      
#endif
    /// <summary>
    /// Helps to add a blood-effect on a given element
    /// </summary>
    public class SkinBloodEffect : ShaderEffect
    {

        #region Consts
        const int STROKE_TEXTURE_WIDTH = 128;
        const int STROKE_TEXTURE_HEIGHT = 128; 
        #endregion

        #region Member data
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
        /// Brush-valued properties turn into sampler-property in the shader.
        /// This helper sets "ImplicitInput" as the default, meaning the default
        /// sampler is whatever the rendering of the element it's being applied to is.
        /// </summary>
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(SkinBloodEffect), 0);

        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>05/minValue>
        /// <maxValue>10</maxValue>
        /// <defaultValue>3.5</defaultValue>
        public Brush Stroke1
        {
            get
            {
                return ((Brush)(this.GetValue(Stroke1Property)));
            }
            set
            {
                this.SetValue(Stroke1Property, value);
            }
        }
        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>05/minValue>
        /// <maxValue>10</maxValue>
        /// <defaultValue>3.5</defaultValue>
        public static readonly DependencyProperty Stroke1Property = ShaderEffect.RegisterPixelShaderSamplerProperty("Stroke1", typeof(SkinBloodEffect), 1);

        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>1,1/minValue>
        /// <maxValue>100,100</maxValue>
        /// <defaultValue>7,7</defaultValue>
        public Point Tile
        {
            get
            {
                return ((Point)(this.GetValue(TileProperty)));
            }
            set
            {
                this.SetValue(TileProperty, value);
            }
        }

        /// <summary>Explain the purpose of this variable.</summary>
        /// <minValue>1,1/minValue>
        /// <maxValue>100,100</maxValue>
        /// <defaultValue>7,7</defaultValue>
        public static readonly DependencyProperty TileProperty = DependencyProperty.Register("Tile", typeof(Point), typeof(SkinBloodEffect), new PropertyMetadata(new Point(7, 7), PixelShaderConstantCallback(1)));

        /// <summary>
        /// 
        /// </summary>
        private static PixelShader pixelShader = new PixelShader(); 
        #endregion

        private double _scale = 1;

        /// <summary>
        /// Stroke Scale
        /// </summary>
        [System.ComponentModel.BrowsableAttribute(false)]
        public double StrokeScale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                Tile = new Point(_tileXAtScale1 * _scale, _tileYAtScale1 * _scale);
            }
        }
        
        private double _tileXAtScale1 = 7;
        private double _tileYAtScale1 = 7;

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SkinBloodEffect()
        {
            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/SkinBloodEffect.ps");
            this.PixelShader = pixelShader;

            this.UpdateShaderValue(InputProperty);
            this.UpdateShaderValue(Stroke1Property);
            this.UpdateShaderValue(TileProperty);

            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(Global.MakePackUri("Textures/BloodTexture.jpg"));
            Stroke1 = brush;
        }
        static SkinBloodEffect()
        {
            pixelShader.UriSource = Global.MakePackUri("ShaderSource/HatchingEffect.ps");
        }
        #endregion

        /// <summary>
        /// Set the Shaded Image Size
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetShadedImageSize(int width, int height)
        {
            _tileXAtScale1 = ((double)width) / STROKE_TEXTURE_WIDTH;
            _tileYAtScale1 = ((double)height) / STROKE_TEXTURE_HEIGHT;
            Tile = new Point(_tileXAtScale1 * _scale, _tileYAtScale1 * _scale);
        }
    }
}
