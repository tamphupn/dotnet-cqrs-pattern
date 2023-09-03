using CqrsV1.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsV1.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DbContextConst.ApplicationDbContext) ?? throw new ArgumentNullException(DbContextConst.ApplicationDbContext);
            var readonlyConnectionString = configuration.GetConnectionString(DbContextConst.ReadonlyDbContext) ?? connectionString; // or in this step, we can throw exception directly, force developer need setup replication database

            services.AddDbContext<CqrsApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddDbContext<CqrsReadonlyDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }
    }
}

