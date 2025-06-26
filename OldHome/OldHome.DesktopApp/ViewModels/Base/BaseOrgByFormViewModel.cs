using FluentValidation;
using OldHome.DesktopApp.Services;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseOrgByFormViewModel<T, TSelf> : BaseFormViewModel<T, TSelf>
         where T : BaseOrgByDto
         where TSelf : BaseOrgByFormViewModel<T, TSelf>
    {
        public BaseOrgByFormViewModel(IValidator<TSelf> validator) : base(validator)
        {
            _user.OrgChanged += OnCurrentOrgChanged;
        }


        private async void OnCurrentOrgChanged(object? sender, int orgId)
        {
            await LoadDataAsync();
        }
    }
}
