using Anotar.NLog;
using Stylet;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using 学比邻老师客户端;
using 学比邻老师客户端.ViewModels;

namespace UI.Windows
{
    /// <summary>
    /// Window Closing Animation Mixin.
    /// </summary>
    [Obsolete]
    public interface IAnimCloseWindow : IWindowMixin
    {
        /// <summary>
        /// Define your Close Animation here.
        /// #Warning Remember to add code
        /// <c>+= CloseAnimationCompleted</c> to your Animation Completed.
        /// </summary>
        /// 
        /// <example> 
        /// <code>
        /// void Anim_Closing() {
        ///     ...
        ///     YourAnimation.Completed += CloseAnimationCompleted;
        ///     ...
        ///     
        /// }
        /// </code> 
        /// </example>
        /// 
        void Anim_Closing();
        bool CloseStoryBoardCompleted { get; set; }

        /// <summary>
        /// Animation Completed Delegation
        /// </summary>
        event EventHandler CloseAnimationCompleted;

    }


    public static class IAnimCloseWindowExtends
    {
        /// <summary>
        /// Call this in Construct Method.
        /// </summary>
        /// <param name="acw"></param>
        public static void InitAnimCloseWindow(this IAnimCloseWindow acw)
        { 
            acw.Window.Closing += acw.Window_Closing;

            acw.Window.RenderTransformOrigin = new Point { X = 0.5, Y = 0.5 };
             

            acw.CloseStoryBoardCompleted = false;

            acw.CloseAnimationCompleted += (x, y) =>
            {
                LogTo.Debug("Window_Closing Animation Completed.");
                acw.CloseStoryBoardCompleted = true;
                acw.Window.Close();

            };
        }


        private static void Window_Closing(this IAnimCloseWindow acw, object sender, CancelEventArgs e)
        {

            if (!acw.CloseStoryBoardCompleted)
            {

                acw.Anim_Closing(); 

                e.Cancel = true;
            }
        }

    }

   


}
