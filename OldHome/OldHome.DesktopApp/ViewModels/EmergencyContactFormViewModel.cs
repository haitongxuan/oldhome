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
    public class EmergencyContactFormViewModel : BaseFormViewModel<EmergencyContactDto, EmergencyContactFormViewModel>
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
        private string _phoneNum;
        public string PhoneNum
        {
            get { return _phoneNum; }
            set
            {
                SetProperty(ref _phoneNum, value);
                ValidateProperty(nameof(PhoneNum));
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                SetProperty(ref _address, value);
                ValidateProperty(nameof(Address));
            }
        }
        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { SetProperty(ref _createAt, value); }
        }
        #endregion

        public EmergencyContactFormViewModel(IValidator<EmergencyContactFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            Name = string.Empty;
            PhoneNum = string.Empty;
            Address = string.Empty;
            CreateAt = null;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.EmergencyContactApi.CreateEmergencyContact(new EmergencyContactCreate
            {
                Name = this.Name,
                PhoneNum = this.PhoneNum,
                Address = this.Address
            }), head: "联系人");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.EmergencyContactApi.ModifyEmergencyContact(new EmergencyContactModify
            {
                Id = this.Id!.Value,
                Name = this.Name,
                PhoneNum = this.PhoneNum,
                Address = this.Address,
            }), head: "联系人");
        }

        public override async Task ChangeState(EmergencyContactDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                PhoneNum = detail.PhoneNum;
                Address = detail.Address;
                CreateAt = detail.CreateAt;
            }
            else
            {
                Clear();
            }
        }
    }
}
