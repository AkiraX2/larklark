using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using 学比邻老师客户端.Common;

namespace 学比邻老师客户端.UI.Converters
{
    class BoolToImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool val = (bool)value;

            if(val == true)
            {
                return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/学比邻老师客户端;component/Resources/Images/Login/img_open.png")));
            }
            else
            {
                return new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/学比邻老师客户端;component/Resources/Images/Login/img_close.png")));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
