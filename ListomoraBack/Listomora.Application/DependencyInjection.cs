using Listomora.API.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Listomora.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<CreationTokenService>();
            return services;
        }
    }
}
