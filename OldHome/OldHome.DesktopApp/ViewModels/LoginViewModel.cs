using OldHome.API;
using OldHome.API.Services;
using OldHome.DesktopApp.Services;
using OldHome.DTO;
using Prism.Common;
using System.Windows;

namespace OldHome.DesktopApp.ViewModels
{
    public class LoginViewModel : BindableBase
    {

        private IRegionManager _regionManager;
        private IUserSessionService _userSession;
        private INotificationUIService _notificationUIService;
        private ApiManager _api;
        private IContainerExtension _containerExtension;

        public LoginViewModel(IRegionManager regionManager, IContainerExtension containerExtension
            , IUserSessionService userSession, ApiManager api, INotificationUIService notificationUIService)
        {
            _regionManager = regionManager;
            _api = api;
            _notificationUIService = notificationUIService;
            _userSession = userSession;
            _containerExtension = containerExtension;
#if DEBUG
            UserName = "admin";
            Password = "admin";
            SelectedOrgId = 1;
#endif
        }

        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private List<OrgSample> _orgs;
        public List<OrgSample> Orgs
        {
            get { return _orgs; }
            set { SetProperty(ref _orgs, value); }
        }

        private int _selectedOrgId;
        public int SelectedOrgId
        {
            get { return _selectedOrgId; }
            set { SetProperty(ref _selectedOrgId, value); }
        }


        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        private AsyncDelegateCommand _loaded;
        public AsyncDelegateCommand LoadedCommand =>
            _loaded ?? (_loaded = new AsyncDelegateCommand(ExecuteLoadedCommand));

        async Task ExecuteLoadedCommand()
        {
            var response = await _api.OrgApi.GetAllOrgSamples();
            if (response.IsSuccess)
            {
                Orgs = response.Data!;
            }
            else
            {
                _notificationUIService.ShowError(response.Message);
            }
        }

        private AsyncDelegateCommand _login;
        public AsyncDelegateCommand LoginCommand =>
            _login ?? (_login = new AsyncDelegateCommand(ExecuteLoginCommand));

        async Task ExecuteLoginCommand()
        {
            try
            {
                var resp = await _api.AuthApi.SignIn(SelectedOrgId, UserName, Password)!;
                if (resp.IsSuccess)
                    _userSession.SetSession(resp.Data.UserName, resp.Data.Token, resp.Data.Role, resp.Data.OrgId);
                else
                {
                    _notificationUIService.ShowWarning("登录失败，请检查用户名/密码");
                    return;
                }
                var mainWindow = ContainerLocator.Container.Resolve<MainWindow>();
                MvvmHelpers.AutowireViewModel(mainWindow);
                var rm = _containerExtension.Resolve<IRegionManager>();
                RegionManager.SetRegionManager(mainWindow, rm);
                RegionManager.UpdateRegions();
                mainWindow.Show();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainWindow;
            }
            catch (Exception ex)
            {
                _notificationUIService.ShowError(ex.Message);
            }
        }
    }
}
