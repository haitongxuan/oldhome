using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class BedFormViewModelValidator : AbstractValidator<BedFormViewModel>
    {
        public BedFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(p => p.BedNum)
                .NotEmpty()
                .WithMessage("床位号不能为空")
                .Length(1, 20)
                .WithMessage("床位号长度必须在1到20个字符之间");
            RuleFor(p => p.SelectedOrgAreaId)
                .NotNull()
                .WithMessage("请选择所在区域");
            RuleFor(p => p.SelectedFloor)
                .NotNull()
                .WithMessage("请选择所在楼层");
            RuleFor(p => p.SelectedRoomId)
                .NotNull()
                .WithMessage("请选择所在房间");
            RuleFor(p => p.SelectedBedStatus)
                .NotNull()
                .WithMessage("请选择床位状态");

        }
    }
}
