using Listomora.Application.Contracts.Persistence.Repositories;
using Listomora.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Listomora.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO : ajouter injections pour infrastructure
            services.AddDbContext<ListomoraDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Listomora.EntityFramework")));

            services.AddScoped<IUserRepo, SqlUserRepo>();
            services.AddScoped<IArticleRepo, SqlArticleRepo>();
            services.AddScoped<IIngredientRepo, SqlIngredientRepo>();
            return services;
        }
    }
}
