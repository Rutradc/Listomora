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

            builder.Services.AddHttpClient("ListomoraAPI", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseUrl"));
            })
            .AddHttpMessageHandler<JwtHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ListomoraAPI"));

            builder.Services.AddScoped<IArticleService, ArticleAPIClient>();
            builder.Services.AddScoped<IAuthService, AuthAPIClient>();
            builder.Services.AddScoped<IUserService, UserAPIClient>();

            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
