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
    /// LoadingCircle.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingCircle : UserControl
    {
        public LoadingCircle()
        {
            InitializeComponent();
        }


        public string ArcThickness
        {
            get => (string) GetValue(ArcThicknessProperty);
            set => SetValue(ArcThicknessProperty, value);
        }

        // Using a DependencyProperty as the backing store for ArcThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ArcThicknessProperty =
            DependencyProperty.Register("ArcThickness", typeof(string), typeof(LoadingCircle),
                new PropertyMetadata("1"));


        public bool IsStarted
        {
            get => (bool) GetValue(IsStartedProperty);
            set => SetValue(IsStartedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsStarted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsStartedProperty =
            DependencyProperty.Register("IsStarted", typeof(bool), typeof(LoadingCircle), new PropertyMetadata(false));
    }
}