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
    [Navigation("SettingMedicines", "SettingMedicines", "药品资料", "人员物料", Order = 5, Icon = "e93b")]
    public class MedicinePagedListViewModel : BasePagedListViewModel<MedicineDto, MedicineFormViewModel>
    {
        private string _queryName;
        public string QueryName
        {
            get { return _queryName; }
            set { SetProperty(ref _queryName, value); }
        }

        private string _queryBarcode;
        public string QueryBarcode
        {
            get { return _queryBarcode; }
            set { SetProperty(ref _queryBarcode, value); }
        }

        public MedicinePagedListViewModel(MedicineFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<MedicineDto>>>> GetPagedFunc =>
            async (pi, pz) => await _api.MedicineApi.GetPagedMedicines(pi, pz, QueryName, QueryBarcode);

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.MedicineApi.DeleteMedicine(SelectedItem.Id);
    }
}
