using OldHome.DesktopApp.Services;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseOrgByListViewModel<T, F> : BaseListViewModel<T, F> where T : BaseOrgByDto where F : BaseFormViewModel<T, F>
    {
        public BaseOrgByListViewModel(F formViewModel) : base(formViewModel)
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
