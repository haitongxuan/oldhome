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
    public class FormRoleViewModel : BaseFormViewModel<RoleDto, FormRoleViewModel>
    {
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
                ValidateProperty(nameof(Name));
            }
        }

        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                SetProperty(ref _code, value);
                ValidateProperty(nameof(Name));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { SetProperty(ref _createAt, value); }
        }
        #endregion

        public FormRoleViewModel(IValidator<FormRoleViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            Name = string.Empty;
            Code = string.Empty;
            Description = string.Empty;
            CreateAt = null;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.RoleApi.CreateRole(new()
            {
                Name = Name,
                Code = Code,
                Description = Description
            }), head: "权限");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.RoleApi.CreateRole(new() {
                Id = Id.Value,
                Name = Name,
                Code = Code,
                Description = Description
            }),head:"权限");
        }

        public override async Task ChangeState(RoleDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                Code = detail.Code;
                Description = detail.Description;
                CreateAt = detail.CreatedAt;
            }
            else
            {
                Id = null;
                Name = string.Empty;
                Code = string.Empty;
                Description = string.Empty;
                CreateAt = null;
            }
        }
    }

    public class FormRoleViewModelValidator : AbstractValidator<FormRoleViewModel>
    {
        public FormRoleViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("权限名称必填！")
                .Length(1, 50).WithMessage("Name must be between 1 and 50 characters.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code is required.")
                .Length(1, 20).WithMessage("Code must be between 1 and 20 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(300).WithMessage("Description cannot exceed 300 characters.");
        }
    }
}
