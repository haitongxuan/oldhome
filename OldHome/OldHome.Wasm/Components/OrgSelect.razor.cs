using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using OldHome.API;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OldHome.Wasm.Components
{
    public partial class OrgSelect
    {
        private List<OrgSample> _orgs;
        private int? _selectedOrgId;

        [Inject] ApiManager ApiManager { get; set; }

        [Parameter] public int? SelectedOrgId { get; set; }
        [Parameter] public EventCallback<int?> SelectedOrgIdChanged { get; set; }

        private async Task OnSelectedOrgChanged(int? newOrgId)
        {
            _selectedOrgId = newOrgId;

            // 触发 SelectedOrgId 的双向绑定
            if (SelectedOrgIdChanged.HasDelegate && newOrgId != null)
            {
                await SelectedOrgIdChanged.InvokeAsync(newOrgId);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                var api = ApiManager.OrgApi;
                var res = await api.GetAllOrgSamples();
                if (res.IsSuccess)
                {
                    _orgs = res.Data;
                }
                else
                {
                    // Handle error, e.g., show a notification
                    Console.WriteLine($"Error fetching organizations: {res.Message}");
                }
                await base.OnInitializedAsync();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }

        }
    }
}
