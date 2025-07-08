using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AntDesign;
using OldHome.Wasm.Models;
using OldHome.Wasm.Services;
using OldHome.API;

namespace OldHome.Wasm.Pages.User
{
    public partial class Login
    {
        private readonly LoginParamsType _model = new LoginParamsType();

        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public ApiManager ApiManager { get; set; }
        [SupplyParameterFromQuery] public string? ReturnUrl { get; set; }
        [Inject] public AppAuthStateProvider AuthProvider { get; set; }
        [Inject] public MessageService Message { get; set; }
        private bool _loading = false;

        public async Task HandleSubmit()
        {
            if (_model.OrgId == 0)
            {
                await Message.WarningAsync("请选择组织机构");
                return;
            }

            _loading = true;
            try
            {
                var success = await AuthProvider.LoginAsync(_model.UserName, _model.Password, _model.OrgId!.Value);

                if (success)
                {
                    await Message.SuccessAsync("登录成功");

                    // 导航到返回URL或首页
                    var url = !string.IsNullOrWhiteSpace(ReturnUrl)
                        ? Uri.UnescapeDataString(ReturnUrl)
                        : "/";
                    NavigationManager.NavigateTo(url);
                }
                else
                {
                    await Message.ErrorAsync("用户名或密码错误");
                }
            }
            catch (Exception ex)
            {
                await Message.ErrorAsync($"登录失败: {ex.Message}");
            }
            finally
            {
                _loading = false;
            }
        }
    }
}