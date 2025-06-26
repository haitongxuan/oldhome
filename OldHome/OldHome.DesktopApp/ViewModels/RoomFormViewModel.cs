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
    public class RoomFormViewModel : BaseOrgByFormViewModel<RoomDto, RoomFormViewModel>
    {
        #region Properties
        public ObservableCollection<RoomType> AllRoomTypes { get; set; } = new ObservableCollection<RoomType>();
        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();

        private RoomType? _selectedRoomType;
        public RoomType? SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                SetProperty(ref _selectedRoomType, value);
                ValidateProperty(nameof(SelectedRoomType));
            }
        }

        private int? _selectedOrgAreaId;
        public int? SelectedOrgAreaId
        {
            get { return _selectedOrgAreaId; }
            set
            {
                SetProperty(ref _selectedOrgAreaId, value);
                ValidateProperty(nameof(SelectedOrgAreaId));
                ChangeAllFloors();
            }
        }

        private int? _selectedFloor;
        public int? SelectedFloor
        {
            get { return _selectedFloor; }
            set
            {
                SetProperty(ref _selectedFloor, value);
                ValidateProperty(nameof(SelectedFloor));
            }
        }

        private int? _bedCount;
        public int? BedCount
        {
            get { return _bedCount; }
            set
            {
                SetProperty(ref _bedCount, value);
                ValidateProperty(nameof(BedCount));
            }
        }

        private int? _freeBedCount;
        public int? FreeBedCount
        {
            get { return _freeBedCount; }
            set
            {
                SetProperty(ref _freeBedCount, value);
                ValidateProperty(nameof(FreeBedCount));
                if (FreeBedCount > 0)
                    IsFull = false;
                else
                    IsFull = true;
            }
        }

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

        private bool _isFull;
        public bool IsFull
        {
            get { return _isFull; }
            set { SetProperty(ref _isFull, value); }
        }
        #endregion

        public RoomFormViewModel(IValidator<RoomFormViewModel> validator) : base(validator)
        {
        }

        private void ChangeAllFloors()
        {
            AllFloors.Clear();
            if (SelectedOrgAreaId == null)
                return;
            var orgArea = AllOrgAreas.FirstOrDefault(x => x.Id == SelectedOrgAreaId);
            if (orgArea != null)
            {
                for (int i = orgArea.FloorMin; i <= orgArea.FloorMax; i++)
                {
                    AllFloors.Add(i);
                }
            }
        }

        public override async Task LoadDataAsync()
        {
            AllRoomTypes.Clear();
            AllOrgAreas.Clear();
            AllFloors.Clear();
            foreach (RoomType item in Enum.GetValues(typeof(RoomType)))
            {
                AllRoomTypes.Add(item);
            }
            var resp = await _api.OrgAreaApi.GetAllOrgAreaSamples();
            if (resp.IsSuccess && resp.Data is not null)
            {
                resp.Data.ForEach(AllOrgAreas.Add);
            }
        }

        protected override void Clear()
        {
            Name = string.Empty;
            Notes = string.Empty;
            SelectedOrgAreaId = null;
            SelectedRoomType = null;
            SelectedFloor = null;
            BedCount = null;
            FreeBedCount = null;
            IsFull = false;
        }

        public override async Task ChangeState(RoomDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.RoomNumber;
                Notes = detail.Notes;
                SelectedOrgAreaId = detail.OrgAreaId;
                SelectedRoomType = detail.RoomType;
                SelectedFloor = detail.Floor;
                BedCount = detail.BedCount;
                FreeBedCount = detail.FreeBedCount;
                IsFull = detail.IsFull;
            }
            else
            {
                Id = null;
                Name = string.Empty;
                Notes = string.Empty;
                SelectedOrgAreaId = null;
                SelectedRoomType = null;
                SelectedFloor = null;
                BedCount = null;
                FreeBedCount = null;
                IsFull = false;
            }
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.RoomApi.CreateRoom(new RoomCreate
            {
                RoomNumber = this.Name,
                RoomType = this.SelectedRoomType!.Value,
                OrgAreaId = this.SelectedOrgAreaId!.Value,
                Floor = this.SelectedFloor!.Value,
                BedCount = this.BedCount!.Value,
                FreeBedCount = this.FreeBedCount!.Value,
                IsFull = this.IsFull,
                Notes = this.Notes,
            }), head: "房间");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.RoomApi.ModifyRoom(new()
            {
                Id = this.Id!.Value,
                RoomNumber = this.Name,
                RoomType = this.SelectedRoomType!.Value,
                OrgAreaId = this.SelectedOrgAreaId!.Value,
                Floor = this.SelectedFloor!.Value,
                BedCount = this.BedCount!.Value,
                FreeBedCount = this.FreeBedCount!.Value,
                IsFull = this.IsFull,
                Notes = this.Notes,
            }), head: "房间");
        }
    }
}
