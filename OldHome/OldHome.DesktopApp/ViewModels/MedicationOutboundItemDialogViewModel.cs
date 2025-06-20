using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Dialogs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationOutboundItemDialogViewModel
        : BaseDialogViewModel<MedicationOutboundItemDto, MedicationOutboundItemDialogViewModel>
    {
        #region Properties

        protected override string PreTitle => "发药明细";

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

        private decimal? _plannedQuantity;
        public decimal? PlannedQuantity
        {
            get { return _plannedQuantity; }
            set
            {
                SetProperty(ref _plannedQuantity, value);
                ValidateProperty(nameof(PlannedQuantity));
                CalculateTotalCost();
            }
        }

        private decimal? _actualQuantity;
        public decimal? ActualQuantity
        {
            get { return _actualQuantity; }
            set
            {
                SetProperty(ref _actualQuantity, value);
                ValidateProperty(nameof(ActualQuantity));
                CalculateTotalCost();
            }
        }

        private decimal? _unitCost;
        public decimal? UnitCost
        {
            get { return _unitCost; }
            set
            {
                SetProperty(ref _unitCost, value);
                ValidateProperty(nameof(UnitCost));
                CalculateTotalCost();
            }
        }

        private decimal? _totalCost;
        public decimal? TotalCost
        {
            get { return _totalCost; }
            set
            {
                SetProperty(ref _totalCost, value);
                ValidateProperty(nameof(TotalCost));
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

        private DispenseStatus? _selectedDispenseStatus;
        public DispenseStatus? SelectedDispenseStatus
        {
            get { return _selectedDispenseStatus; }
            set
            {
                SetProperty(ref _selectedDispenseStatus, value);
                ValidateProperty(nameof(SelectedDispenseStatus));
            }
        }

        private string _instructions;
        public string Instructions
        {
            get { return _instructions; }
            set
            {
                SetProperty(ref _instructions, value);
                ValidateProperty(nameof(Instructions));
            }
        }

        private string _specialInstructions;
        public string SpecialInstructions
        {
            get { return _specialInstructions; }
            set
            {
                SetProperty(ref _specialInstructions, value);
                ValidateProperty(nameof(SpecialInstructions));
            }
        }

        private DateTime? _residentConfirmedTime;
        public DateTime? ResidentConfirmedTime
        {
            get { return _residentConfirmedTime; }
            set
            {
                SetProperty(ref _residentConfirmedTime, value);
                ValidateProperty(nameof(ResidentConfirmedTime));
            }
        }

        private string _refusalReason;
        public string RefusalReason
        {
            get { return _refusalReason; }
            set
            {
                SetProperty(ref _refusalReason, value);
                ValidateProperty(nameof(RefusalReason));
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

        public ObservableCollection<DispenseStatus> DispenseStatuses { get; set; } = new ObservableCollection<DispenseStatus>();

        #endregion

        public MedicationOutboundItemDialogViewModel(IValidator<MedicationOutboundItemDialogViewModel> validator) : base(validator)
        {
            foreach (DispenseStatus item in Enum.GetValues(typeof(DispenseStatus)))
            {
                DispenseStatuses.Add(item);
            }
        }

        protected override void SetForm(IDialogParameters parameters)
        {
            MedicationOutboundItemDto item = parameters.GetValue<MedicationOutboundItemDto>("Item");
            Id = item.Id;
            SelectedResident = new ResidentSample { Id = item.ResidentId, Name = item.ResidentName };
            SelectedMedicine = new MedicineSample { Id = item.MedicineId, Name = item.MedicineName };
            BatchNumber = item.BatchNumber;
            PlannedQuantity = item.PlannedQuantity;
            ActualQuantity = item.ActualQuantity;
            UnitCost = item.UnitCost;
            TotalCost = item.TotalCost;
            ExpirationDate = item.ExpirationDate.ToDateTime(TimeOnly.MinValue);
            SelectedDispenseStatus = item.DispenseStatus;
            Instructions = item.Instructions;
            SpecialInstructions = item.SpecialInstructions;
            ResidentConfirmedTime = item.ResidentConfirmedTime;
            RefusalReason = item.RefusalReason;
            Notes = item.Notes;
        }

        protected override DialogParameters GetDialogParameters()
        {
            var dto = new MedicationOutboundItemDto
            {
                ResidentId = SelectedResident!.Id,
                ResidentName = SelectedResident.Name,
                MedicineId = SelectedMedicine!.Id,
                MedicineName = SelectedMedicine.Name,
                BatchNumber = BatchNumber,
                PlannedQuantity = PlannedQuantity!.Value,
                ActualQuantity = ActualQuantity!.Value,
                UnitCost = UnitCost!.Value,
                TotalCost = TotalCost!.Value,
                ExpirationDate = DateOnly.FromDateTime(ExpirationDate!.Value),
                DispenseStatus = SelectedDispenseStatus!.Value,
                Instructions = Instructions,
                SpecialInstructions = SpecialInstructions,
                ResidentConfirmedTime = ResidentConfirmedTime,
                RefusalReason = RefusalReason,
                Notes = Notes
            };

            if (State.Equals(FormState.Edit))
            {
                dto.Id = Id!.Value;
            }

            DialogParameters parameters = new DialogParameters
            {
                { "Item", dto }
            };
            return parameters;
        }

        private void CalculateTotalCost()
        {
            if (ActualQuantity.HasValue && UnitCost.HasValue)
            {
                TotalCost = ActualQuantity.Value * UnitCost.Value;
            }
        }
    }
}