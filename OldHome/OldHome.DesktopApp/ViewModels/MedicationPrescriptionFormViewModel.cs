using FluentValidation;
using OldHome.Core;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DesktopApp.Views.Windows;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationPrescriptionFormViewModel : BaseFormViewModel<MedicationPrescriptionDto, MedicationPrescriptionFormViewModel>
    {
        #region Properties

        private string _prescriptionNumber;
        public string PrescriptionNumber
        {
            get { return _prescriptionNumber; }
            set
            {
                SetProperty(ref _prescriptionNumber, value);
                ValidateProperty(nameof(PrescriptionNumber));
            }
        }


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


        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                SetProperty(ref _startDate, value);
                ValidateProperty(nameof(StartDate));
            }
        }


        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                SetProperty(ref _endDate, value);
                ValidateProperty(nameof(EndDate));
            }
        }


        private PrescriptionType? _selectedPrescriptionType;
        public PrescriptionType? SelectedPrescriptionType
        {
            get { return _selectedPrescriptionType; }
            set
            {
                SetProperty(ref _selectedPrescriptionType, value);
                ValidateProperty(nameof(SelectedPrescriptionType));
            }
        }

        private PrescriptionStatus? _selectedStatus;
        public PrescriptionStatus? SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                SetProperty(ref _selectedStatus, value);
                ValidateProperty(nameof(SelectedStatus));
            }
        }

        private string _diagnosis;
        public string Diagnosis
        {
            get { return _diagnosis; }
            set
            {
                SetProperty(ref _diagnosis, value);
                ValidateProperty(nameof(Diagnosis));
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

        public ObservableCollection<PrescriptionType> AllPrescriptionTypes { get; set; } = new ObservableCollection<PrescriptionType>();
        public ObservableCollection<PrescriptionStatus> AllPrescriptionStatuses { get; set; } = new ObservableCollection<PrescriptionStatus>();
        public ObservableCollection<MedicationPrescriptionItemDto> Items { get; set; } = new ObservableCollection<MedicationPrescriptionItemDto>();
        #endregion

        private readonly IDialogService _dialogService;

        private DelegateCommand _addItemCommand;
        public DelegateCommand AddItemCommand =>
            _addItemCommand ?? (_addItemCommand = new DelegateCommand(ExecuteAddItemCommand));

        void ExecuteAddItemCommand()
        {
            DialogParameters parameters = new DialogParameters
            {
                { "State", FormState.Create }
            };
            _dialogService.Show("MedicationPrescriptionItemDialog", parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    MedicineSample medicineSample = result.Parameters.GetValue<MedicineSample>("Medicine");
                    Items.Add(new MedicationPrescriptionItemDto
                    {
                        MedicineId = medicineSample.Id,
                        MedicineName = medicineSample.Name,
                        MedicationType = result.Parameters.GetValue<MedicineType>("MedicineType"),

                    });
                }
            }, nameof(CustomDialogWindow));
        }

        public MedicationPrescriptionFormViewModel(IValidator<MedicationPrescriptionFormViewModel> validator, IDialogService dialogService) : base(validator)
        {
            _dialogService = dialogService;
            foreach (PrescriptionType item in Enum.GetValues(typeof(PrescriptionType)))
            {
                this.AllPrescriptionTypes.Add(item);
            }

            foreach (PrescriptionStatus item in Enum.GetValues(typeof(PrescriptionStatus)))
            {
                this.AllPrescriptionStatuses.Add(item);
            }
        }

        public override async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            PrescriptionNumber = string.Empty;
            SelectedResident = null;
            StartDate = null;
            EndDate = null;
            SelectedPrescriptionType = null;
            SelectedStatus = null;
            Diagnosis = string.Empty;
            Notes = string.Empty;
        }

        public override async Task ChangeState(MedicationPrescriptionDto detail, FormState state)
        {
            if (detail == null)
            {
                Clear();
            }
            else
            {
                PrescriptionNumber = detail.PrescriptionNumber;
                SelectedResident = detail.Resident;
                StartDate = detail.StartDate.ToDateTime(TimeOnly.MinValue);
                EndDate = detail.EndDate?.ToDateTime(TimeOnly.MinValue);
                SelectedPrescriptionType = detail.PrescriptionType;
                SelectedStatus = detail.Status;
                Diagnosis = detail.Diagnosis;
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
            return await ValidateAndRunAsync(async () =>
                await _api.CreateMedicationPrescription(new MedicationPrescriptionDto
                {
                    PrescriptionNumber = PrescriptionNumber,
                    ResidentId = SelectedResident!.Id,
                    StartDate = DateOnly.FromDateTime(StartDate!.Value),
                    EndDate = EndDate == null ? null : DateOnly.FromDateTime(EndDate.Value),
                    PrescriptionType = SelectedPrescriptionType!.Value,
                    Status = SelectedStatus!.Value,
                    Diagnosis = Diagnosis,
                    Notes = Notes,
                    Items = Items.ToList()
                }), head: "处方创建");
        }

        protected override Task<bool> ModifyAsync()
        {
            return ValidateAndRunAsync(async () =>
                await _api.ModifyMedicationPrescription(new MedicationPrescriptionDto
                {
                    Id = Id!.Value,
                    PrescriptionNumber = PrescriptionNumber,
                    ResidentId = SelectedResident!.Id,
                    StartDate = DateOnly.FromDateTime(StartDate!.Value),
                    EndDate = EndDate == null ? null : DateOnly.FromDateTime(EndDate.Value),
                    PrescriptionType = SelectedPrescriptionType!.Value,
                    Status = SelectedStatus!.Value,
                    Diagnosis = Diagnosis,
                    Notes = Notes,
                    Items = Items.ToList()
                }), head: "处方修改");
        }
    }
}
