using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ColorHelper
    {
        public static System.Windows.Media.Color ConvertHtmlToColor(string value)
        {
            int r = 0, g = 0, b = 0;
            if (value.StartsWith("#"))
            {
                int v = Convert.ToInt32(value.Substring(1), 16);
                r = (v >> 16) & 255; g = (v >> 8) & 255; b = v & 255;
            }

            return System.Windows.Media.Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }
    }
}
