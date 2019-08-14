using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace 学比邻老师客户端.UI.Controls
{
    public class AnimatedButton : Button
    {
        public bool IsLoading
        {
            get => (bool) GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }


        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.RegisterAttached("IsLoading", typeof(bool), typeof(AnimatedButton),
                new PropertyMetadata(false));
    }
}