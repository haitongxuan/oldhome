using AutoCompleteTextBox.Editors;
using OldHome.DesktopApp.Messages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.Providers
{
    public class ResidentProvider : BindableBase, ISuggestionProvider
    {
        private readonly WebApi _api;
        public ResidentProvider()
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
                    var resp = await _api.GetAllResidentSamples();
                    return resp.Data;
                }
            }
            else
            {
                var r = await _api.GetAllResidentSamples(name: filter, code: filter);
                return r.Data;
            }
        }
    }
}
