﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ConsoleManagerEx
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public const int SW_HIDE = 0;
        public const int SW_SHOW = 5;

        private static bool IsOpen = true;

        public static void Toggle()
        {
          
            ConsoleManagerEx.ShowWindow(ConsoleManagerEx.GetConsoleWindow(), IsOpen? ConsoleManagerEx.SW_HIDE: ConsoleManagerEx.SW_SHOW);
            IsOpen = !IsOpen;
        }




    }
}
