using FluentValidation;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class FormOrgViewModel : BaseFormViewModel<OrgDto, FormOrgViewModel>
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                ValidateProperty(nameof(Name));
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }

        private string _phoneNum;
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { SetProperty(ref _phoneNum, value); }
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { SetProperty(ref _createAt, value); }
        }

        private bool _isHead;
        public bool IsHead
        {
            get { return _isHead; }
            set { SetProperty(ref _isHead, value); }
        }

        private List<OrgAreaDto> _orgAreas = new List<OrgAreaDto>();
        public List<OrgAreaDto> OrgAreas
        {
            get { return _orgAreas; }
            set { SetProperty(ref _orgAreas, value); }
        }
        #endregion

        public FormOrgViewModel(IValidator<FormOrgViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            if (Id != null)
            {
                var response = await _api.GetOrgAreas(Id!.Value);
                if (response.IsSuccess)
                {
                    OrgAreas = response.Data;
                }
            }
        }

        protected override void Clear()
        {
            Name = string.Empty;
            PhoneNum = string.Empty;
            CreateAt = null;
            Address = string.Empty;
            IsHead = false;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.CreateOrg(new OrgCreate
            {
                Name = Name,
                Address = Address,
                PhoneNum = PhoneNum
            }), head: "机构");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyOrg(new()
            {
                Id = Id.Value,
                PhoneNum = PhoneNum,
                Address = Address,
                Name = Name,
            }), head: "机构");
        }

        public override async Task ChangeState(OrgDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                Address = detail.Address;
                PhoneNum = detail.PhoneNum;
                IsHead = detail.IsHead;
                CreateAt = detail.CreatedAt;
            }
            else
            {
                Id = null;
                Name = string.Empty;
                Address = string.Empty;
                IsHead = false;
                PhoneNum = string.Empty;
                CreateAt = null;
            }
            if (Id is not null)
                await LoadDataAsync();
        }
    }

    public class FormOrgViewModelValidator : AbstractValidator<FormOrgViewModel>
    {
        public FormOrgViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("机构名称不能为空");
        }
    }
}
