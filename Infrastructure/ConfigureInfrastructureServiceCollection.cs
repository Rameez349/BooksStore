using Application.Services;
using Infrastructure.Contexts;
using Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ConfigureInfrastructureServiceCollection
    {
        public static void ConfigureDataBaseServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<BooksStoreDbContext>();
            services.AddScoped<IBooksStoreDbContext, BooksStoreDbContext>();
            services.Configure<DbOptions>(opt => config.GetSection(DbOptions.Key).Bind(opt));
        }
    }
}
