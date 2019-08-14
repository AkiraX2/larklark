using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace UI.Behaivors
{
    public class TopmostWindowBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.Activated += AssociatedObject_Activated;
            AssociatedObject.Deactivated += AssociatedObject_Deactivated;
        }

        private void AssociatedObject_Deactivated(object sender, EventArgs e)
        {
            AssociatedObject.Topmost = false;
        }

        private void AssociatedObject_Activated(object sender, EventArgs e)
        {
            AssociatedObject.Topmost = true;

        }

        protected override void OnDetaching()
        {

            AssociatedObject.Activated -= AssociatedObject_Activated;
            AssociatedObject.Deactivated -= AssociatedObject_Deactivated;
            base.OnDetaching();
        }
    }
}
