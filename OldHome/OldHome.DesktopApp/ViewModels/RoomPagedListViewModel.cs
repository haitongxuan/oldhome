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
    [Navigation("SettingRooms", "SettingRooms", "房间管理", "人员物料", Order = 3, Icon = "e93b")]
    public class RoomPagedListViewModel : BaseOrgByPagedListViewModel<RoomDto, RoomFormViewModel>
    {
        private int? _queryOrgAreaId;
        public int? QueryOrgAreaId
        {
            get { return _queryOrgAreaId; }
            set
            {
                SetProperty(ref _queryOrgAreaId, value);
                ChangeAllFloors();
            }
        }

        private int? _queryFloor;
        public int? QueryFloor
        {
            get { return _queryFloor; }
            set { SetProperty(ref _queryFloor, value); }
        }

        public ObservableCollection<OrgAreaSample> AllOrgAreas { get; set; } = new ObservableCollection<OrgAreaSample>();
        public ObservableCollection<int> AllFloors { get; set; } = new ObservableCollection<int>();

        private void ChangeAllFloors()
        {
            AllFloors.Clear();
            if (QueryOrgAreaId == null)
                return;
            var orgArea = AllOrgAreas.FirstOrDefault(x => x.Id == QueryOrgAreaId);
            if (orgArea != null)
            {
                for (int i = orgArea.FloorMin; i <= orgArea.FloorMax; i++)
                {
                    AllFloors.Add(i);
                }
            }
        }

        public RoomPagedListViewModel(RoomFormViewModel formViewModel) : base(formViewModel)
        {
        }

        public override async Task LoadDataAsync()
        {
            await base.LoadDataAsync();
            var resp = await _api.OrgAreaApi.GetAllOrgAreaSamples();
            if (resp.IsSuccess)
            {
                AllOrgAreas.Clear();
                foreach (var item in resp.Data)
                {
                    AllOrgAreas.Add(item);
                }
            }
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<RoomDto>>>> GetPagedFunc => async (pi, pz) =>
        {
            return await _api.RoomApi.GetPagedRooms(pi, pz, this.QueryOrgAreaId, this.QueryFloor);
        };

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.RoomApi.DeleteRoom(SelectedItem.Id);
    }
}
