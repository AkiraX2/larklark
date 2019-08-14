using Anotar.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace UI.Behaivors
{
    public class CloseWindowBehavior : Behavior<Window>
    {
        public bool CloseStoryBoardCompleted { get; private set; } = false;

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Closing += AssociatedObject_Closing;

            CloseAnimation.Completed += CloseAnimation_Completed;


        }

        private void AssociatedObject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!CloseStoryBoardCompleted)
            {

                Anim_Closing();

                e.Cancel = true;
            }
        }
 

        protected override void OnDetaching()
        {

            AssociatedObject.Closing -= AssociatedObject_Closing;
            base.OnDetaching();
        }



        public DoubleAnimation CloseAnimation { get; set; } = new DoubleAnimation
        {
            From = 1,
            To = 0,
            Duration = TimeSpan.FromSeconds(0.6),
            EasingFunction = new BackEase() { EasingMode = EasingMode.EaseInOut }
        };
        public ScaleTransform ScaleTransform { get; private set; }

        public void Anim_Closing()
        {
            AssociatedObject.RenderTransformOrigin = new Point { X = 0.5, Y = 0.5 };
            ScaleTransform = AssociatedObject.FindName("MScaleTransform") as ScaleTransform;
            ScaleTransform?.BeginAnimation(ScaleTransform.ScaleXProperty, CloseAnimation.Clone());
            ScaleTransform?.BeginAnimation(ScaleTransform.ScaleYProperty, CloseAnimation.Clone());
            AssociatedObject.BeginAnimation(UIElement.OpacityProperty, CloseAnimation);


        }

        private void CloseAnimation_Completed(object sender, EventArgs e)
        {
            LogTo.Debug("Window_Closing Animation Completed.");
            CloseStoryBoardCompleted = true;
            AssociatedObject.Close();
        }
    }
}
