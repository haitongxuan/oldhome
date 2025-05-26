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
    public class OrgAreaFormViewModel : BaseOrgByFormViewModel<OrgAreaDto, OrgAreaFormViewModel>
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int? _selectedOrgId;
        public int? SelectedOrgId
        {
            get { return _selectedOrgId; }
            set
            {
                SetProperty(ref _selectedOrgId, value);
                ValidateProperty(nameof(SelectedOrgId));
            }
        }

        private int _floorMax;
        public int FloorMax
        {
            get { return _floorMax; }
            set
            {
                SetProperty(ref _floorMax, value);
                ValidateProperty(nameof(FloorMax));
            }
        }

        private int _floorMin;
        public int FloorMin
        {
            get { return _floorMin; }
            set
            {
                SetProperty(ref _floorMin, value);
                ValidateProperty(nameof(FloorMin));
            }
        }

        private List<OrgSample> _orgs = new List<OrgSample>();
        public List<OrgSample> Orgs
        {
            get { return _orgs; }
            set { SetProperty(ref _orgs, value); }
        }

        #endregion

        public OrgAreaFormViewModel(IValidator<OrgAreaFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            var res = await _api.GetAllOrgSamples();
            if (res.IsSuccess)
            {
                Orgs = res.Data!;
            }
            else
            {
                _notificationUIService.ShowError(res.Message);
            }
        }

        protected override void Clear()
        {
            Name = string.Empty;
            Description = string.Empty;
            SelectedOrgId = null;
            FloorMin = 1;
            FloorMax = 1;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.CreateOrgArea(new()
            {
                Name = Name,
                Description = Description,
                OrgId = SelectedOrgId!.Value,
                FloorMax = FloorMax,
                FloorMin = FloorMin
            }), head: "区域");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyOrgArea(new()
            {
                Id = Id!.Value,
                Name = Name,
                Description = Description,
                OrgId = SelectedOrgId!.Value,
                FloorMax = FloorMax,
                FloorMin = FloorMin
            }), head: "区域");
        }

        public override async Task ChangeState(OrgAreaDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                Description = detail.Description;
                SelectedOrgId = detail.OrgId;
                FloorMin = detail.FloorMin;
                FloorMax = detail.FloorMax;
            }
            else
            {
                Id = null;
                Name = string.Empty;
                Description = string.Empty;
                SelectedOrgId = null;
                FloorMin = 1;
                FloorMax = 1;
            }
        }
    }
}
