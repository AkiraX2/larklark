using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows; 

namespace Common
{
    public static class AppHelper
    {
        public static Version AppVersion = Application.ResourceAssembly.GetName().Version;
        public static string AppName = Application.ResourceAssembly.GetName().Name;
        public static string AppFullName = Application.ResourceAssembly.GetName().FullName;
        public static string AppNameWithVersion = $"{AppName} {AppVersion}";
        
        /// <summary>
        /// Get xaml resource
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resource_name"></param>
        /// <returns></returns>
        public static T GetResource<T>( string resource_name)
        {
            return (T)Application.Current.Resources[resource_name];
        }
    }
}
