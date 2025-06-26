using OldHome.DesktopApp.Services;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseOrgByPagedListViewModel<T, F> : BasePagedListViewModel<T, F> where T : BaseOrgByDto where F : BaseFormViewModel<T, F>
    {
        public BaseOrgByPagedListViewModel(F formViewModel) : base(formViewModel)
        {
            _user.OrgChanged += OnCurrentOrgChanged;
        }
        private async void OnCurrentOrgChanged(object? sender, int orgId)
        {
            await LoadDataAsync();
        }
    }
}
