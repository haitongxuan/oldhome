using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingMedicationPrescriptions", "SettingMedicationPrescriptions", "住户药品处方", "Group", IsDefault = true, Icon = "e93b")]
    public class MedicationPrescriptionPagedListViewModel : BasePagedListViewModel<MedicationPrescriptionDto, MedicationPrescriptionFormViewModel>
    {
        public MedicationPrescriptionPagedListViewModel(MedicationPrescriptionFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<MedicationPrescriptionDto>>>> GetPagedFunc => throw new NotImplementedException();

        protected override Func<Task<BaseResponse>> DeleteFunc => throw new NotImplementedException();
    }
}
