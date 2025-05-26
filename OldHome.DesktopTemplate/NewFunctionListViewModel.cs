using OldHome.DesktopApp.Containers;
using OldHome.DesktopApp.ViewModels.Base;
using OldHome.DTO;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DesktopApp.ViewModels
{
    [Navigation("Setting$fileinputname$", "Setting$fileinputname$", "$fileinputname$管理", "Group", IsDefault = true, Icon = "e93b")]
    public class $fileinputname$ListViewModel : BaseListViewModel<$fileinputname$Dto, $fileinputname$FormViewModel>
    {
        public $fileinputname$ListViewModel($fileinputname$FormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<Task<BaseResponse<List<$fileinputname$Dto>>>> GetAllFunc => throw new NotImplementedException();

        protected override Func<Task<BaseResponse>> DeleteFunc => throw new NotImplementedException();
    }
}
