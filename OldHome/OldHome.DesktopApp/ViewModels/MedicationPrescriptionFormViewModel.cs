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
    public class MedicationPrescriptionFormViewModel
        : BaseItemFormViewModel<MedicationPrescriptionDto, MedicationPrescriptionFormViewModel, MedicationPrescriptionItemDto>
    {
        #region Properties

        private bool _enableOperate;
        public bool EnableOperate
        {
            get { return _enableOperate; }
            set { SetProperty(ref _enableOperate, value); }
        }

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
        #endregion

        protected override Func<MedicationPrescriptionItemDto, string> DeleteItemMessage => (item) => { return $"处方项：{item.MedicineName}"; };
        protected override string DialogName => "MedicationPrescriptionItemDialog";

        public MedicationPrescriptionFormViewModel(IValidator<MedicationPrescriptionFormViewModel> validator, IDialogService dialogService) : base(validator, dialogService)
        {
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
            Items.Clear();
        }

        public override async Task ChangeState(MedicationPrescriptionDto detail, FormState state)
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
                PrescriptionNumber = detail.PrescriptionNumber;
                SelectedResident = detail.Resident;
                StartDate = detail.StartDate.ToDateTime(TimeOnly.MinValue);
                EndDate = detail.EndDate?.ToDateTime(TimeOnly.MinValue);
                SelectedPrescriptionType = detail.PrescriptionType;
                SelectedStatus = detail.Status;
                Diagnosis = detail.Diagnosis;
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
                var dto = new MedicationPrescriptionDto();
                dto.ResidentId = SelectedResident!.Id;
                dto.StartDate = DateOnly.FromDateTime(StartDate!.Value);
                dto.EndDate = EndDate is not null ? DateOnly.FromDateTime(EndDate.Value) : null;
                dto.PrescriptionType = SelectedPrescriptionType.Value;
                dto.Status = SelectedStatus!.Value;
                dto.Diagnosis = Diagnosis;
                dto.Items = Items.ToList();
                return await _api.CreateMedicationPrescription(dto);
            }, head: "处方创建");
            return res;
        }

        protected override Task<bool> ModifyAsync()
        {
            return ValidateAndRunAsync(async () =>
            {
                var dto = new MedicationPrescriptionModifyDto();
                dto.Id = Id!.Value;
                dto.ResidentId = SelectedResident!.Id;
                dto.StartDate = DateOnly.FromDateTime(StartDate!.Value);
                dto.EndDate = EndDate == null ? null : DateOnly.FromDateTime(EndDate.Value);
                dto.PrescriptionType = SelectedPrescriptionType!.Value;
                dto.Status = SelectedStatus!.Value;
                dto.Diagnosis = Diagnosis;
                dto.Notes = Notes;
                dto.Items = Items.ToList();
                return await _api.ModifyMedicationPrescription(dto);
            }, head: "处方修改");
        }
    }
}
