using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace 学比邻老师客户端.UI.Decorators
{
    public sealed class WatermarkPasswordBox : Decorator
    {
        public WatermarkPasswordBox()
        {
            PasswordBox = new PasswordBox();
            PasswordBox.Style = AppHelper.GetResource<Style>("WatermarkPasswordBoxStyle");
            PasswordBox.PasswordChanged += PwdBox_PasswordChanged;
            this.Child = PasswordBox;
        }

        private void PwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasPassword = !string.IsNullOrWhiteSpace(PasswordBox.Password);
        }

        public bool HasPassword
        {
            get { return (bool)GetValue(HasPasswordProperty); }
            private set { SetValue(HasPasswordProperty, value); }
        }

        public static readonly DependencyProperty HasPasswordProperty =
            DependencyProperty.RegisterAttached("HasPassword", typeof(bool), typeof(WatermarkPasswordBox), new PropertyMetadata(false));

        public object Watermark
        {
            get { return (object)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(object), typeof(WatermarkPasswordBox), new PropertyMetadata(null));
        
        public PasswordBox PasswordBox { get; private set; }
    }
}
