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
    [Navigation("SettingMedicationPrescriptions", "SettingMedicationPrescriptions", "长者药物处方", "用药管理", Icon = "e93b")]
    public class MedicationPrescriptionPagedListViewModel : BaseOrgByPagedListViewModel<MedicationPrescriptionDto, MedicationPrescriptionFormViewModel>
    {
        private ResidentSample? _queryResident;
        public ResidentSample? QueryResident
        {
            get { return _queryResident; }
            set { SetProperty(ref _queryResident, value); }
        }
        public MedicationPrescriptionPagedListViewModel(MedicationPrescriptionFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<MedicationPrescriptionDto>>>> GetPagedFunc =>
           async (pi, pz) => await _api.GetPagedMedicationPrescriptions(pi, pz, QueryResident?.Id);

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.DeleteMedicationPrescription(SelectedItem.Id);
    }
}
