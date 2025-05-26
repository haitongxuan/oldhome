using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class RoomFormViewModelValidator : AbstractValidator<RoomFormViewModel>
    {
        public RoomFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("房间编号不能为空")
                .Length(1, 50)
                .WithMessage("房间编号长度必须在1到50个字符之间");
            RuleFor(x => x.SelectedRoomType)
                .NotNull()
                .WithMessage("请选择房间类型");
            RuleFor(x => x.SelectedOrgAreaId)
                .NotNull()
                .WithMessage("请选择房间所在区域");
            RuleFor(x => x.SelectedFloor)
                .NotNull()
                .WithMessage("请选择房间所在楼层");
            RuleFor(x => x.BedCount)
                .NotNull()
                .WithMessage("请填写床位数")
                .GreaterThan(0)
                .WithMessage("床位数必须大于0");
            RuleFor(x => x.FreeBedCount)
                .NotNull()
                .WithMessage("请填写空床位数")
                .GreaterThanOrEqualTo(0)
                .WithMessage("空床位数必须大于等于0");
        }
    }
}
