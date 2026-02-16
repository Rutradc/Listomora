using Blazored.LocalStorage;
using ListomoraFront.Services;
using ListomoraFront.Services.Implementations;
using ListomoraFront.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;

namespace ListomoraFront
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped<IncludeCredentialsHandler>();

            builder.Services.AddHttpClient<ArticleAPIClient>().AddHttpMessageHandler<IncludeCredentialsHandler>();
            builder.Services.AddHttpClient<AuthAPIClient>().AddHttpMessageHandler<IncludeCredentialsHandler>();
            builder.Services.AddHttpClient<UserAPIClient>().AddHttpMessageHandler<IncludeCredentialsHandler>();

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
