using FluentValidation;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels.Base
{
    public abstract class BaseItemFormViewModel<T, TSelf, TItem> : BaseFormViewModel<T, TSelf>
        where T : BaseDto
        where TSelf : BaseItemFormViewModel<T, TSelf, TItem>
        where TItem : BaseDto
    {
        private TItem _selectedItem;
        public TItem SelectedItem
        {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        

        private DelegateCommand _viewItem;
        public DelegateCommand ViewItemCommand =>
            _viewItem ?? (_viewItem = new DelegateCommand(ExecuteViewItemCommand));

        void ExecuteViewItemCommand()
        {
            if (SelectedItem == null)
                return;
            
        }

        protected BaseItemFormViewModel(IValidator<TSelf> validator) : base(validator)
        {
        }
    }
}
