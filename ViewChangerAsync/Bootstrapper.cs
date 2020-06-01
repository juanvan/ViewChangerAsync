using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using ViewChangerAsync.ViewModels;

namespace ViewChangerAsync
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {

            //_container.Instance(ConfigureAutomapper());

            //_container.Instance(_container)
            //    .PerRequest<IProductEndpoint, ProductEndpoint>()
            //    .PerRequest<ISalesEndpoint, SalesEndpoint>()
            //    .PerRequest<IUserEndpoint, UserEndpoint>();

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();
            //.Singleton<ILoggedInUserModel, LoggedInUserModel>()
            //.Singleton<IConfigHelper, ConfigHelper>();
            //_container.CreateChildContainer();
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
