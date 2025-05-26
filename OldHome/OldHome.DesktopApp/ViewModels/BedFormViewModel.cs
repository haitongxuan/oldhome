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
    public class BedFormViewModel : BaseOrgByFormViewModel<BedDto, BedFormViewModel>
    {
        #region Properties
        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<RoomSample> Rooms { get; set; } = new ObservableCollection<RoomSample>();
        public ObservableCollection<BedStatus> BedStatuses { get; set; } = new ObservableCollection<BedStatus>();

        private string _bedNum;
        public string BedNum
        {
            get { return _bedNum; }
            set
            {
                SetProperty(ref _bedNum, value);
                ValidateProperty(nameof(BedNum));
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
            }
        }



        private int? _selectedRoomId;
        public int? SelectedRoomId
        {
            get { return _selectedRoomId; }
            set
            {
                SetProperty(ref _selectedRoomId, value);
                ValidateProperty(nameof(SelectedRoomId));
            }
        }

        private BedStatus? _selectedBedStatus;
        public BedStatus? SelectedBedStatus
        {
            get { return _selectedBedStatus; }
            set
            {
                SetProperty(ref _selectedBedStatus, value);
                if (value is not null)
                {
                    if (value.Value == BedStatus.Occupied || value.Value == BedStatus.Maintenance || value.Value == BedStatus.Frozen)
                        Available = false;
                    else
                        Available = true;
                }
                else
                {
                    Available = false;
                }
                ValidateProperty(nameof(SelectedBedStatus));
            }
        }

        private bool _available;
        public bool Available
        {
            get { return _available; }
            set { SetProperty(ref _available, value); }
        }

        private string _statusNotes;
        public string StatusNotes
        {
            get { return _statusNotes; }
            set { SetProperty(ref _statusNotes, value); }
        }
        #endregion

        public BedFormViewModel(IValidator<BedFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            Samples.LoadOrgAreas(AllOrgAreas, _api);
            BedStatuses.Clear();
            foreach (BedStatus item in Enum.GetValues(typeof(BedStatus)))
            {
                BedStatuses.Add(item);
            }
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            BedNum = string.Empty;
            SelectedOrgAreaId = null;
            SelectedFloor = null;
            SelectedRoomId = null;
            SelectedBedStatus = null;
            StatusNotes = string.Empty;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.CreateBed(new BedCreate
            {
                BedNum = BedNum,
                OrgAreaId = SelectedOrgAreaId.Value,
                Floor = SelectedFloor.Value,
                RoomId = SelectedRoomId.Value,
                Status = SelectedBedStatus.Value,
                StatusNotes = StatusNotes,
                Available = Available
            }), head: "床位");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyBed(new BedModify
            {
                Id = Id.Value,
                BedNum = BedNum,
                OrgAreaId = SelectedOrgAreaId.Value,
                Floor = SelectedFloor.Value,
                RoomId = SelectedRoomId.Value,
                Status = SelectedBedStatus.Value,
                StatusNotes = StatusNotes,
                Available = Available
            }), head: "床位");
        }

        public override async Task ChangeState(BedDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                BedNum = detail.BedNum;
                SelectedOrgAreaId = detail.OrgAreaId;
                SelectedFloor = detail.Floor;
                SelectedRoomId = detail.RoomId;
                SelectedBedStatus = detail.Status;
                StatusNotes = detail.StatusNotes;
                Available = detail.Available;
            }
            else
            {
                Id = null;
                BedNum = string.Empty;
                SelectedOrgAreaId = null;
                SelectedFloor = null;
                SelectedRoomId = null;
                SelectedBedStatus = null;
                StatusNotes = string.Empty;
            }
        }
    }
}
