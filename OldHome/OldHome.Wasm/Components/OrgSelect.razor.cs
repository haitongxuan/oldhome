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
        private OrgSample _selectedOrg;
        [Inject] ApiManager ApiManager { get; set; }


        protected override void OnInitialized()
        {
            ApiManager.OrgApi.GetAllOrgSamples()
                .ContinueWith(t =>
                {
                    if (t.IsCompletedSuccessfully)
                    {
                        _orgs = t.Result.Data!;
                        StateHasChanged();
                    }
                    else
                    {
                        Console.WriteLine("Failed to load organizations: " + t.Exception?.Message);
                    }
                });
        }
    }
}
