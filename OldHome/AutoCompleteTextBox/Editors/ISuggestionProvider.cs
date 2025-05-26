using System.Collections;
using System.Threading.Tasks;

namespace AutoCompleteTextBox.Editors
{
    public interface ISuggestionProvider
    {

        #region Public Methods

        Task<IEnumerable> GetSuggestions(string filter);

        #endregion Public Methods

    }
}
