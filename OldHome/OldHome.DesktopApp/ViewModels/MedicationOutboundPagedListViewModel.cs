using OldHome.Core;
using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("SettingMedicationOutbounds", "SettingMedicationOutbounds", "发药出库管理", "用药管理", Icon = "e93c")]
    public class MedicationOutboundPagedListViewModel : BaseOrgByPagedListViewModel<MedicationOutboundDto, MedicationOutboundFormViewModel>
    {
        private DateTime? _queryStartDate;
        public DateTime? QueryStartDate
        {
            get { return _queryStartDate; }
            set { SetProperty(ref _queryStartDate, value); }
        }

        private DateTime? _queryEndDate;
        public DateTime? QueryEndDate
        {
            get { return _queryEndDate; }
            set { SetProperty(ref _queryEndDate, value); }
        }

        private MedicineTime? _queryMedicineTime;
        public MedicineTime? QueryMedicineTime
        {
            get { return _queryMedicineTime; }
            set { SetProperty(ref _queryMedicineTime, value); }
        }

        private MedicationOutboundType? _queryOutboundType;
        public MedicationOutboundType? QueryOutboundType
        {
            get { return _queryOutboundType; }
            set { SetProperty(ref _queryOutboundType, value); }
        }

        private MedicationOutboundStatus? _queryStatus;
        public MedicationOutboundStatus? QueryStatus
        {
            get { return _queryStatus; }
            set { SetProperty(ref _queryStatus, value); }
        }

        private StaffSample? _queryPharmacist;
        public StaffSample? QueryPharmacist
        {
            get { return _queryPharmacist; }
            set { SetProperty(ref _queryPharmacist, value); }
        }

        public ObservableCollection<MedicineTime> AllMedicineTimes { get; set; } = new ObservableCollection<MedicineTime>();
        public ObservableCollection<MedicationOutboundType> AllOutboundTypes { get; set; } = new ObservableCollection<MedicationOutboundType>();
        public ObservableCollection<MedicationOutboundStatus> AllOutboundStatuses { get; set; } = new ObservableCollection<MedicationOutboundStatus>();

        public MedicationOutboundPagedListViewModel(MedicationOutboundFormViewModel formViewModel) : base(formViewModel)
        {
            // 添加空选项
            AllMedicineTimes.Add(default(MedicineTime));
            foreach (MedicineTime item in Enum.GetValues(typeof(MedicineTime)))
            {
                AllMedicineTimes.Add(item);
            }

            AllOutboundTypes.Add(default(MedicationOutboundType));
            foreach (MedicationOutboundType item in Enum.GetValues(typeof(MedicationOutboundType)))
            {
                AllOutboundTypes.Add(item);
            }

            AllOutboundStatuses.Add(default(MedicationOutboundStatus));
            foreach (MedicationOutboundStatus item in Enum.GetValues(typeof(MedicationOutboundStatus)))
            {
                AllOutboundStatuses.Add(item);
            }
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<MedicationOutboundDto>>>> GetPagedFunc =>
           async (pi, pz) => await _api.GetPagedMedicationOutbounds(pi, pz,
               QueryStartDate,
               QueryEndDate,
               QueryMedicineTime,
               QueryOutboundType,
               QueryStatus,
               QueryPharmacist?.Id);

        protected override Func<Task<BaseResponse>> DeleteFunc => async () => await _api.DeleteMedicationOutbound(SelectedItem.Id);
    }
}