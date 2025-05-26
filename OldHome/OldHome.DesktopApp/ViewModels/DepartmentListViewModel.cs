using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingDepartments", "SettingDepartments", "部门管理", "组织架构", Icon = "e941", Order = 6)]
    public class DepartmentListViewModel : BaseOrgByListViewModel<DepartmentDto, DepartmentFormViewModel>
    {
        public DepartmentListViewModel(DepartmentFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<Task<BaseResponse<List<DepartmentDto>>>> GetAllFunc => _api.GetAllDepartments;

        protected override Func<Task<BaseResponse>> DeleteFunc => async () =>
        {
            return await _api.DeleteDepartment(SelectedItem.Id);
        };
    }
}
