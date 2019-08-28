using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace 学比邻老师客户端.UI.Controls
{
    public class ImageButton : Button
    {
        public ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        // 默认图标
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Brush), typeof(ImageButton));

        //        public static readonly DependencyProperty MouseOverBackgroundProperty =
        //            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(ImageButton));
        //
        //        public string MouseOverBackground
        //        {
        //            get => (string)GetValue(MouseOverBackgroundProperty);
        //            set => SetValue(MouseOverBackgroundProperty, value);
        //        }
        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }

}