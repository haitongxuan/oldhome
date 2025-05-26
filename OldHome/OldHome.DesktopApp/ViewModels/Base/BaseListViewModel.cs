using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseListViewModel<T, F> : BaseViewModel where T : BaseDto where F : BaseFormViewModel<T, F>
    {
        public BaseListViewModel(F formViewModel)
        {
            FormViewModel = formViewModel;
            FormViewModel.FormClosing += FormViewModel_FormClosing;
        }

        private List<T> _items = new List<T>();
        public List<T> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private T _selectedItem;
        public T SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        private bool _isOpen = false;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { SetProperty(ref _isOpen, value); }
        }

        private async void FormViewModel_FormClosing(object? sender, EventArgs e)
        {
            this.IsOpen = false;
            await LoadDataAsync();
        }

        private F _formViewModel;
        public F FormViewModel
        {
            get { return _formViewModel; }
            set
            {
                SetProperty(ref _formViewModel, value);
            }
        }

        private DelegateCommand _edit;
        public DelegateCommand EditCommand =>
            _edit ?? (_edit = new DelegateCommand(ExecuteEditCommand));

        void ExecuteEditCommand()
        {
            if (SelectedItem == null)
                return;
            IsOpen = true;
            FormViewModel.ChangeState(SelectedItem, FormState.Edit);
        }

        private DelegateCommand _viewDetail;
        public DelegateCommand ViewDetailCommand =>
            _viewDetail ?? (_viewDetail = new DelegateCommand(ExecuteViewDetailCommand));

        void ExecuteViewDetailCommand()
        {
            if (SelectedItem == null)
                return;
            IsOpen = true;
            FormViewModel.ChangeState(SelectedItem, FormState.View);
        }

        private DelegateCommand _hideForm;
        public DelegateCommand HideFormCommand =>
            _hideForm ?? (_hideForm = new DelegateCommand(ExecuteHideFormCommand));

        void ExecuteHideFormCommand()
        {
            IsOpen = false;
        }

        private DelegateCommand _add;
        public DelegateCommand AddCommand =>
            _add ?? (_add = new DelegateCommand(ExecuteAddCommand));

        void ExecuteAddCommand()
        {
            IsOpen = true;
            FormViewModel.ChangeState(null, FormState.Create);
        }

        private AsyncDelegateCommand _delete;
        public AsyncDelegateCommand DeleteCommand =>
            _delete ?? (_delete = new AsyncDelegateCommand(ExecuteDeleteCommand));

        async Task ExecuteDeleteCommand()
        {
            try
            {
                if (SelectedItem is null) return;
                var resp = await DeleteFunc();
                if (resp.IsSuccess)
                {
                    _notificationUIService.ShowInformation("删除成功");
                    await LoadDataAsync();
                }
                else
                {
                    _notificationUIService.ShowWarning($"删除失败:{resp.Message ?? string.Empty}");
                }
            }
            catch (Exception ex)
            {
                _notificationUIService.ShowError(ex.Message);
            }
        }

        public override async Task LoadDataAsync()
        {
            try
            {
                var resp = await GetAllFunc();
                resp.CallbackAction(ResponseCallback);
            }
            catch (Exception ex)
            {
                _notificationUIService.ShowError(ex.Message);
            }
        }

        protected abstract Func<Task<BaseResponse<List<T>>>> GetAllFunc { get; }
        protected abstract Func<Task<BaseResponse>> DeleteFunc { get; }
        public virtual void ResponseCallback(BaseResponse<List<T>> resp)
        {
            if (resp != null && resp.Data != null)
            {
                if (resp.IsSuccess)
                {
                    Items = resp.Data;
                }
                else
                {
                    _notificationUIService.ShowWarning($"获取数据异常:{resp.Message ?? string.Empty}");
                }
            }
        }
    }
}
