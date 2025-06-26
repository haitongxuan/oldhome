using OldHome.Core;
using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingResidents", "SettingResidents", "长者资料", "人员信息", Order = 7, Icon = "e93b")]
    public class ResidentPagedListViewModel : BaseOrgByPagedListViewModel<ResidentDto, ResidentFormViewModel>
    {
        private string _queryName;
        public string QueryName
        {
            get { return _queryName; }
            set { SetProperty(ref _queryName, value); }
        }

        private int? _queryOrgAreaId;
        public int? QueryOrgAreaId
        {
            get { return _queryOrgAreaId; }
            set
            {
                if (SetProperty(ref _queryOrgAreaId, value))
                {
                    Samples.LoadFloors(AllFloors, value, AllOrgAreas);
                }
            }
        }

        private int? _queryFloor;
        public int? QueryFloor
        {
            get { return _queryFloor; }
            set
            {
                if (SetProperty(ref _queryFloor, value))
                    Samples.LoadRooms(Rooms, QueryOrgAreaId, value, _api);
            }
        }

        private int? _queryRoomId;
        public int? QueryRoomId
        {
            get { return _queryRoomId; }
            set
            {
                if (SetProperty(ref _queryRoomId, value))
                    Samples.LoadBeds(Beds, value, _api);
            }
        }

        private int? _queryBedId;
        public int? QueryBedId
        {
            get { return _queryBedId; }
            set { SetProperty(ref _queryBedId, value); }
        }

        private HealthStatus _healthStatus;
        public HealthStatus HealthStatus
        {
            get { return _healthStatus; }
            set { SetProperty(ref _healthStatus, value); }
        }

        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<RoomSample> Rooms { get; set; } = new ObservableCollection<RoomSample>();
        public ObservableCollection<BedSample> Beds { get; set; } = new ObservableCollection<BedSample>();
        public ObservableCollection<HealthStatus> AllHealthStatuses { get; set; } = new ObservableCollection<HealthStatus>();

        public ResidentPagedListViewModel(ResidentFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<ResidentDto>>>> GetPagedFunc =>
            async (pi, pz) => await _api.ResidentApi.GetPagedResidents(pi, pz, QueryName, QueryOrgAreaId, QueryFloor, QueryRoomId, QueryBedId);

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.ResidentApi.DeleteResident(SelectedItem.Id);

        public override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();
            Samples.LoadOrgAreas(AllOrgAreas, _api);
            Samples.LoadHealthStatuses(AllHealthStatuses);
        }
    }
}
