using FluentValidation;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    public class DepartmentFormViewModel : BaseFormViewModel<DepartmentDto, DepartmentFormViewModel>
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }
        #endregion

        public DepartmentFormViewModel(IValidator<DepartmentFormViewModel> validator) : base(validator)
        {
        }

        public override async Task LoadDataAsync()
        {
            await Task.CompletedTask;
        }

        protected override void Clear()
        {
            Name = string.Empty;
        }

        protected override async Task<bool> CreateAsync()
        {
            return await ValidateAndRunAsync(async () =>
             await _api.DepartmentApi.CreateDepartment(new DepartmentCreate { Name = this.Name }), head: "部门");
        }

        protected override async Task<bool> ModifyAsync()
        {
            return await ValidateAndRunAsync(async () => await _api.DepartmentApi.ModifyDepartment(new DepartmentModify { Id = this.Id!.Value, Name = this.Name })
            , head: "部门");
        }

        public override async Task ChangeState(DepartmentDto detail, FormState state)
        {
            await base.ChangeState(detail, state);
            if (detail != null)
            {
                Id = detail.Id;
                Name = detail.Name;
                Description = detail.Description;
                CreatedAt = detail.CreatedAt;
            }
            else
            {
                Clear();
            }
        }
    }
}
