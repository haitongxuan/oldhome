using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class OrgAreaFormViewModelValidator : AbstractValidator<OrgAreaFormViewModel>
    {
        public OrgAreaFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("区域名称不能为空")
                .Length(1, 150)
                .WithMessage("区域名称长度必须在1到150个字符之间");
            RuleFor(x => x.FloorMin)
                .NotEmpty()
                .WithMessage("最低楼层不能为空")
                .GreaterThan(0)
                .WithMessage("最低楼层不能小于0");
            RuleFor(x => x.FloorMax)
                .NotEmpty()
                .WithMessage("最高楼层不能为空")
                .GreaterThan(0)
                .WithMessage("最高楼层不能小于0");
        }
    }
}
