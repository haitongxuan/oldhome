using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OldHome.API;
using OldHome.API.Services;
using OldHome.Wasm.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OldHome.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            builder.Services
                .AddScoped<IAccountService, AccountService>()
                .AddSingleton<IApiClient>((sp) =>
                {
                    return new ApiClient(new HttpClient()
                    {
                        BaseAddress = new Uri("http://localhost:5185")
                    });
                })
                .AddScoped<ApiManager>();

            await builder.Build().RunAsync();
        }
    }
}