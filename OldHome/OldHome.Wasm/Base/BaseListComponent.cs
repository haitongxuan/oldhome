using Microsoft.AspNetCore.Components;
using OldHome.DTO.Base;

namespace OldHome.Wasm.Base
{
    public abstract class BaseListComponent<T> : AntDomComponentBase
        where T : BaseDto
    {

        [Inject] public API.ApiManager ApiManager { get; set; }
        [Inject] public IMessageService Message { get; set; }
        protected List<T> _items;
        protected bool _loading = false;

        protected abstract Func<Task<BaseResponse<List<T>>>> GetAllFunc { get; }
        protected abstract Func<int, Task<BaseResponse>> DeleteFunc { get; }


        protected async Task LoadData()
        {
            try
            {
                _loading = true;
                var res = await GetAllFunc();
                if (res.IsSuccess)
                {
                    _items = res.Data;
                }
                else
                {
                    // Handle error, e.g., show a notification
                    Console.WriteLine($"Error fetching items: {res.Message}");
                }
                _loading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }
        }
    }
}
