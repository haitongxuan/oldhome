using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class ResidentFormViewModel : BaseOrgByFormViewModel<ResidentDto, ResidentFormViewModel>
    {
        #region Properties
        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<RoomSample> Rooms { get; set; } = new ObservableCollection<RoomSample>();
        public ObservableCollection<BedSample> Beds { get; set; } = new ObservableCollection<BedSample>();
        public ObservableCollection<Gender> AllGenders { get; set; } = new ObservableCollection<Gender>();
        public ObservableCollection<HealthStatus> AllHealthStatuses { get; set; } = new ObservableCollection<HealthStatus>();

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


        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                SetProperty(ref _birthDate, value);
                ValidateProperty(nameof(BirthDate));
            }
        }

        private string _idCardNumber;
        public string IdCardNumber
        {
            get { return _idCardNumber; }
            set
            {
                SetProperty(ref _idCardNumber, value);
                ValidateProperty(nameof(IdCardNumber));
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

        private DateTime _admissionDate;
        public DateTime AdmissionDate
        {
            get { return _admissionDate; }
            set
            {
                SetProperty(ref _admissionDate, value);
                ValidateProperty(nameof(AdmissionDate));
            }
        }

        private int? _selectedOrgAreaId;
        public int? SelectedOrgAreaId
        {
            get { return _selectedOrgAreaId; }
            set
            {
                SetProperty(ref _selectedOrgAreaId, value);
                Samples.LoadFloors(AllFloors, value, AllOrgAreas);
                ValidateProperty(nameof(SelectedOrgAreaId));
            }
        }

        private int? _selectedFloor;
        public int? SelectedFloor
        {
            get { return _selectedFloor; }
            set
            {
                SetProperty(ref _selectedFloor, value);
                Samples.LoadRooms(Rooms, SelectedOrgAreaId, value, _api);
                ValidateProperty(nameof(SelectedFloor));
            }
        }

        private int? _selectedRoomId;
        public int? SelectedRoomId
        {
            get { return _selectedRoomId; }
            set
            {
                SetProperty(ref _selectedRoomId, value);
                Samples.LoadBeds(Beds, value, _api);
                ValidateProperty(nameof(SelectedRoomId));
            }
        }

        private int? _selectedBedId;
        public int? SelectedBedId
        {
            get { return _selectedBedId; }
            set
            {
                SetProperty(ref _selectedBedId, value);
                ValidateProperty(nameof(SelectedBedId));
            }
        }

        private HealthStatus? _healthStatus;
        public HealthStatus? HealthStatus
        {
            get { return _healthStatus; }
            set
            {
                SetProperty(ref _healthStatus, value);
                ValidateProperty(nameof(HealthStatus));
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                SetProperty(ref _notes, value);
                ValidateProperty(nameof(Notes));
            }
        }
        #endregion

        public ResidentFormViewModel(IValidator<ResidentFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            Samples.LoadOrgAreas(AllOrgAreas, _api);
            Samples.LoadGenders(AllGenders);
            Samples.LoadHealthStatuses(AllHealthStatuses);
            await Task.CompletedTask;
        }

        public override async Task ChangeState(ResidentDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                SelectedGender = detail.Gender;
                BirthDate = detail.BirthDate.ToDateTime(TimeOnly.MinValue);
                IdCardNumber = detail.IdCardNumber;
                PhoneNumber = detail.PhoneNumber;
                Address = detail.Address;
                AdmissionDate = detail.AdmissionDate.ToDateTime(TimeOnly.MinValue);
                SelectedOrgAreaId = detail.OrgAreaId;
                SelectedFloor = detail.Floor;
                SelectedRoomId = detail.RoomId;
                SelectedBedId = detail.BedId;
                HealthStatus = detail.HealthStatus;
                Notes = detail.HealthDescription;
            }
            else
            {
                Clear();
            }
        }

        protected override void Clear()
        {
            Name = string.Empty;
            SelectedGender = null;
            BirthDate = DateTime.Now;
            IdCardNumber = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            AdmissionDate = DateTime.Now;
            SelectedOrgAreaId = null;
            SelectedFloor = null;
            SelectedRoomId = null;
            SelectedBedId = null;
            HealthStatus = null;
            Notes = string.Empty;

            AllFloors.Clear();
            Rooms.Clear();
            Beds.Clear();
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ResidentApi.CreateResident(new ResidentCreate
            {
                Name = Name,
                Gender = SelectedGender.Value,
                BirthDate = DateOnly.FromDateTime(BirthDate),
                IdCardNumber = IdCardNumber,
                PhoneNumber = PhoneNumber,
                Address = Address,
                AdmissionDate = DateOnly.FromDateTime(AdmissionDate),
                OrgAreaId = SelectedOrgAreaId.Value,
                Floor = SelectedFloor.Value,
                RoomId = SelectedRoomId.Value,
                BedId = SelectedBedId.Value,
                HealthStatus = HealthStatus.Value,
                HealthDescription = Notes,
                ImagePath = string.Empty,
            }), head: "长者资料");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ResidentApi.ModifyResident(new ResidentModify
            {
                Id = Id.Value,
                Name = Name,
                Gender = SelectedGender.Value,
                BirthDate = DateOnly.FromDateTime(BirthDate),
                IdCardNumber = IdCardNumber,
                PhoneNumber = PhoneNumber,
                Address = Address,
                AdmissionDate = DateOnly.FromDateTime(AdmissionDate),
                OrgAreaId = SelectedOrgAreaId.Value,
                Floor = SelectedFloor.Value,
                RoomId = SelectedRoomId.Value,
                BedId = SelectedBedId.Value,
                HealthStatus = HealthStatus.Value,
                HealthDescription = Notes,
            }), head: "长者资料");
        }
    }
}
