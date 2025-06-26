using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DesktopApp.Views.Windows;
using OldHome.DTO;
using Panuon.WPF.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationOutboundFormViewModel
        : BaseItemFormViewModel<MedicationOutboundDto, MedicationOutboundFormViewModel, MedicationOutboundItemDto>
    {
        #region Properties

        private bool _enableOperate;
        public bool EnableOperate
        {
            get { return _enableOperate; }
            set { SetProperty(ref _enableOperate, value); }
        }

        private string _outboundNumber;
        public string OutboundNumber
        {
            get { return _outboundNumber; }
            set
            {
                SetProperty(ref _outboundNumber, value);
                ValidateProperty(nameof(OutboundNumber));
            }
        }

        private DateTime? _outboundDate;
        public DateTime? OutboundDate
        {
            get { return _outboundDate; }
            set
            {
                SetProperty(ref _outboundDate, value);
                ValidateProperty(nameof(OutboundDate));
            }
        }

        private MedicineTime? _selectedMedicineTime;
        public MedicineTime? SelectedMedicineTime
        {
            get { return _selectedMedicineTime; }
            set
            {
                SetProperty(ref _selectedMedicineTime, value);
                ValidateProperty(nameof(SelectedMedicineTime));
            }
        }

        private MedicationOutboundType? _selectedOutboundType;
        public MedicationOutboundType? SelectedOutboundType
        {
            get { return _selectedOutboundType; }
            set
            {
                SetProperty(ref _selectedOutboundType, value);
                ValidateProperty(nameof(SelectedOutboundType));
            }
        }

        private StaffSample? _selectedPharmacist;
        public StaffSample? SelectedPharmacist
        {
            get { return _selectedPharmacist; }
            set
            {
                SetProperty(ref _selectedPharmacist, value);
                ValidateProperty(nameof(SelectedPharmacist));
            }
        }

        private StaffSample? _selectedCheckedBy;
        public StaffSample? SelectedCheckedBy
        {
            get { return _selectedCheckedBy; }
            set
            {
                SetProperty(ref _selectedCheckedBy, value);
                ValidateProperty(nameof(SelectedCheckedBy));
            }
        }

        private MedicationOutboundStatus? _selectedStatus;
        public MedicationOutboundStatus? SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                SetProperty(ref _selectedStatus, value);
                ValidateProperty(nameof(SelectedStatus));
            }
        }

        private DateTime? _preparedTime;
        public DateTime? PreparedTime
        {
            get { return _preparedTime; }
            set
            {
                SetProperty(ref _preparedTime, value);
                ValidateProperty(nameof(PreparedTime));
            }
        }

        private DateTime? _checkedTime;
        public DateTime? CheckedTime
        {
            get { return _checkedTime; }
            set
            {
                SetProperty(ref _checkedTime, value);
                ValidateProperty(nameof(CheckedTime));
            }
        }

        private DateTime? _dispensedTime;
        public DateTime? DispensedTime
        {
            get { return _dispensedTime; }
            set
            {
                SetProperty(ref _dispensedTime, value);
                ValidateProperty(nameof(DispensedTime));
            }
        }

        private int _totalItemCount;
        public int TotalItemCount
        {
            get { return _totalItemCount; }
            set
            {
                SetProperty(ref _totalItemCount, value);
                ValidateProperty(nameof(TotalItemCount));
            }
        }


        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                SetProperty(ref _notes, value);
                ValidateProperty(nameof(Notes));
            }
        }

        public ObservableCollection<MedicineTime> AllMedicineTimes { get; set; } = new ObservableCollection<MedicineTime>();
        public ObservableCollection<MedicationOutboundType> AllOutboundTypes { get; set; } = new ObservableCollection<MedicationOutboundType>();
        public ObservableCollection<MedicationOutboundStatus> AllOutboundStatuses { get; set; } = new ObservableCollection<MedicationOutboundStatus>();

        #endregion

        protected override Func<MedicationOutboundItemDto, string> DeleteItemMessage => (item) => { return $"发药项：{item.MedicineName} - {item.ResidentName}"; };
        protected override string DialogName => "MedicationOutboundItemDialog";

        public MedicationOutboundFormViewModel(IValidator<MedicationOutboundFormViewModel> validator, IDialogService dialogService) : base(validator, dialogService)
        {
            foreach (MedicineTime item in Enum.GetValues(typeof(MedicineTime)))
            {
                this.AllMedicineTimes.Add(item);
            }

            foreach (MedicationOutboundType item in Enum.GetValues(typeof(MedicationOutboundType)))
            {
                this.AllOutboundTypes.Add(item);
            }

            foreach (MedicationOutboundStatus item in Enum.GetValues(typeof(MedicationOutboundStatus)))
            {
                this.AllOutboundStatuses.Add(item);
            }
        }

        public override async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            OutboundNumber = string.Empty;
            OutboundDate = DateTime.Now;
            SelectedMedicineTime = null;
            SelectedOutboundType = null;
            SelectedPharmacist = null;
            SelectedCheckedBy = null;
            SelectedStatus = null;
            PreparedTime = DateTime.Now;
            CheckedTime = null;
            DispensedTime = null;
            TotalItemCount = 0;
            Notes = string.Empty;
            Items.Clear();
        }

        public override async Task ChangeState(MedicationOutboundDto detail, FormState state)
        {
            Clear();
            if (state.Equals(FormState.View))
            {
                EnableOperate = false;
            }
            else
            {
                EnableOperate = true;
            }
            if (detail != null)
            {
                OutboundNumber = detail.OutboundNumber;
                OutboundDate = detail.OutboundDate.ToDateTime(TimeOnly.MinValue);
                SelectedMedicineTime = detail.MedicineTime;
                SelectedOutboundType = detail.OutboundType;
                SelectedPharmacist = new StaffSample { Id = detail.PharmacistId, Name = detail.PharmacistName };
                if (detail.CheckedById.HasValue)
                {
                    SelectedCheckedBy = new StaffSample { Id = detail.CheckedById.Value, Name = detail.CheckedByName };
                }
                SelectedStatus = detail.Status;
                PreparedTime = detail.PreparedTime;
                CheckedTime = detail.CheckedTime;
                DispensedTime = detail.DispensedTime;
                TotalItemCount = detail.TotalItemCount;
                Notes = detail.Notes;
                foreach (var item in detail.Items)
                {
                    Items.Add(item);
                }
            }
            await base.ChangeState(detail, state);
        }

        protected override async Task<bool> CreateAsync()
        {
            var res = await ValidateAndRunAsync(async () =>
            {
                var dto = new MedicationOutboundCreateDto();
                dto.OutboundDate = DateOnly.FromDateTime(OutboundDate!.Value);
                dto.MedicineTime = SelectedMedicineTime!.Value;
                dto.OutboundType = SelectedOutboundType!.Value;
                dto.PharmacistId = SelectedPharmacist!.Id;
                dto.CheckedById = SelectedCheckedBy?.Id;
                dto.Status = SelectedStatus!.Value;
                dto.PreparedTime = PreparedTime!.Value;
                dto.CheckedTime = CheckedTime;
                dto.DispensedTime = DispensedTime;
                dto.TotalItemCount = TotalItemCount;
                dto.Notes = Notes;
                dto.Items = Items.ToList();
                return await _api.MedicationOutboundApi.CreateMedicationOutbound(dto);
            }, head: "发药单创建");
            return res;
        }

        protected override Task<bool> ModifyAsync()
        {
            return ValidateAndRunAsync(async () =>
            {
                var dto = new MedicationOutboundModifyDto();
                dto.Id = Id!.Value;
                dto.OutboundNumber = OutboundNumber;
                dto.OutboundDate = DateOnly.FromDateTime(OutboundDate!.Value);
                dto.MedicineTime = SelectedMedicineTime!.Value;
                dto.OutboundType = SelectedOutboundType!.Value;
                dto.PharmacistId = SelectedPharmacist!.Id;
                dto.CheckedById = SelectedCheckedBy?.Id;
                dto.Status = SelectedStatus!.Value;
                dto.PreparedTime = PreparedTime!.Value;
                dto.CheckedTime = CheckedTime;
                dto.DispensedTime = DispensedTime;
                dto.TotalItemCount = TotalItemCount;
                dto.Notes = Notes;
                dto.Items = Items.ToList();
                return await _api.MedicationOutboundApi.ModifyMedicationOutbound(dto);
            }, head: "发药单修改");
        }

        // 自动计算总数量和总金额
        protected override void OnItemsChanged()
        {
            TotalItemCount = Items.Count;
            base.OnItemsChanged();
        }
    }
}