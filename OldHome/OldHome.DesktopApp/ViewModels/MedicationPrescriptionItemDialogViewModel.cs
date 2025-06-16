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

        private MedicationFrequency? _selectedFrequency;
        public MedicationFrequency? SelectedFrequency
        {
            get { return _selectedFrequency; }
            set
            {
                SetProperty(ref _selectedFrequency, value);
                ValidateProperty(nameof(SelectedFrequency));
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
        public ObservableCollection<MedicineType> AllMedicineTypes { get; set; } = new ObservableCollection<MedicineType>();
        public ObservableCollection<PrescriptionItemStatus> AllPrescriptionItemStatuses { get; set; } = new ObservableCollection<PrescriptionItemStatus>();



        #endregion
        public MedicationPrescriptionItemDialogViewModel(IValidator<MedicationPrescriptionItemDialogViewModel> validator) : base(validator)
        {
            foreach (MedicineType item in Enum.GetValues(typeof(MedicineType)))
            {
                AllMedicineTypes.Add(item);
            }
            foreach (PrescriptionItemStatus item in Enum.GetValues(typeof(PrescriptionItemStatus)))
            {
                AllPrescriptionItemStatuses.Add(item);
            }
        }


        protected override void SetForm(IDialogParameters parameters)
        {
            MedicationPrescriptionItemDto item = parameters.GetValue<MedicationPrescriptionItemDto>("Item");
            Id = item.Id;
            SelectedMedicine = item.Medicine;
            DosageAmount = item.DosageAmount;
            SelectedFrequency = item.Frequency;
            SelectedMedicineType = item.MedicationType;
            SelectedStatus = item.Status;
            Notes = item.Notes;

        }

        protected override DialogParameters GetDialogParameters()
        {
            DialogParameters parameters = new DialogParameters
            {
                { "Item", new MedicationPrescriptionItemDto
                    {
                        Id = Id.Value,
                        Medicine = SelectedMedicine,
                        DosageAmount = DosageAmount.Value,
                        Frequency = SelectedFrequency.Value,
                        MedicationType = SelectedMedicineType.Value,
                        Status = SelectedStatus.Value,
                        Notes = Notes
                    }
                }
            };
            return parameters;
        }
    }
}
