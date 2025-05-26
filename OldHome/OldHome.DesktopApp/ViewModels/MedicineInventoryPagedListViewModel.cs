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
    [Navigation("SettingMedicineInventories", "SettingMedicineInventories", "库存批次管理", "人员物料", Order = 6, Icon = "e93b")]
    public class MedicineInventoryPagedListViewModel : BaseOrgByPagedListViewModel<MedicineInventoryDto, MedicineInventoryFormViewModel>
    {
        private string _queryBatchNumber;
        public string QueryBatchNumber
        {
            get { return _queryBatchNumber; }
            set { SetProperty(ref _queryBatchNumber, value); }
        }

        private string _queryResidentFilter;
        public string QueryResidentFilter
        {
            get { return _queryResidentFilter; }
            set { SetProperty(ref _queryResidentFilter, value); }
        }

        private string _queryMedicineFilter;
        public string QueryMedicineFilter
        {
            get { return _queryMedicineFilter; }
            set { SetProperty(ref _queryMedicineFilter, value); }
        }

        public MedicineInventoryPagedListViewModel(MedicineInventoryFormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<MedicineInventoryDto>>>> GetPagedFunc =>
            async (pi, pz) => await _api.GetPagedMedicineInventories(pi, pz, QueryBatchNumber, QueryResidentFilter, QueryMedicineFilter);

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.DeleteMedicineInventory(SelectedItem.Id);
    }
}
