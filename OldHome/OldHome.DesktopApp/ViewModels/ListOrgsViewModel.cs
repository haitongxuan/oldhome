using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingOrgs", "SettingOrgs", "机构管理", "组织架构", Icon = "e941", Order = 1)]
    public class ListOrgsViewModel : BaseListViewModel<OrgDto, FormOrgViewModel>
    {
        public ListOrgsViewModel(FormOrgViewModel formViewModel) : base(formViewModel)
        {
        }


        protected override Func<Task<BaseResponse>> DeleteFunc => async () =>
        {
            return await _api.OrgApi.DeleteOrg(SelectedItem.Id);
        };

        protected override Func<Task<BaseResponse<List<OrgDto>>>> GetAllFunc => _api.OrgApi.GetAllOrgs;
    }
}
