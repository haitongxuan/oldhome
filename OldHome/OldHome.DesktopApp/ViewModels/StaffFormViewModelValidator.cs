using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class StaffFormViewModelValidator : AbstractValidator<StaffFormViewModel>
    {
        public StaffFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("姓名必填.");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("电话号码必填.")
                .Matches(@"^\d{11}$")
                .WithMessage("电话号码是11位数字.");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("出生日期必填.");
            RuleFor(x => x.SelectedGender)
                .NotEmpty()
                .WithMessage("性别必填.");
            RuleFor(x => x.SelectedPosition)
                .NotEmpty()
                .WithMessage("职位必填.");
            RuleFor(x => x.SelectedDepartmentId)
                .NotEmpty()
                .WithMessage("部门必填.");
            RuleFor(x => x.HireDate)
                .NotEmpty()
                .WithMessage("入职日期必填.");
        }
    }
}
