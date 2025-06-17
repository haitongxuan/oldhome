using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using OldHome.DTO.Base;
using System.Collections;
using System.ComponentModel;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseFormViewModel<T, TSelf> : BaseViewModel, INotifyDataErrorInfo
        where T : BaseDto
        where TSelf : BaseFormViewModel<T, TSelf>
    {
        public int? Id { get; set; } = null;

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { SetProperty(ref _createdAt, value); }
        }

        public event EventHandler? FormClosing;

        protected readonly IValidator<TSelf> _validator;
        private readonly Dictionary<string, List<string>> _errors = new();
        public BaseFormViewModel(IValidator<TSelf> validator)
        {
            _validator = validator;
        }

        private FormState _state = FormState.Edit;
        public FormState State
        {
            get { return _state; }
            set { SetProperty(ref _state, value); }
        }

        public virtual async Task ChangeState(T detail, FormState state)
        {
            State = state;
            if (detail != null && (state.Equals(FormState.Edit) || state.Equals(FormState.View)))
            {
                Id = detail.Id;
                CreatedAt = detail.CreatedAt;
            }
            else
                CreatedAt = null;
            await Task.CompletedTask;
        }

        protected virtual async Task SaveAsync()
        {
            bool res = false;
            if (State.Equals(FormState.Create))
            {
                res = await CreateAsync();
            }
            else if (State.Equals(FormState.Edit))
            {
                res = await ModifyAsync();
            }
            if (res)
                this.FormClosing?.Invoke(this, EventArgs.Empty);
        }

        private AsyncDelegateCommand _save;

        public AsyncDelegateCommand SaveCommand =>
            _save ?? (_save = new AsyncDelegateCommand(ExecuteSaveCommand));


        async Task ExecuteSaveCommand()
        {
            await SaveAsync();
        }

        private DelegateCommand _clear;
        private IValidator<FormUserViewModel> validator;

        public DelegateCommand ClearCommand =>
            _clear ?? (_clear = new DelegateCommand(ExecuteClearCommand));

        void ExecuteClearCommand()
        {
            Clear();
            this.FormClosing?.Invoke(this, EventArgs.Empty);
        }


        protected abstract Task<bool> CreateAsync();
        protected abstract Task<bool> ModifyAsync();
        protected abstract void Clear();

        protected async Task<ValidationResult> ValidationAsync()
        {
            var res = await _validator.ValidateAsync((TSelf)this);
            return res;
        }

        // 验证单个属性
        protected async void ValidateProperty(string propertyName)
        {
            var context = new ValidationContext<BaseFormViewModel<T, TSelf>>
                (this, new PropertyChain(), new MemberNameValidatorSelector(new[] { propertyName }));

            var result = await _validator.ValidateAsync(context);

            if (result.IsValid)
            {
                ClearErrors(propertyName);
            }
            else
            {
                SetErrors(propertyName, result.Errors.Select(e => e.ErrorMessage));
            }
        }

        private void SetErrors(string propertyName, IEnumerable<string> errors)
        {
            _errors[propertyName] = new List<string>(errors);
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(string propertyName)
        {
            if (_errors.Remove(propertyName))
            {
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public bool HasErrors => _errors.Any();
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.SelectMany(e => e.Value);

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        protected void ShowMessage(BaseResponse response, string successMsg)
        {
            if (response.IsSuccess)
            {
                _notificationUIService.ShowSuccess(successMsg);
            }
            else
            {
                _notificationUIService.ShowError(response.Message);
            }
        }
        protected void ShowMessage(BaseResponse<T> response, string? successMsg = null, string? failMsg = null, string? head = null)
        {
            if (response.IsSuccess)
            {
                if (successMsg is not null)
                    _notificationUIService.ShowSuccess(successMsg);
                else if (head is not null)
                    _notificationUIService.ShowSuccess($"创建{head}成功");
                else
                    _notificationUIService.ShowSuccess("创建成功");
                Clear();
            }
            else
            {
                if (failMsg is not null)
                {
                    _notificationUIService.ShowError($"{failMsg},失败原因:{response.Message}");
                }
                else if (head is not null)
                {
                    _notificationUIService.ShowError($"创建{head}失败,失败原因:{response.Message}");
                }
                else
                {
                    _notificationUIService.ShowError($"创建失败,失败原因:{response.Message}");
                }
            }
        }
        protected void ShowMessage(BaseResponse response, string? successMsg = null, string? failMsg = null, string? head = null)
        {
            if (response.IsSuccess)
            {
                if (successMsg is not null)
                    _notificationUIService.ShowSuccess(successMsg);
                else if (head is not null)
                    _notificationUIService.ShowSuccess($"创建{head}成功");
                else
                    _notificationUIService.ShowSuccess("创建成功");
                Clear();
            }
            else
            {
                if (failMsg is not null)
                {
                    _notificationUIService.ShowError($"{failMsg},失败原因:{response.Message}");
                }
                else if (head is not null)
                {
                    _notificationUIService.ShowError($"创建{head}失败,失败原因:{response.Message}");
                }
                else
                {
                    _notificationUIService.ShowError($"创建失败,失败原因:{response.Message}");
                }
            }
        }

        protected async Task<bool> ValidateAndRunAsync(Func<Task<BaseResponse>> action, string? successMsg = null, string? failMsg = null, string? head = null)
        {
            var result = await ValidationAsync();
            if (result.IsValid)
            {
                var resp = await action();
                ShowMessage(resp, successMsg, failMsg, head);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected async Task<bool> ValidateAndRunAsync(Func<Task<BaseResponse<T>>> action, string? successMsg = null, string? failMsg = null, string? head = null)
        {
            var result = await ValidationAsync();
            if (result.IsValid)
            {
                var resp = await action();
                ShowMessage(resp, successMsg, failMsg, head);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
