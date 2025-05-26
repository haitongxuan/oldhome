using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class EmergencyContactFormViewModelValidator : AbstractValidator<EmergencyContactFormViewModel>
    {
        public EmergencyContactFormViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("姓名不能为空")
                .Length(1, 50)
                .WithMessage("姓名长度必须在1到50个字符之间");
            RuleFor(x => x.PhoneNum)
                .NotEmpty()
                .WithMessage("电话号码不能为空")
                .Matches(@"^\d{10,15}$")
                .WithMessage("电话号码必须是10到15位数字");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("居住地址不能为空");
        }
    }
}
