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
    [Navigation("Setting$fileinputname$s", "Setting$fileinputname$s", "$fileinputname$管理", "Group", IsDefault = true, Icon = "e93b")]
    public class $fileinputname$PagedListViewModel : BasePagedListViewModel<$fileinputname$Dto, $fileinputname$FormViewModel>
    {
        public $fileinputname$PagedListViewModel($fileinputname$FormViewModel formViewModel) : base(formViewModel)
        {
        }

        protected override Func<int, int, Task<BaseResponse<PagedResult<$fileinputname$Dto>>>> GetPagedFunc => throw new NotImplementedException();

        protected override Func<Task<BaseResponse>> DeleteFunc => throw new NotImplementedException();
    }
}
