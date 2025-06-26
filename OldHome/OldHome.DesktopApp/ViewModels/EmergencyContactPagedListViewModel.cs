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
    [Navigation("SettingEmergencyContacts", "SettingEmergencyContacts", "监护联系人", "人员信息", Icon = "e93b")]
    public class EmergencyContactPagedListViewModel : BaseOrgByPagedListViewModel<EmergencyContactDto, EmergencyContactFormViewModel>
    {
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

        public EmergencyContactPagedListViewModel(EmergencyContactFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<EmergencyContactDto>>>> GetPagedFunc => async (pi, pz) =>
        {
            return await _api.EmergencyContactApi.GetPagedEmergencyContacts(pi, pz, this.QueryName, this.QueryPhoneNum);
        };


        protected override Func<Task<BaseResponse>> DeleteFunc => async () => { return await _api.EmergencyContactApi.DeleteEmergencyContact(SelectedItem.Id); };
    }
}
