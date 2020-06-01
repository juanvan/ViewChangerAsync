using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ViewChangerAsync.ViewModels
{
    public class NavigationViewModel : Screen
    {
        protected override void OnViewReady(object view)
        {
            base.OnViewReady(view);
            Caliburn.Micro.Action.Invoke(this, "OnViewReady", (DependencyObject)view);
        }
        public virtual IEnumerable<IResult> OnViewReady()
        {
            yield break;
        }
    }
}
