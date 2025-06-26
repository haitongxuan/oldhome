using FluentValidation;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;

namespace OldHome.DesktopApp.ViewModels
{
    public class FormUserViewModel : BaseFormViewModel<UserDto, FormUserViewModel>
    {
        public FormUserViewModel(IValidator<FormUserViewModel> validator) : base(validator)
        {
        }
        #region Properties
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _phoneNumber = string.Empty;

        public string UserName
        {
            get => _username;
            set
            {
                SetProperty(ref _username, value);
                ValidateProperty(nameof(UserName));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                ValidateProperty(nameof(Password));
            }
        }

        public string PhoneNum
        {
            get => _phoneNumber;
            set => SetProperty(ref _phoneNumber, value);
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { SetProperty(ref _createAt, value); }
        }

        private int? _roleId;
        public int? RoleId
        {
            get { return _roleId; }
            set
            {
                SetProperty(ref _roleId, value);
                ValidateProperty(nameof(RoleId));  // Validate RoleId property
            }
        }

        private int? _orgId;
        public int? OrgId
        {
            get { return _orgId; }
            set
            {
                SetProperty(ref _orgId, value);
                ValidateProperty(nameof(OrgId));  // Validate OrgId property
            }
        }

        private List<RoleSample> _roles = new List<RoleSample>();
        public List<RoleSample> Roles
        {
            get { return _roles; }
            set { SetProperty(ref _roles, value); }
        }

        private List<OrgSample> _orgs = new List<OrgSample>();


        public List<OrgSample> Orgs
        {
            get { return _orgs; }
            set { SetProperty(ref _orgs, value); }
        }
        #endregion


        public override async Task ChangeState(UserDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                UserName = detail.UserName;
                PhoneNum = detail.PhoneNum;
                Password = string.Empty;
                CreateAt = detail.CreateAt;
                RoleId = detail.RoleId;
                OrgId = detail.OrgId;
            }
            else
            {
                UserName = string.Empty;
                PhoneNum = string.Empty;
                Password = string.Empty;
                CreateAt = null;
                RoleId = null;
                OrgId = null;
            }
        }

        public override async Task LoadDataAsync()
        {
            var res = await _api.OrgApi.GetAllOrgSamples();
            if (res.IsSuccess)
            {
                Orgs = res.Data!;
            }
            else
            {
                _notificationUIService.ShowError(res.Message);
            }
            var roleRes = await _api.RoleApi.GetAllRoleSamples();
            if (roleRes.IsSuccess)
            {
                Roles = roleRes.Data!;
            }
            else
            {
                _notificationUIService.ShowError(roleRes.Message);
            }
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.UserApi.CreateUser(new()
            {
                UserName = this.UserName,
                PhoneNum = this.PhoneNum,
                Password = this.Password,
                OrgId = this.OrgId ?? 1,
                RoleId = this.RoleId ?? 1
            }), head: "用户");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.UserApi.ModifyUser(new()
            {
                Id = Id.Value,
                PhoneNum = this.PhoneNum,
                Password = this.Password,
                OrgId = this.OrgId ?? 1,
                RoleId = this.RoleId ?? 1
            }), head: "用户");
        }

        protected override void Clear()
        {
            UserName = string.Empty;
            PhoneNum = string.Empty;
            CreateAt = null;
            RoleId = null;
            OrgId = null;
            Password = string.Empty;
        }
    }

    public class FormUserViewModelValidator : AbstractValidator<FormUserViewModel>
    {
        public FormUserViewModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("用户名不能为空")
                .Length(4, 20)
                .WithMessage("用户名长度必须在4到20个字符之间");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("密码不能为空")
                .Length(6, 20)
                .WithMessage("密码长度必须在6到20个字符之间")
                .When(x => x.State == FormState.Create || !string.IsNullOrEmpty(x.Password));
            RuleFor(x => x.OrgId)
                .NotEmpty()
                .WithMessage("组织不能为空");
            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("角色不能为空");
        }
    }
}
