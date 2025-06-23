using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class MedicineInventoryFormViewModelValidator : AbstractValidator<MedicineInventoryFormViewModel>
    {
        public MedicineInventoryFormViewModelValidator()
        {
            ///todo : validator rules
            RuleFor(p => p.SelectedMedicine)
                .NotNull()
                .WithMessage("请选择药品");
            RuleFor(p => p.PackageCount)
                .NotNull()
                .WithMessage("请输入入库包装数量");
            RuleFor(p => p.QtyTotal)
                .NotNull()
                .WithMessage("请输入入库数量");
            RuleFor(p => p.QtyRemaining)
                .NotNull()
                .WithMessage("请输入剩余数量");
            RuleFor(p => p.ExpirationDate)
                .NotNull()
                .WithMessage("请输入效期");
            RuleFor(p => p.SelectedStatus)
                .NotNull()
                .WithMessage("请选择入库批次状态");
        }
    }
}
