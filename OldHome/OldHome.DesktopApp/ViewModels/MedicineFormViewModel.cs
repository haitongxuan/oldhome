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
    public class MedicineFormViewModel : BaseFormViewModel<MedicineDto, MedicineFormViewModel>
    {
        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                ValidateProperty(nameof(Name));
            }
        }

        private string _specification;
        public string Specification
        {
            get { return _specification; }
            set
            {
                SetProperty(ref _specification, value);
                ValidateProperty(nameof(Specification));
            }
        }

        private string _manufacturer;
        public string Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                SetProperty(ref _manufacturer, value);
                ValidateProperty(nameof(Manufacturer));
            }
        }

        private string _storageMethod;
        public string StorageMethod
        {
            get { return _storageMethod; }
            set
            {
                SetProperty(ref _storageMethod, value);
                ValidateProperty(nameof(StorageMethod));
            }
        }

        private MedicinePackageUnit? _selectedPackageUnit;
        public MedicinePackageUnit? SelectedPackageUnit
        {
            get { return _selectedPackageUnit; }
            set
            {
                SetProperty(ref _selectedPackageUnit, value);
                ValidateProperty(nameof(SelectedPackageUnit));
            }
        }

        private MedicineUnit? _selectedMedicineUnit;
        public MedicineUnit? SelectedMedicineUnit
        {
            get { return _selectedMedicineUnit; }
            set
            {
                SetProperty(ref _selectedMedicineUnit, value);
                ValidateProperty(nameof(SelectedMedicineUnit));
            }
        }

        private int _qtyPerPackage;
        public int QtyPerPackage
        {
            get { return _qtyPerPackage; }
            set
            {
                SetProperty(ref _qtyPerPackage, value);
                ValidateProperty(nameof(QtyPerPackage));
            }
        }

        private string _barcode;
        public string Barcode
        {
            get { return _barcode; }
            set
            {
                SetProperty(ref _barcode, value);
                ValidateProperty(nameof(Barcode));
            }
        }
        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        public ObservableCollection<MedicinePackageUnit> AllPackageUnits { get; set; } = new ObservableCollection<MedicinePackageUnit>();
        public ObservableCollection<MedicineUnit> AllMedicineUnits { get; set; } = new ObservableCollection<MedicineUnit>();
        #endregion

        public MedicineFormViewModel(IValidator<MedicineFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            foreach (var item in Enum.GetValues(typeof(MedicinePackageUnit)))
            {
                AllPackageUnits.Add((MedicinePackageUnit)item);
            }
            foreach (var item in Enum.GetValues(typeof(MedicineUnit)))
            {
                AllMedicineUnits.Add((MedicineUnit)item);
            }
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            Id = null;
            Name = string.Empty;
            Specification = string.Empty;
            Manufacturer = string.Empty;
            StorageMethod = string.Empty;
            SelectedPackageUnit = null;
            SelectedMedicineUnit = null;
            QtyPerPackage = 0;
            Barcode = string.Empty;
            Notes = string.Empty;

        }

        public override async Task ChangeState(MedicineDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Name = detail.Name;
                Specification = detail.Specification;
                Manufacturer = detail.Manufacturer;
                StorageMethod = detail.StorageMethod;
                SelectedPackageUnit = detail.PackageUnit;
                SelectedMedicineUnit = detail.MinUnit;
                QtyPerPackage = detail.QtyPerPackage;
                Barcode = detail.Barcode;
                Notes = detail.Notes;
            }
            else
            {
                Clear();
            }
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () =>
             await _api.CreateMedicine(new MedicineCreate
             {
                 Name = this.Name,
                 Specification = this.Specification,
                 Manufacturer = this.Manufacturer,
                 StorageMethod = this.StorageMethod,
                 PackageUnit = this.SelectedPackageUnit.Value,
                 MinUnit = this.SelectedMedicineUnit.Value,
                 QtyPerPackage = this.QtyPerPackage,
                 Barcode = this.Barcode,
                 Notes = this.Notes
             }), head: "药品");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.ModifyMedicine(new MedicineModify
            {
                Id = this.Id.Value,
                Name = this.Name,
                Specification = this.Specification,
                Manufacturer = this.Manufacturer,
                StorageMethod = this.StorageMethod,
                PackageUnit = this.SelectedPackageUnit.Value,
                MinUnit = this.SelectedMedicineUnit.Value,
                QtyPerPackage = this.QtyPerPackage,
                Barcode = this.Barcode,
                Notes = this.Notes
            }), head: "药品");
        }
    }
}
