using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AntDesign;
using OldHome.Wasm.Models;
using OldHome.Wasm.Services;

namespace OldHome.Wasm.Pages.User
{
    public partial class Login
    {
        private readonly LoginParamsType _model = new LoginParamsType();

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public IAccountService AccountService { get; set; }

        [Inject] public MessageService Message { get; set; }

        public void HandleSubmit()
        {

        }
    }
}