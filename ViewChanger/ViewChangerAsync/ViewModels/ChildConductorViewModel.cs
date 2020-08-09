using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewChangerAsync.ViewModels
{
    public class ChildConductorViewModel : Conductor<object>.Collection.AllActive
    {
        public ChildConductorViewModel()
        {
            NavigationUserControl = IoC.Get<NavigationViewModel>();
            CenterContentControl = IoC.Get<CenterContentViewModel>();
            Items.Add(NavigationUserControl);
            Items.Add(CenterContentControl);
        }

        public NavigationViewModel NavigationUserControl { get; private set; }
        public CenterContentViewModel CenterContentControl { get; private set; }
    }
}
