using Blazored.LocalStorage;
using ListomoraFront.Services.Implementations;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ListomoraFront
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient<ArticleAPIClient>();
            builder.Services.AddHttpClient<AuthAPIClient>();
            builder.Services.AddHttpClient<UserAPIClient>();

            builder.Services.AddSingleton<IArticleService, ArticleAPIClient>();
            builder.Services.AddSingleton<IAuthService, AuthAPIClient>();
            builder.Services.AddSingleton<IUserService, UserAPIClient>();

            builder.Services.AddBlazoredLocalStorage();
            // gestion d'un jwthandler


            // demander pour savoir utiliser builder.HostEnvironment
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
