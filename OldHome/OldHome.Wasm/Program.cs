using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using OldHome.API;
using OldHome.API.Services;
using OldHome.DTO;
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
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5185/"); // ÄúµÄAPIµØÖ·
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            builder.Services.AddKeyedScoped("localClient", (sp, key) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
          
            builder.Services.AddInteractiveStringLocalizer();
            builder.Services.AddLocalization();

            builder.Services
                .AddAuthorizationCore()
                .AddScoped<IAccountService, AccountService>()
                .AddSingleton<IUserSessionService, UserSessionService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IProjectService, ProjectService>()
                .AddTransient<AuthorizationMessageHandler>()
                .AddScoped(sp =>
                {
                    var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
                    var httpClient = httpClientFactory.CreateClient("ApiClient");
                    var userSessionService = sp.GetRequiredService<IUserSessionService>();
                    var jsRuntime = sp.GetRequiredService<IJSRuntime>();
                    var navigationManager = sp.GetRequiredService<NavigationManager>();

                    return new ApiClient(httpClient, userSessionService, jsRuntime, navigationManager);
                })
                .AddScoped<IApiClient>(sp => sp.GetRequiredService<ApiClient>())
                .AddSingleton<NavigationContainer>()
                .AddScoped<ApiManager>()
                .AddScoped<AppAuthStateProvider>()
                .AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<AppAuthStateProvider>());

            var app = builder.Build();
            var authStateProvider = app.Services.GetRequiredService<AuthenticationStateProvider>();
            await authStateProvider.GetAuthenticationStateAsync();

            await app.RunAsync();
        }

    }
}