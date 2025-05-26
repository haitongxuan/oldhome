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
    [Navigation("SettingRoles", "SettingRoles", "权限管理", "组织架构", Icon = "e9d1", Order = 2)]
    public class ListRolesViewModel : BaseListViewModel<RoleDto, FormRoleViewModel>
    {
        public ListRolesViewModel(FormRoleViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<Task<BaseResponse<List<RoleDto>>>> GetAllFunc => _api.GetAllRoles;

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.DeleteRole(SelectedItem.Id);
    }
}
