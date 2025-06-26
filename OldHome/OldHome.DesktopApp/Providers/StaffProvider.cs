using AutoCompleteTextBox.Editors;
using OldHome.API;
using System.Collections;

namespace OldHome.DesktopApp.Providers
{
    public class StaffProvider : BindableBase, ISuggestionProvider
    {
        private readonly ApiManager _api;
        public StaffProvider()
        {
            _api = ContainerLocator.Container.Resolve<ApiManager>();
        }


        private bool _allowEmptyFilter;
        public bool AllowEmptyFilter
        {
            get { return _allowEmptyFilter; }
            set { SetProperty(ref _allowEmptyFilter, value); }
        }

        public async Task<IEnumerable> GetSuggestions(string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                if (!AllowEmptyFilter)
                    return null;
                else
                {
                    var resp = await _api.StaffApi.GetAllStaffSamples(filter);
                    return resp.Data;
                }
            }
            else
            {
                var r = await _api.StaffApi.GetAllStaffSamples(filter);
                return r.Data;
            }
        }
    }
}
