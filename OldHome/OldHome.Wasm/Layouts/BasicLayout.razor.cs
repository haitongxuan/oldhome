using AntDesign.Extensions.Localization;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using OldHome.Wasm.Services;
using System.Globalization;
using System.Net.Http.Json;

namespace OldHome.Wasm.Layouts
{
    public partial class BasicLayout : LayoutComponentBase, IDisposable
    {
        private MenuDataItem[] _menuData;

        [Inject] private ReuseTabsService TabService { get; set; }
        [Inject] private NavigationContainer NavigationContainer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var menuData = new List<MenuDataItem>{
                new MenuDataItem
                {
                    Path = "/",
                    Name = "欢迎",
                    Key = "welcome",
                    Icon = "smile",
                }
            };
            NavigationContainer.GetAll().ForEach(p =>
            {
                menuData.Add(p.ToMenuDataItem());
            });
            _menuData = menuData.ToArray();
        }

        void Reload()
        {
            TabService.ReloadPage();
        }

        public void Dispose()
        {

        }

    }
}
