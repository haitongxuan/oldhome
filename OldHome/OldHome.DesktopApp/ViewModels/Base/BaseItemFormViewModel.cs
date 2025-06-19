using FluentValidation;
using OldHome.DesktopApp.Views.Windows;
using OldHome.DTO;
using OldHome.DTO.Base;
using Panuon.WPF.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseItemFormViewModel<T, TSelf, TItem> : BaseFormViewModel<T, TSelf>
        where T : BaseDto
        where TSelf : BaseItemFormViewModel<T, TSelf, TItem>
        where TItem : BaseDto
    {
        protected readonly IDialogService _dialogService;

        protected abstract string DialogName { get; }
        protected abstract Func<TItem, string> DeleteItemMessage { get; }

        private TItem _selectedItem;
        public TItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        public ObservableCollection<TItem> Items { get; set; } = new ObservableCollection<TItem>();

        private DelegateCommand _viewItem;
        public DelegateCommand ViewItemCommand =>
            _viewItem ?? (_viewItem = new DelegateCommand(ExecuteViewItemCommand));

        void ExecuteViewItemCommand()
        {
            if (SelectedItem == null)
                return;

        }

        private DelegateCommand _addItemCommand;
        public DelegateCommand AddItemCommand =>
            _addItemCommand ?? (_addItemCommand = new DelegateCommand(ExecuteAddItemCommand));

        void ExecuteAddItemCommand()
        {
            DialogParameters parameters = new DialogParameters
            {
                { "State", FormState.Create }
            };
            _dialogService.Show(DialogName, parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    var item = result.Parameters.GetValue<TItem>("Item");
                    Items.Add(item);
                }
            }, nameof(CustomDialogWindow));
        }

        private DelegateCommand<TItem> _editItem;
        public DelegateCommand<TItem> EditItemCommand =>
            _editItem ?? (_editItem = new DelegateCommand<TItem>(ExecuteEditItemCommand));

        void ExecuteEditItemCommand(TItem parameter)
        {
            DialogParameters parameters = new DialogParameters
            {
                { "State", FormState.Edit },
                { "Index", Items.IndexOf(parameter) },
                { "Item", parameter   }
            };
            _dialogService.Show(DialogName, parameters, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    var item = result.Parameters.GetValue<TItem>("Item");
                    int index = result.Parameters.GetValue<int>("Index");
                    Items[index] = item;
                }
            }, nameof(CustomDialogWindow));
        }

        private DelegateCommand<TItem> _deleteItem;
        public DelegateCommand<TItem> DeleteItemCommand =>
            _deleteItem ?? (_deleteItem = new DelegateCommand<TItem>(ExecuteDeleteItemCommand));

        void ExecuteDeleteItemCommand(TItem parameter)
        {
            var message = $"确定要删除{this.DeleteItemMessage(parameter)} 吗？";
            var result = MessageBoxX.Show(
                Application.Current.MainWindow,
                message,
                "删除确认", MessageBoxButton.OKCancel, MessageBoxIcon.Question, DefaultButton.CancelNo, 10);
            if (result == MessageBoxResult.OK)
            {
                Items.Remove(parameter);
            }
        }

        public BaseItemFormViewModel(IValidator<TSelf> validator, IDialogService dialogService) : base(validator)
        {
            _dialogService = dialogService;
        }
    }
}
