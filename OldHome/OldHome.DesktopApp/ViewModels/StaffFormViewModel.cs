using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.Utils;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class StaffFormViewModel : BaseOrgByFormViewModel<StaffDto, StaffFormViewModel>
    {
        #region Properties
        public ObservableCollection<Gender> AllGenders { get; set; } = new ObservableCollection<Gender>();
        public ObservableCollection<StaffPosition> AllPositions { get; set; } = new ObservableCollection<StaffPosition>();
        public ObservableCollection<DepartmentSample> AllDepartments { get; set; } = new ObservableCollection<DepartmentSample>();

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

        private Gender? _selectedGender;
        public Gender? SelectedGender
        {
            get { return _selectedGender; }
            set
            {
                SetProperty(ref _selectedGender, value);
                ValidateProperty(nameof(SelectedGender));
            }
        }

        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set
            {
                SetProperty(ref _birthDate, value);
                ValidateProperty(nameof(BirthDate));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                SetProperty(ref _phoneNumber, value);
                ValidateProperty(nameof(PhoneNumber));
            }
        }


        private StaffPosition? _selectedPosition;
        public StaffPosition? SelectedPosition
        {
            get { return _selectedPosition; }
            set
            {
                SetProperty(ref _selectedPosition, value);
                ValidateProperty(nameof(SelectedPosition));
            }
        }
        private DateTime? _hireDate;
        public DateTime? HireDate
        {
            get { return _hireDate; }
            set
            {
                SetProperty(ref _hireDate, value);
                ValidateProperty(nameof(HireDate));
            }
        }

        private int? _selectedDepartmentId;
        public int? SelectedDepartmentId
        {
            get { return _selectedDepartmentId; }
            set
            {
                SetProperty(ref _selectedDepartmentId, value);
                ValidateProperty(nameof(SelectedDepartmentId));
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }
        #endregion

        public StaffFormViewModel(IValidator<StaffFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            AllGenders.Clear();
            AllPositions.Clear();
            AllDepartments.Clear();
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                AllGenders.Add(gender);
            }

            foreach (StaffPosition position in Enum.GetValues(typeof(StaffPosition)))
            {
                AllPositions.Add(position);
            }
            var response = await _api.GetAllDepartmentSamples();
            if (response.IsSuccess && response.Data is not null)
            {
                foreach (var department in response.Data)
                {
                    AllDepartments.Add(department);
                }
            }
        }

        protected override void Clear()
        {
            Name = string.Empty;
            SelectedGender = null;
            BirthDate = null;
            PhoneNumber = string.Empty;
            SelectedPosition = null;
            HireDate = null;
            SelectedDepartmentId = null;
            Notes = string.Empty;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.CreateStaff(new()
            {
                Name = Name,
                Gender = SelectedGender!.Value,
                BirthDate = DateOnly.FromDateTime(BirthDate!.Value),
                PhoneNumber = PhoneNumber,
                Position = SelectedPosition!.Value,
                HireDate = DateOnly.FromDateTime(HireDate!.Value),
                DepartmentId = SelectedDepartmentId!.Value,
                Notes = Notes
            }), head: "员工");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyStaff(new()
            {
                Id = Id!.Value,
                Name = Name,
                Gender = SelectedGender!.Value,
                BirthDate = DateOnly.FromDateTime(BirthDate!.Value),
                PhoneNumber = PhoneNumber,
                Position = SelectedPosition!.Value,
                HireDate = DateOnly.FromDateTime(HireDate!.Value),
                DepartmentId = SelectedDepartmentId!.Value,
                Notes = Notes
            }), head: "员工");
        }

        public override async Task ChangeState(StaffDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                SelectedGender = detail.Gender;
                BirthDate = detail.BirthDate.ToDateTime(TimeOnly.MinValue);
                PhoneNumber = detail.PhoneNumber;
                SelectedPosition = detail.Position;
                HireDate = detail.HireDate.ToDateTime(TimeOnly.MinValue);
                SelectedDepartmentId = detail.DepartmentId;
                Notes = detail.Notes;
                CreatedAt = detail.CreatedAt;
            }
            else
            {
                Clear();
            }
        }
    }
}
