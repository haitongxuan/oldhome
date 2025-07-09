using AntDesign.TableModels;
using Microsoft.AspNetCore.Components;
using OldHome.DTO;
using OldHome.DTO.Base;

namespace OldHome.Wasm.Base
{
    public abstract class BaseListComponent<T> : AntDomComponentBase
        where T : BaseDto, new()

    {

        [Inject] public API.ApiManager ApiManager { get; set; }
        [Inject] public IMessageService Message { get; set; }
        [Inject] public ConfirmService ComfirmService { get; set; }
        [Inject] public ModalService ModalService { get; set; }
        protected List<T> _items;
        protected bool _loading = false;

        protected abstract string Title { get; }

        protected abstract Func<Task<BaseResponse<List<T>>>> GetAllFunc { get; }
        protected abstract Func<int, Task<BaseResponse>> DeleteFunc { get; }

        protected ITable _table;

        protected void StartEdit(T? row)
        {
            var data = row == null ? new() : row;
            ModalRef<bool> modalRef = default;
            IForm form = default;
            modalRef = ModalService.CreateModal<bool>(new ModalOptions()
            {
                Title = data.Id > 0 ? "编辑机构" : "新增机构",
                Content = GetModalContent(form, data, modalRef),
                OnOk = async (e) =>
                {
                    if (!form.Validate())
                    {
                        return;
                    }

                    // save db and refresh
                    modalRef.SetConfirmLoading(true);

                    if (data.Id > 0)
                    {
                        var res = await Modify(data);
                    }
                    else
                    {
                        var res = await Create(data);
                    }

                    await modalRef.CloseAsync();
                    _table.ReloadData();
                    StateHasChanged();
                },
                OnCancel = async (e) =>
                {
                    try
                    {
                        if (form.IsModified)
                        {
                            if (!await Comfirm("表单已修改，是否离开?"))
                                return;
                            else
                                _table.ReloadData();
                        }
                        else
                        {
                            await modalRef.CloseAsync();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            });
        }

        protected abstract Task<BaseResponse> Modify(T model);
        protected abstract Task<BaseResponse<T>> Create(T model);
        protected abstract RenderFragment GetModalContent(IForm form, T? data, ModalRef<bool> modalRef);

        protected async Task Delete(T row)
        {
            await DeleteFunc.Invoke(row.Id);
            _table.ReloadData();
        }


        protected async Task<bool> Comfirm(string message)
        {
            return await ComfirmService.Show(message, "请确认", ConfirmButtons.YesNo, ConfirmIcon.Warning) == ConfirmResult.Yes;
        }

        protected async Task HandleTableChange(QueryModel<T> queryModel)
        {
            await LoadData();
        }

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
