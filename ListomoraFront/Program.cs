using Blazored.LocalStorage;
using ListomoraFront.Services;
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

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddScoped<JwtHandler>();

            builder.Services.AddHttpClient("MyAPI", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl"));
            })
            .AddHttpMessageHandler<JwtHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MyAPI"));
            //builder.Services.AddHttpClient<ArticleAPIClient>().AddHttpMessageHandler<JwtHandler>();
            //builder.Services.AddHttpClient<AuthAPIClient>().AddHttpMessageHandler<JwtHandler>();
            //builder.Services.AddHttpClient<UserAPIClient>().AddHttpMessageHandler<JwtHandler>();

            builder.Services.AddScoped<IArticleService, ArticleAPIClient>();
            builder.Services.AddScoped<IAuthService, AuthAPIClient>();
            builder.Services.AddScoped<IUserService, UserAPIClient>();

            // demander pour savoir utiliser builder.HostEnvironment
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
