using Caliburn.Micro;

using System.Threading;
using System.Threading.Tasks;

namespace ViewChangerAsync.ViewModels
{
   public class ShellViewModel : Conductor<object>.Collection.OneActive
    {
        private CenterContentViewModel _centerContentControl;

        public CenterContentViewModel CenterContentControl
        {
            get { return _centerContentControl; }
            set 
            {
                _centerContentControl = value;
                NotifyOfPropertyChange(() => CenterContentControl); 
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set 
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        //private NavigationViewModel _navigationUserControl;

        //public NavigationViewModel NavigationUserControl
        //{
        //    get { return _navigationUserControl; }
        //    set 
        //    { 
        //        _navigationUserControl = value;
        //        NotifyOfPropertyChange(() => NavigationUserControl);
        //    }
        //}

        public ShellViewModel()
        {
            Title = "Start Screen";
            //NavigationUserControl = IoC.Get<NavigationViewModel>();
            //CenterContentControl = IoC.Get<CenterContentViewModel>();
            //Items.Add(NavigationUserControl);
            //Items.Add(CenterContentControl);
            ActivateItemAsync(IoC.Get<NavigationViewModel>(), new CancellationToken());
        }

        public async Task ChangeView()
        {

            //Title = "After Click";
            //NavigationUserControl = IoC.Get<NavigationViewModel>();
            //CenterContentControl = IoC.Get<CenterContentViewModel>();
            //Items.Add(NavigationUserControl);
            //Items.Add(CenterContentControl);
            await ActivateItemAsync(IoC.Get<NavigationViewModel>(), new CancellationToken());
        }

        public async Task NavToChildConductor()
        {
            await ActivateItemAsync(IoC.Get<ChildConductorViewModel>(), new CancellationToken());
        }

        public async Task NavBackToMainControler()
        {
            await ActivateItemAsync(IoC.Get<NavigationViewModel>(), new CancellationToken());
        }
    }
}
