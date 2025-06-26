using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingUsers", "SettingUsers", "用户管理", "组织架构", IsDefault = true, Icon = "e93b")]
    public class PagedListUsersViewModel : BaseOrgByPagedListViewModel<UserDto, FormUserViewModel>
    {
        public PagedListUsersViewModel(FormUserViewModel formUserViewModel) : base(formUserViewModel)
        {
        }
        protected override Func<int, int, Task<BaseResponse<PagedResult<UserDto>>>> GetPagedFunc => _api.UserApi.GetPagedUsers;

        protected override Func<Task<BaseResponse>> DeleteFunc => async () =>
        {
            return await _api.UserApi.DeleteUser(SelectedItem.Id);
        };
    }

}
