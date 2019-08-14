using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace UI.Windows
{
    public interface IWindowMixin
    {
        Window Window { get; }

    }



    /// <summary>
    /// Example Window
    /// </summary>
    public abstract class AbstractMixinWindow : Window, IDragWindow, IAnimCloseWindow
    {
        protected AbstractMixinWindow()
        {
            this.InitAnimCloseWindow();
            this.InitDragWindow();
        }

        public virtual DoubleAnimation CloseAnimation { get; set; } = new DoubleAnimation
        {
            From = 1,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.5),
            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseInOut }
        };



        public Window Window => this;

        public bool CloseStoryBoardCompleted { get; set; } = false;

        public virtual event EventHandler CloseAnimationCompleted;

        public virtual void Anim_Closing()
        {

            CloseAnimation.Completed += CloseAnimationCompleted;

            Window.BeginAnimation(Window.OpacityProperty, CloseAnimation);

        }
    }
}
