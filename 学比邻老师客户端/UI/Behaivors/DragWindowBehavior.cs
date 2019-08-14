using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace UI.Behaivors
{
    public class DragWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseDown;
        }

        private void AssociatedObject_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AssociatedObject.DragMove();
        }

        protected override void OnDetaching()
        {

            AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseDown;
            base.OnDetaching();
        }
    }
}
