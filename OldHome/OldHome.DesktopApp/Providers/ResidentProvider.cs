using AutoCompleteTextBox.Editors;
using OldHome.API;
using System.Collections;

namespace OldHome.DesktopApp.Providers
{
    public class ResidentProvider : BindableBase, ISuggestionProvider
    {
        private readonly ApiManager _api;
        public ResidentProvider()
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
                    var resp = await _api.ResidentApi.GetAllResidentSamples();
                    return resp.Data;
                }
            }
            else
            {
                var r = await _api.ResidentApi.GetAllResidentSamples(name: filter, code: filter);
                return r.Data;
            }
        }
    }
}
