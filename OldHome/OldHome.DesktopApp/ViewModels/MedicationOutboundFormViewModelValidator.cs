using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace OldHome.DesktopApp.ViewModels
    {
        public class MedicationOutboundFormViewModelValidator : AbstractValidator<MedicationOutboundFormViewModel>
        {
            public MedicationOutboundFormViewModelValidator()
            {
                RuleFor(x => x.OutboundDate)
                    .NotNull().WithMessage("发药日期不能为空");

                RuleFor(x => x.SelectedMedicineTime)
                    .NotNull().WithMessage("请选择发药时间段");

                RuleFor(x => x.SelectedOutboundType)
                    .NotNull().WithMessage("请选择发药类型");

                RuleFor(x => x.SelectedPharmacist)
                    .NotNull().WithMessage("请选择发药护士");

                RuleFor(x => x.SelectedStatus)
                    .NotNull().WithMessage("请选择出库状态");

                RuleFor(x => x.PreparedTime)
                    .NotNull().WithMessage("创建时间不能为空");

                RuleFor(x => x.TotalItemCount)
                    .GreaterThanOrEqualTo(0).WithMessage("总药品数量不能为负数");

                RuleFor(x => x.TotalAmount)
                    .GreaterThanOrEqualTo(0).WithMessage("总金额不能为负数");
            }
        }
    }
}
