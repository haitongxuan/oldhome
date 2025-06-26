using AutoCompleteTextBox.Editors;
using OldHome.API;
using System.Collections;

namespace OldHome.DesktopApp.Providers
{
    public class MedicineProvider : BindableBase, ISuggestionProvider
    {
        private readonly ApiManager _api;
        public MedicineProvider()
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
                    var resp = await _api.MedicineApi.GetTop10MedicineSamples();
                    return resp.Data;
                }
            }
            else
            {
                var r = await _api.MedicineApi.GetAllMedicineSamples(filter, filter);
                return r.Data;
            }
        }

        public async Task<IEnumerable> GetFullCollection()
        {
            var r = await _api.MedicineApi.GetAllMedicineSamples();
            if (r.IsSuccess)
            {
                return r.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
