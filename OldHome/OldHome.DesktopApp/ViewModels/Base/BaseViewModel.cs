using OldHome.DesktopApp.Messages;
using OldHome.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseViewModel : BindableBase
    {
        public abstract Task LoadDataAsync();
        protected readonly INotificationUIService _notificationUIService;
        protected readonly WebApi _api;

        public BaseViewModel()
        {
            _notificationUIService = ContainerLocator.Container.Resolve<INotificationUIService>();
            _api = ContainerLocator.Container.Resolve<WebApi>();
        }

        private AsyncDelegateCommand _loaded;
        public AsyncDelegateCommand LoadedCommand =>
            _loaded ?? (_loaded = new AsyncDelegateCommand(ExecuteLoadedCommand));

        async Task ExecuteLoadedCommand()
        {
            await LoadDataAsync();
        }
    }
}
