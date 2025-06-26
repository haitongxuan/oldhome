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



        private decimal? _plannedQuantity;
        public decimal? PlannedQuantity
        {
            get { return _plannedQuantity; }
            set
            {
                SetProperty(ref _plannedQuantity, value);
                ValidateProperty(nameof(PlannedQuantity));
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
            PlannedQuantity = item.PlannedQuantity;
            ActualQuantity = item.ActualQuantity;
            SelectedDispenseStatus = item.DispenseStatus;
        }

        protected override DialogParameters GetDialogParameters()
        {
            var dto = new MedicationOutboundItemDto
            {
                ResidentId = SelectedResident!.Id,
                ResidentName = SelectedResident.Name,
                MedicineId = SelectedMedicine!.Id,
                MedicineName = SelectedMedicine.Name,
                PlannedQuantity = PlannedQuantity!.Value,
                ActualQuantity = ActualQuantity!.Value,
                DispenseStatus = DispenseStatus.Dispensed,
                ResidentConfirmedTime = DateTime.Now,
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

    }
}