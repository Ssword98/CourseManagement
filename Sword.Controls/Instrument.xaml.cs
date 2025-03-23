using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sword.Controls
{
    /// <summary>
    /// Instrument.xaml 的交互逻辑
    /// </summary>
    public partial class Instrument : UserControl
    {
        //
        #region 依赖属性，依赖对象
        public double Value
        {
            get { return (double)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Instrument),
            new PropertyMetadata(double.NaN, new PropertyChangedCallback(OnPropertyChanged)));

        public int Minimum
        {
            get { return (int)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Minimum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(int), typeof(Instrument),
                new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int Maximum
        {
            get { return (int)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Maximum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(int), typeof(Instrument),
                new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Interval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register("Interval", typeof(int), typeof(Instrument),
            new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public Brush PlateBackGround
        {
            get { return (Brush)GetValue(PlateBackGroundProperty); }
            set { SetValue(PlateBackGroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for PlateBackGround.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlateBackGroundProperty = DependencyProperty.Register("PlateBackGround", typeof(Brush), typeof(Instrument),
            new PropertyMetadata(default(Brush)));

        public int ScaleTextSize
        {
            get { return (int)GetValue(ScaleTextSizeProperty); }
            set { SetValue(ScaleTextSizeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ScaleTextSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleTextSizeProperty = DependencyProperty.Register("ScaleTextSize", typeof(int), typeof(Instrument),
            new PropertyMetadata(default(int), new PropertyChangedCallback(OnPropertyChanged)));

        public Brush ScaleBrush
        {
            get { return (Brush)GetValue(ScaleBrushProperty); }
            set { SetValue(ScaleBrushProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ScaleBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ScaleBrushProperty = DependencyProperty.Register("ScaleBrush", typeof(Brush), typeof(Instrument),
            new PropertyMetadata(default(Brush), new PropertyChangedCallback(OnPropertyChanged)));

        #endregion

        public static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Instrument).Refresh();
        }

        public Instrument()
        {
            InitializeComponent();

            this.SizeChanged += Instrument_SizeChanged;
        }

        private void Instrument_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double minSize = Math.Min(this.RenderSize.Width, this.RenderSize.Height);
            this.backEllipse.Width = minSize;
            this.backEllipse.Height = minSize;
        }

        private void Refresh()
        {
            //获取中心位置
            double radius = this.backEllipse.Width / 2;
            if (double.IsNaN(radius))
            {
                return;
            }

            this.mainCanvas.Children.Clear();

            int min = this.Minimum, max = this.Maximum;
            double scaleAreaCount = this.Interval;
            double step = 270.0 / (max - min);  //获取每个刻度的角度
            double stepText = (max - min) / scaleAreaCount;
            double scaleThickness = 1;//设置线条粗细
            for (int i = 0; i <= max - min; i++)
            {
                Line lineScale = new Line(); //创建刻度线条
                scaleThickness = 1;
                int length1 = 13, length2 = 8;
                //计算刻度线条的起始点和终止点
                double angle = i * step;
                if (i % scaleAreaCount == 0)
                {
                    length1 = 20;
                    length2 = 8;
                    scaleThickness = 2;

                    TextBlock textScale = new TextBlock();
                    textScale.Width = 34;
                    textScale.TextAlignment = TextAlignment.Center;
                    textScale.Text = ((int)(min + stepText * i / 10)).ToString();
                    textScale.Foreground = this.ScaleBrush;
                    textScale.FontSize = this.ScaleTextSize;
                    Canvas.SetLeft(textScale, radius - (radius - length1 - 10) * Math.Cos((angle - 45) * Math.PI / 180) - 17);
                    Canvas.SetTop(textScale, radius - (radius - length1 - 10) * Math.Sin((angle - 45) * Math.PI / 180) - 10);
                    //textScale.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    //textScale.Arrange(new Rect(0, 0, textScale.DesiredSize.Width, textScale.DesiredSize.Height));
                    //textScale.RenderTransform = new TranslateTransform(radius - textScale.DesiredSize.Width / 2, radius - length1 - textScale.DesiredSize.Height);
                    this.mainCanvas.Children.Add(textScale);
                }

                lineScale.X1 = radius - (radius - length1) * Math.Cos((angle - 45) * Math.PI / 180);
                lineScale.Y1 = radius - (radius - length1) * Math.Sin((angle - 45) * Math.PI / 180);
                lineScale.X2 = radius - (radius - length2) * Math.Cos((angle - 45) * Math.PI / 180);
                lineScale.Y2 = radius - (radius - length2) * Math.Sin((angle - 45) * Math.PI / 180);

                lineScale.Stroke = this.ScaleBrush; //设置线条颜色
                lineScale.StrokeThickness = scaleThickness; //设置线条粗细
                this.mainCanvas.Children.Add(lineScale);
            }

            //绘制圆环
            string sData = "M{0} {1} A{0} {0} 0 1 1 {1} {2}";
            sData = string.Format(sData, radius / 2, radius, radius * 1.5);
            var converter = TypeDescriptor.GetConverter(typeof(Geometry));
            this.circle.Data = (Geometry)converter.ConvertFrom(sData);

            //this.rtPoint.Angle = this.Value*step-45;
            double value = double.IsNaN(this.Value) ? 0 : this.Value;
            DoubleAnimation da = new DoubleAnimation((value - min)* step - 45, new Duration(TimeSpan.FromMilliseconds(200)));
            this.rtPoint.BeginAnimation(RotateTransform.AngleProperty, da);

            //绘制指针
            sData = "M{0} {1},{1} {2},{1} {3}";
            sData = string.Format(sData, radius * 0.3, radius, radius - 5, radius + 5);
            this.point.Data = (Geometry)converter.ConvertFrom(sData);


        }
    }
}
