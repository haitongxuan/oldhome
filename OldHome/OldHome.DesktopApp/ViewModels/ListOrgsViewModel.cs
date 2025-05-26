using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.Messages;
using OldHome.DesktopApp.Services;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DesktopApp.ViewModels;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _api.DeleteOrg(SelectedItem.Id);
        };

        protected override Func<Task<BaseResponse<List<OrgDto>>>> GetAllFunc => _api.GetAllOrgs;
    }
}
