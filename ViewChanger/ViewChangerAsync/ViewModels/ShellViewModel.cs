using Caliburn.Micro;

using System.Threading;
using System.Threading.Tasks;

namespace ViewChangerAsync.ViewModels
{
   public class ShellViewModel : Conductor<object>
    {
        private NavigationViewModel _navigationUserControl;

        public NavigationViewModel NavigationUserControl
        {
            get { return _navigationUserControl; }
            set 
            { 
                _navigationUserControl = value;
                NotifyOfPropertyChange(() => NavigationUserControl);
            }
        }

        public ShellViewModel()
        {
            //Navigation UserControl Loads
            //NavigationUserControl = IoC.Get<NavigationViewModel>();
            //ActivateItemAsync(NavigationUserControl, new CancellationToken());
            //ActivateItemAsync(IoC.Get<MainScreenViewModel>(), new CancellationToken());
        }

        public async Task ChangeView()
        {
            ////Navigation UserControl Does not Load into the ContentControl
            var viewModel = IoC.Get<NavigationViewModel>();
            var view = ViewLocator.LocateForModel(viewModel, null, null);
            ViewModelBinder.Bind(viewModel, view, null);
            var activator = viewModel as IActivate;
            if(activator != null)
            {
                await activator.ActivateAsync();
            }
            
            //await ActivateItemAsync(NavigationUserControl, new CancellationToken());
            await ActivateItemAsync(IoC.Get<MainScreenViewModel>(), new CancellationToken());
        }
    }
}
