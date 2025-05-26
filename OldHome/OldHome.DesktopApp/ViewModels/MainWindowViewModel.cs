using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.Messages;
using OldHome.DesktopApp.Services;
using OldHome.DTO;
using OldHome.DTO.Base;

namespace OldHome.DesktopApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly WebApi _api;
        private readonly IUserSessionService _userSessionService;

        private string _checkedName = string.Empty;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isSuperAdmin = false;
        public bool IsSuperAdmin
        {
            get { return _isSuperAdmin; }
            set { SetProperty(ref _isSuperAdmin, value); }
        }

        private List<OrgSample> _orgs;
        public List<OrgSample> Orgs
        {
            get { return _orgs; }
            set { SetProperty(ref _orgs, value); }
        }

        private int? _selectedOrgId;
        public int? SelectedOrgId
        {
            get { return _selectedOrgId; }
            set
            {
                SetProperty(ref _selectedOrgId, value);
                if (value != null)
                {
                    _userSessionService.ChangeOrgId(value.Value);
                }
            }
        }

        private List<NavigationGroup> _navigations = new();
        public List<NavigationGroup> NavigationGroups
        {
            get { return _navigations; }
            set { SetProperty(ref _navigations, value); }
        }

        private string _bardcrumbTitle;
        public string BardcrumbTitle
        {
            get { return _bardcrumbTitle; }
            set { SetProperty(ref _bardcrumbTitle, value); }
        }

        IRegionManager _regionManager;
        public string _username;
        private readonly NavigationsContainer _navigationsContainer;

        public MainWindowViewModel(IRegionManager regionManager, WebApi api,
            NavigationsContainer navigationsContainer, IUserSessionService userSessionService)
        {
            _api = api;
            _userSessionService = userSessionService;
            Title = "养老院管理系统";
            _regionManager = regionManager;
            NavigationGroups = navigationsContainer.GetAll()
                .GroupBy(n => n.Group)
                .OrderBy(p => p.Key)
                .Select(g => new NavigationGroup
                {
                    Group = g.Key,
                    Items = g.OrderBy(n => n.Order).ToList()
                })
                .ToList();
            var defaultN = navigationsContainer.GetAll().First(p => p.IsDefault);
            if (userSessionService.IsSuperAdmin)
            {
                IsSuperAdmin = true;
            }
            if (defaultN is not null)
            {
                regionManager.RegisterViewWithRegion("ContentRegion", defaultN.Path);
                _checkedName = defaultN.Name;
                BardcrumbTitle = defaultN.Title;
            }
            _navigationsContainer = navigationsContainer;
        }


        private AsyncDelegateCommand _loaded;
        public AsyncDelegateCommand LoadedCommand =>
            _loaded ?? (_loaded = new AsyncDelegateCommand(ExecuteLoadedCommand));

        async Task ExecuteLoadedCommand()
        {
            var resp = await _api.GetAllOrgSamples();
            if (resp.IsSuccess)
            {
                Orgs = resp.Data;
            }
            SelectedOrgId = _userSessionService.OrgId;
        }

        private DelegateCommand<string> _navigate;
        public DelegateCommand<string> NavigateCommand =>
            _navigate ?? (_navigate = new DelegateCommand<string>(ExecuteNavigateCommand));

        void ExecuteNavigateCommand(string parameter)
        {
            try
            {
                if (!string.IsNullOrEmpty(parameter) && _checkedName != parameter)
                {
                    _regionManager.RequestNavigate("ContentRegion", parameter);
                    if (_navigationsContainer.ContainsKey(parameter))
                    {
                        BardcrumbTitle = _navigationsContainer.Get(parameter).Title;
                    }
                    _checkedName = parameter;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
