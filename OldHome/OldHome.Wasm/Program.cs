using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
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

            builder.Services.AddKeyedScoped("localClient", (sp, key) => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5185/")
            });
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
                    var handler = sp.GetRequiredService<AuthorizationMessageHandler>();
                    handler.InnerHandler = new HttpClientHandler();
                    var httpClient = sp.GetRequiredService<HttpClient>();
                    var userSessionService = sp.GetRequiredService<IUserSessionService>();

                    return new ApiClient(httpClient, userSessionService, async () =>
                    {
                        // 这里可以实现刷新Token的逻辑
                        var authProvider = sp.GetRequiredService<AppAuthStateProvider>();
                        var success = await authProvider.RefreshTokenAsync();
                        if (success)
                        {
                            var userSession = sp.GetRequiredService<IUserSessionService>();
                            return new SignInResponse(
                                userSession.Token,
                                userSession.Username,
                                userSession.Role,
                                userSession.OrgId ?? 0
                            );
                        }
                        return null;
                    });
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