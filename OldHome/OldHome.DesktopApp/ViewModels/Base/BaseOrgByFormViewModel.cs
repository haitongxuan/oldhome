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
            var ea = ContainerLocator.Container.Resolve<IEventAggregator>();
            ea.GetEvent<CurrentOrgChangedEvent>().Subscribe(OnCurrentOrgChanged);
        }
        private async void OnCurrentOrgChanged(int orgId)
        {
            await LoadDataAsync();
        }
    }
}
