using OldHome.DesktopApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OldHome.DesktopApp.Views
{
    public class BaseUserControl : UserControl
    {
        public BaseUserControl()
        {
            Loaded += (s, e) =>
            {
                // 避免设计器模式下执行运行时逻辑
                if (DesignerProperties.GetIsInDesignMode(this))
                    return;

                if (DataContext is BaseViewModel vm)
                {
                    vm.LoadedCommand?.Execute(null);
                }
            };
        }
    }
}
