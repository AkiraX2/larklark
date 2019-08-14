using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace 学比邻老师客户端.UI.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class GridLinesRenderer : DependencyObject
    {
        public static readonly DependencyProperty StrokeWidthProperty = DependencyProperty.Register(
            "StrokeWidth", typeof(double), typeof(GridLinesRenderer), new PropertyMetadata(1.0, OnPropertyChanged)
        );

        public static readonly DependencyProperty StrokeColorProperty = DependencyProperty.Register(
            "StrokeColor", typeof(SolidColorBrush), typeof(GridLinesRenderer),
            new PropertyMetadata(Brushes.Black, OnPropertyChanged)
        );

        public double StrokeWidth
        {
            get => (double) GetValue(StrokeWidthProperty);
            set => SetValue(StrokeWidthProperty, value);
        }

        public SolidColorBrush StrokeColor
        {
            get => (SolidColorBrush) GetValue(StrokeColorProperty);
            set => SetValue(StrokeColorProperty, value);
        }

        public GridLinesRenderer()
        {
            OnPropertyChanged(this, new DependencyPropertyChangedEventArgs());
        }

        private static void OnPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            Type T = Type.GetType("System.Windows.Controls.Grid+GridLinesRenderer," +
                                  "PresentationFramework, Version=4.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
            var glr = Activator.CreateInstance(T);
            Pen glrPen = new Pen(((GridLinesRenderer) source).StrokeColor, ((GridLinesRenderer) source).StrokeWidth);
            glr.GetType().GetField("s_oddDashPen", BindingFlags.Static | BindingFlags.NonPublic)?.SetValue(glr, glrPen);
            glr.GetType().GetField("s_evenDashPen", BindingFlags.Static | BindingFlags.NonPublic)
                ?.SetValue(glr, glrPen);
        }
    }
}