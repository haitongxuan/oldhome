using OldHome.API;
using OldHome.API.Services;
using OldHome.DesktopApp.Services;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseViewModel : BindableBase
    {
        public abstract Task LoadDataAsync();
        protected readonly INotificationUIService _notificationUIService;
        protected readonly ApiManager _api;
        protected readonly IUserSessionService _user;

        public BaseViewModel()
        {
            _notificationUIService = ContainerLocator.Container.Resolve<INotificationUIService>();
            _user = ContainerLocator.Container.Resolve<IUserSessionService>();
            _api = ContainerLocator.Container.Resolve<ApiManager>();
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
