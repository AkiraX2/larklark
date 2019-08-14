using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace 学比邻老师客户端.Common
{
    class BitmapImageHelper
    {

        public static BitmapImage LoadImageFromFile(string filePath)
        {
            BitmapImage bitmap = new BitmapImage();
            if (File.Exists(filePath))
            {
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                using (Stream ms = new MemoryStream(File.ReadAllBytes(filePath)))
                {
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }
            return bitmap;
        }
    }
}
