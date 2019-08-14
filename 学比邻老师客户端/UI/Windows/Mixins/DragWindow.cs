using Stylet;
using System;
using System.Windows;
using System.Windows.Input;
using 学比邻老师客户端;
using 学比邻老师客户端.ViewModels;

namespace UI.Windows
{
    /// <summary>
    /// Window Mouse Drag Mixin.
    /// </summary>
    [Obsolete("Use Behaviors instead.")]
    public interface IDragWindow : IWindowMixin
    {  

    }



    public static class DragWindowExtends 
    {
        /// <summary>
        /// Call this in Construct Method.
        /// </summary>
        /// <param name="dw"></param>
        public static void InitDragWindow(this IDragWindow dw)
        {

            dw.Window.MouseDown += dw.Window_MouseDown;
        }


        private static void Window_MouseDown(this IDragWindow dw, object sender, MouseButtonEventArgs e)
        { 
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (dw?.Window)?.DragMove();
            }
        }

    }
}
