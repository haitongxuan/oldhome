using AutoCompleteTextBox.Editors;
using OldHome.DesktopApp.Messages;
using OldHome.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Providers
{
    public class MedicineProvider : BindableBase, ISuggestionProvider
    {
        private readonly WebApi _api;
        public MedicineProvider()
        {
            _api = ContainerLocator.Container.Resolve<WebApi>();
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
                    var resp = await _api.GetTop10MedicineSamples();
                    return resp.Data;
                }
            }
            else
            {
                var r = await _api.GetAllMedicineSamples(filter, filter);
                return r.Data;
            }
        }

        public async Task<IEnumerable> GetFullCollection()
        {
            var r = await _api.GetAllMedicineSamples();
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
