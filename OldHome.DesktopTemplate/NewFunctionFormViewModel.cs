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
    public class $fileinputname$FormViewModel : BaseFormViewModel<$fileinputname$Dto, $fileinputname$FormViewModel>
    {
        #region Properties
        #endregion

        public $fileinputname$FormViewModel(IValidator<$fileinputname$FormViewModel> validator) : base(validator)
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

        protected override Task CreateAsync()
        {
            throw new NotImplementedException();
        }

        protected override Task ModifyAsync()
        {
            throw new NotImplementedException();
        }
    }
}
