using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class DepartmentFormViewModelValidator : AbstractValidator<DepartmentFormViewModel>
    {
        public DepartmentFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("部门名称不能为空");
        }
    }
}
