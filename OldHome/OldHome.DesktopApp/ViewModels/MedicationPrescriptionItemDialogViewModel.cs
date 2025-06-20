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
using System.Reflection;
using OldHome.Core.Attributes;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationPrescriptionItemDialogViewModel
        : BaseDialogViewModel<MedicationPrescriptionItemDto, MedicationPrescriptionItemDialogViewModel>
    {
        #region Properties

        protected override string PreTitle => "药物处方项";

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

        private decimal? _dosageAmount;
        public decimal? DosageAmount
        {
            get { return _dosageAmount; }
            set
            {
                SetProperty(ref _dosageAmount, value);
                ValidateProperty(nameof(DosageAmount));
            }
        }

        private MedicineTime? _selectedTime;
        public MedicineTime? SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                SetProperty(ref _selectedTime, value);
                ValidateProperty(nameof(SelectedTime));
            }
        }

        private MedicineType? _selectedMedicineType;
        public MedicineType? SelectedMedicineType
        {
            get { return _selectedMedicineType; }
            set
            {
                SetProperty(ref _selectedMedicineType, value);
                ValidateProperty(nameof(SelectedMedicineType));
            }
        }

        private PrescriptionItemStatus? _selectedStatus;
        public PrescriptionItemStatus? SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                SetProperty(ref _selectedStatus, value);
                ValidateProperty(nameof(SelectedStatus));
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
        public ObservableCollection<MedicineType> MedicineTypes { get; set; } = new ObservableCollection<MedicineType>();
        public ObservableCollection<PrescriptionItemStatus> Statuses { get; set; } = new ObservableCollection<PrescriptionItemStatus>();
        public ObservableCollection<MedicineTime> Times { get; set; } = new ObservableCollection<MedicineTime>();


        #endregion
        public MedicationPrescriptionItemDialogViewModel(IValidator<MedicationPrescriptionItemDialogViewModel> validator) : base(validator)
        {
            foreach (MedicineType item in Enum.GetValues(typeof(MedicineType)))
            {
                MedicineTypes.Add(item);
            }
            foreach (PrescriptionItemStatus item in Enum.GetValues(typeof(PrescriptionItemStatus)))
            {
                Statuses.Add(item);
            }
            foreach (MedicineTime item in Enum.GetValues(typeof(MedicineTime)))
            {
                Times.Add(item);
            }
        }


        protected override void SetForm(IDialogParameters parameters)
        {
            MedicationPrescriptionItemDto item = parameters.GetValue<MedicationPrescriptionItemDto>("Item");
            Id = item.Id;
            SelectedMedicine = item.Medicine;
            DosageAmount = item.DosageAmount;
            SelectedTime = item.MedicineTime;
            SelectedMedicineType = item.MedicationType;
            SelectedStatus = item.Status;
            Notes = item.Notes;

        }

        protected override DialogParameters GetDialogParameters()
        {
            var dto = new MedicationPrescriptionItemDto
            {
                Medicine = SelectedMedicine,
                MedicineId = SelectedMedicine.Id,
                MedicineName = SelectedMedicine?.Name ?? string.Empty,
                DosageAmount = DosageAmount.Value,
                MedicineTime = SelectedTime.Value,
                MedicationType = SelectedMedicineType.Value,
                Status = SelectedStatus.Value,
                Notes = Notes
            };
            if (State.Equals(FormState.Edit))
            {
                dto.Id = Id.Value;
            }

            DialogParameters parameters = new DialogParameters
            {
                { "Item",dto}
            };
            return parameters;
        }
    }
}
