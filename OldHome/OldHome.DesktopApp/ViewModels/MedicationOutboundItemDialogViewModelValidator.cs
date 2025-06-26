using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicationOutboundItemDialogViewModelValidator : AbstractValidator<MedicationOutboundItemDialogViewModel>
    {
        public MedicationOutboundItemDialogViewModelValidator()
        {
            RuleFor(x => x.SelectedResident)
                .NotNull().WithMessage("请选择住户");

            RuleFor(x => x.SelectedMedicine)
                .NotNull().WithMessage("请选择药品");

            RuleFor(x => x.PlannedQuantity)
                .NotNull().WithMessage("计划用量不能为空")
                .GreaterThan(0).WithMessage("计划用量必须大于0");

            RuleFor(x => x.ActualQuantity)
                .NotNull().WithMessage("实际出库量不能为空")
                .GreaterThan(0).WithMessage("实际出库量必须大于0");


            RuleFor(x => x.ExpirationDate)
                .NotNull().WithMessage("有效期不能为空")
                .GreaterThan(DateTime.Now).WithMessage("有效期不能早于当前时间");

            RuleFor(x => x.SelectedDispenseStatus)
                .NotNull().WithMessage("请选择发药状态");

            RuleFor(x => x.Instructions)
                .MaximumLength(500).WithMessage("用药说明长度不能超过500个字符");

            RuleFor(x => x.SpecialInstructions)
                .MaximumLength(500).WithMessage("特殊说明长度不能超过500个字符");
        }
    }
}