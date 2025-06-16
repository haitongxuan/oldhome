using FluentValidation;
using FluentValidation.Internal;
using OldHome.DTO.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseDialogViewModel<T, TSelf> : BindableBase, IDialogAware
        where T : BaseDto
        where TSelf : BaseDialogViewModel<T, TSelf>
    {
        protected abstract string PreTitle { get; }
        public string Title { get; protected set; }
        public int? Id { get; set; } = null;

        private DialogCloseListener _requestClose;
        public DialogCloseListener RequestClose
        {
            get { return _requestClose; }
            set { SetProperty(ref _requestClose, value); }
        }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { SetProperty(ref _createdAt, value); }
        }

        protected readonly IValidator<TSelf> _validator;
        private readonly Dictionary<string, List<string>> _errors = new();
        public BaseDialogViewModel(IValidator<TSelf> validator)
        {
            _validator = validator;
        }

        protected abstract DialogParameters GetDialogParameters();

        private DelegateCommand _ok;
        public DelegateCommand OkCommand =>
            _ok ?? (_ok = new DelegateCommand(ExecuteOkCommand));

        void ExecuteOkCommand()
        {
            var parameters = GetDialogParameters();
            RequestClose.Invoke(parameters, ButtonResult.OK);
        }

        private DelegateCommand _cancel;
        public DelegateCommand CancelCommand =>
            _cancel ?? (_cancel = new DelegateCommand(ExecuteCancleCommand));

        void ExecuteCancleCommand()
        {
            RequestClose.Invoke(ButtonResult.Cancel);
        }

        protected void ChangeTitleByState()
        {
            Title = State switch
            {
                FormState.Create => $"添加{PreTitle}",
                FormState.Edit => $"编辑{PreTitle}",
                FormState.View => $"查看{PreTitle}",
                _ => "未知状态"
            };
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
            ChangeTitleByState();
            if (detail != null && (state.Equals(FormState.Edit) || state.Equals(FormState.View)))
                CreatedAt = detail.CreatedAt;
            else
                CreatedAt = null;
            await Task.CompletedTask;
        }

        // 验证单个属性
        protected async void ValidateProperty(string propertyName)
        {
            var context = new ValidationContext<BaseDialogViewModel<T, TSelf>>
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

        DialogCloseListener IDialogAware.RequestClose => throw new NotImplementedException();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.SelectMany(e => e.Value);

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            State = parameters.GetValue<FormState>("State");
            ChangeTitleByState();

            if (State.Equals(FormState.Edit) || State.Equals(FormState.View))
            {
                SetForm(parameters);
            }
            else
            {
                Id = null;
            }
        }

        protected abstract void SetForm(IDialogParameters parameters);
    }
}
