using CqrsV1.Application.ApplicationServices.V1.OrderAppService.Queries;
using CqrsV1.Application.BuildingBlocks.DbContext;
using CqrsV1.DomainShared.BuildingBlocks.CqrsCore;
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
                options.UseNpgsql(readonlyConnectionString);
            });

            services.AddTransient<ICqrsApplicationDbContext>(provider => provider.GetService<CqrsApplicationDbContext>() ?? throw new ArgumentNullException(nameof(CqrsApplicationDbContext)));

            services.AddTransient<ICqrsReadonlyDbContext>(provider => provider.GetService<CqrsReadonlyDbContext>() ?? throw new ArgumentNullException(nameof(CqrsReadonlyDbContext)));

            services.AddQueryHandler<GetOrderByIdQuery, OrderViewModel, GetOrderByIdQueryHandler>();
                
            return services;
        }
    }
}

