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
    [Navigation("SettingStaffs", "SettingStaffs", "雇员", "人员物料", IsDefault = false, Icon = "e93b")]
    public class StaffPagedListViewModel : BaseOrgByPagedListViewModel<StaffDto, StaffFormViewModel>
    {
        public ObservableCollection<DepartmentSample> AllDepartments { get; set; } = new ObservableCollection<DepartmentSample>();

        private int? _selectedDepartmentId;
        public int? SelectedDepartmentId
        {
            get { return _selectedDepartmentId; }
            set { SetProperty(ref _selectedDepartmentId, value); }
        }

        private string _queryName;
        public string QueryName
        {
            get { return _queryName; }
            set { SetProperty(ref _queryName, value); }
        }

        private string _queryPhoneNum;
        public string QueryPhoneNum
        {
            get { return _queryPhoneNum; }
            set { SetProperty(ref _queryPhoneNum, value); }
        }

        public StaffPagedListViewModel(StaffFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<StaffDto>>>> GetPagedFunc => async (pi, pz) =>
        {
            var resp = await _api.GetPagedStaffs(pi, pz, this.QueryName, this.QueryPhoneNum);
            return resp;
        };

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => { return await _api.DeleteStaff(SelectedItem.Id); };
    }
}
