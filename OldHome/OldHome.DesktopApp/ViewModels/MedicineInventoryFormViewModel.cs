using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicineInventoryFormViewModel : BaseOrgByFormViewModel<MedicineInventoryDto, MedicineInventoryFormViewModel>
    {
        #region Properties

        private ResidentSample? _selectedResident;
        public ResidentSample? SelectedResident
        {
            get { return _selectedResident; }
            set
            {
                SetProperty(ref _selectedResident, value);
                ValidateProperty(nameof(SelectedResident));
            }
        }


        private MedicineSample? _selectedMedicine;
        public MedicineSample? SelectedMedicine
        {
            get { return _selectedMedicine; }
            set
            {
                SetProperty(ref _selectedMedicine, value);
                ValidateProperty(nameof(SelectedMedicine));
            }
        }

        private string _batchNumber;
        public string BatchNumber
        {
            get { return _batchNumber; }
            set
            {
                SetProperty(ref _batchNumber, value);
                ValidateProperty(nameof(BatchNumber));
            }
        }


        private DateTime? _expirationDate;
        public DateTime? ExpirationDate
        {
            get { return _expirationDate; }
            set
            {
                SetProperty(ref _expirationDate, value);
                ValidateProperty(nameof(ExpirationDate));
            }
        }

        private int? _packageCount;
        public int? PackageCount
        {
            get { return _packageCount; }
            set
            {
                SetProperty(ref _packageCount, value);
                if (SelectedMedicine != null && value.HasValue)
                {
                    QtyTotal = value * SelectedMedicine.QtyPerPackage;
                    QtyRemaining = value * SelectedMedicine.QtyPerPackage;
                }
                ValidateProperty(nameof(PackageCount));
            }
        }

        private int? _qtyTotal;
        public int? QtyTotal
        {
            get { return _qtyTotal; }
            set
            {
                SetProperty(ref _qtyTotal, value);
                ValidateProperty(nameof(QtyTotal));
            }
        }

        private int? _qtyRemaining;
        public int? QtyRemaining
        {
            get { return _qtyRemaining; }
            set
            {
                SetProperty(ref _qtyRemaining, value);
                ValidateProperty(nameof(QtyRemaining));
            }
        }


        private MedicineInventoryStatus? _selectedStatus;
        public MedicineInventoryStatus? SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                SetProperty(ref _selectedStatus, value);
                ValidateProperty(nameof(SelectedStatus));
            }
        }

        public ObservableCollection<MedicineInventoryStatus> AllStatuses { get; set; } = new ObservableCollection<MedicineInventoryStatus>();
        #endregion

        public MedicineInventoryFormViewModel(IValidator<MedicineInventoryFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            AllStatuses.Clear();
            foreach (MedicineInventoryStatus item in Enum.GetValues(typeof(MedicineInventoryStatus)))
            {
                AllStatuses.Add(item);
            }
            await Task.CompletedTask;
        }

        public override async Task ChangeState(MedicineInventoryDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                BatchNumber = detail.BatchNumber;
                ExpirationDate = detail.ExpirationDate.ToDateTime(TimeOnly.MinValue);
                this.PackageCount = detail.PackageCount;
                QtyRemaining = detail.QtyRemaining;
                QtyTotal = detail.QtyTotal;
                SelectedMedicine = detail.Medicine;
                SelectedResident = detail.Resident;
                SelectedStatus = detail.Status;
            }
            else
            {
                Clear();
            }
        }

        protected override void Clear()
        {
            this.BatchNumber = string.Empty;
            this.ExpirationDate = null;
            this.PackageCount = null;
            this.QtyTotal = null;
            this.QtyRemaining = null;
            SelectedMedicine = null;
            SelectedResident = null;
            SelectedStatus = null;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () =>
                 await _api.CreateMedicineInventory(new MedicineInventoryCreate
                 {
                     ExpirationDate = DateOnly.FromDateTime(this.ExpirationDate.Value),
                     PackageCount = PackageCount.Value,
                     QtyTotal = QtyTotal.Value,
                     QtyRemaining = QtyRemaining.Value,
                     MedicineId = SelectedMedicine.Id,
                     MedicineBarcode = SelectedMedicine.Barcode,
                     MedicineName = SelectedMedicine.Name,
                     ResidentId = SelectedResident is null ? null : SelectedResident.Id,
                     ResidentName = SelectedResident is null ? null : SelectedResident.Name,
                     ResidentCode = SelectedResident is null ? null : SelectedResident.Code,
                     Status = SelectedStatus.Value,
                 })
             , head: "入库批次");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyMedicineInventory(new MedicineInventoryModify
            {
                Id = this.Id!.Value,
                ExpirationDate = DateOnly.FromDateTime(this.ExpirationDate.Value),
                PackageCount = PackageCount.Value,
                QtyTotal = QtyTotal.Value,
                QtyRemaining = QtyRemaining.Value,
                MedicineId = SelectedMedicine.Id,
                MedicineBarcode = SelectedMedicine.Barcode,
                MedicineName = SelectedMedicine.Name,
                ResidentId = SelectedResident is null ? null : SelectedResident.Id,
                ResidentName = SelectedResident is null ? null : SelectedResident.Name,
                ResidentCode = SelectedResident is null ? null : SelectedResident.Code,
                Status = SelectedStatus.Value,
            }), head: "入库批次");
        }
    }
}
