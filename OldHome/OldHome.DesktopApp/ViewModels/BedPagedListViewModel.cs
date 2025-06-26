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
    [Navigation("SettingBeds", "SettingBeds", "床位管理", "人员物料", Order = 5, Icon = "e93b")]
    public class BedPagedListViewModel : BaseOrgByPagedListViewModel<BedDto, BedFormViewModel>
    {
        #region Properties
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
            set { SetProperty(ref _queryRoomId, value); }
        }

        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();
        public ObservableCollection<RoomSample> Rooms { get; set; } = new ObservableCollection<RoomSample>();


        #endregion

        public BedPagedListViewModel(BedFormViewModel formViewModel) : base(formViewModel)
        {
        }

        public override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();
            Samples.LoadOrgAreas(AllOrgAreas, _api);
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<BedDto>>>> GetPagedFunc => async (pi, pz) =>
        {
            var resp = await _api.BedApi.GetPagedBeds(pi, pz, QueryOrgAreaId, QueryFloor, QueryRoomId);
            return resp;
        };

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.BedApi.DeleteBed(SelectedItem.Id);
    }
}
