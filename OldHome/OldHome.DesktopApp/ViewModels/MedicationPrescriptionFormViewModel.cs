using FluentValidation;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationPrescriptionFormViewModel : BaseFormViewModel<MedicationPrescriptionDto, MedicationPrescriptionFormViewModel>
    {
        #region Properties
        #endregion

        public MedicationPrescriptionFormViewModel(IValidator<MedicationPrescriptionFormViewModel> validator) : base(validator)
        {
        }

        public override Task LoadDataAsync()
        {
            throw new NotImplementedException();
        }

        protected override void Clear()
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> CreateAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task<bool> ModifyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
