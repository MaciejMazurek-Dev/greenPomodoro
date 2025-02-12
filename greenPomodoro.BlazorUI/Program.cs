using Blazored.LocalStorage;
using greenPomodoro.BlazorUI.Contracts;
using greenPomodoro.BlazorUI.Providers;
using greenPomodoro.BlazorUI.Services;
using greenPomodoro.BlazorUI.Services.BaseHttpClient;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace greenPomodoro.BlazorUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddAuthorizationCore();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            
            builder.Services.AddScoped<BaseHttpService>();
            builder.Services.AddHttpClient<IClient, Client>((client) =>
            {
                // TODO: Retrieve the access token from local storage and include it in the Authorization header of every request.
                client.DefaultRequestHeaders.Add("Authorization", "placeForJWTAccessToken");

                // TODO: Provide the URI from the configuration file.
                client.BaseAddress = new Uri("http://localhost:5100");
            });

            builder.Services.AddScoped<IPomodoroTaskService, PomodoroTaskService>();
            builder.Services.AddScoped<IAuthService, AuthService>();

            await builder.Build().RunAsync();
        }
    }
}
