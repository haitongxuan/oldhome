using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.Messages;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DesktopApp.ViewModels;
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
    [Navigation("SettingUsers", "SettingUsers", "用户管理", "组织架构", IsDefault = true, Icon = "e93b")]
    public class PagedListUsersViewModel : BaseOrgByPagedListViewModel<UserDto, FormUserViewModel>
    {
        public PagedListUsersViewModel(FormUserViewModel formUserViewModel) : base(formUserViewModel)
        {
        }
        protected override Func<int, int, Task<BaseResponse<PagedResult<UserDto>>>> GetPagedFunc => _api.GetPagedUsers;

        protected override Func<Task<BaseResponse>> DeleteFunc => async () =>
        {
            return await _api.DeleteUser(SelectedItem.Id);
        };
    }

}
