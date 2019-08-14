using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 学比邻老师客户端.UI.Controls
{
    /// <summary>
    /// AvatarUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class AvatarUserControl : UserControl
    {
        public AvatarUserControl()
        {
            InitializeComponent();
            this.DataContext = this; 
        }

        public static Uri Source = new Uri(@"pack://application:,,,/学比邻老师客户端;component/Resources/Avatars/default.jpg");

        

        public ImageSource AvatarImage
        {
            get { return (ImageSource)GetValue(AvatarImageProperty); }
            set { SetValue(AvatarImageProperty, value); }
        }
        public string AvatarBorderThickness
        {
            get { return (string)GetValue(AvatarBorderThicknessProperty); }
            set { SetValue(AvatarBorderThicknessProperty, value); }
        }


        public static readonly DependencyProperty AvatarImageProperty =
            DependencyProperty.RegisterAttached("AvatarImage", typeof(ImageSource), typeof(AvatarUserControl), new PropertyMetadata(new BitmapImage(Source)));

        public static readonly DependencyProperty AvatarBorderThicknessProperty =
                  DependencyProperty.RegisterAttached("AvatarBorderThickness", typeof(string), typeof(AvatarUserControl), new PropertyMetadata("4"));


    }
}
