using System;
using System.Collections;
using System.Threading.Tasks;

namespace AutoCompleteTextBox.Editors
{
    public class SuggestionProvider : ISuggestionProvider
    {


        #region Private Fields

        private readonly Func<string, Task<IEnumerable>> _method;

        #endregion Private Fields

        #region Public Constructors

        public SuggestionProvider(Func<string, Task<IEnumerable>> method)
        {
            _method = method ?? throw new ArgumentNullException(nameof(method));
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IEnumerable> GetSuggestions(string filter)
        {
            return await _method(filter);
        }

        #endregion Public Methods

    }
}