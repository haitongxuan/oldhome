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
    [Navigation("SettingOrgAreas", "SettingOrgAreas", "机构区域管理", "组织架构", Icon = "e941", Order = 5)]
    public class OrgAreaListViewModel : BaseOrgByListViewModel<OrgAreaDto, OrgAreaFormViewModel>
    {
        private List<OrgSample> _orgs;
        public List<OrgSample> Orgs
        {
            get { return _orgs; }
            set { SetProperty(ref _orgs, value); }
        }

        private int? _selectedOrgId;
        public int? SelectedOrgId
        {
            get { return _selectedOrgId; }
            set { SetProperty(ref _selectedOrgId, value); }
        }

        public override async Task LoadDataAsync()
        {
            var response = await _api.OrgApi.GetAllOrgSamples();
            if (response.IsSuccess)
            {
                Orgs = response.Data;
            }
            await base.LoadDataAsync();
        }

        public OrgAreaListViewModel(OrgAreaFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<Task<BaseResponse<List<OrgAreaDto>>>> GetAllFunc => _api.OrgAreaApi.GetAllOrgAreas;

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => { return await _api.OrgAreaApi.DeleteOrgArea(SelectedItem.Id); };


        private AsyncDelegateCommand _query;
        public AsyncDelegateCommand QueryCommand =>
            _query ?? (_query = new AsyncDelegateCommand(ExecuteQueryCommand));

        async Task ExecuteQueryCommand()
        {
            if (SelectedOrgId is not null)
            {
                var resp = await _api.OrgApi.GetOrgAreas(SelectedOrgId.Value);
                if (resp.IsSuccess)
                {
                    Items = resp.Data;
                }
            }
        }
    }
}
