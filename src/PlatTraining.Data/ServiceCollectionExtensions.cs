using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatTraining.Data.DbContexts;
using PlatTraining.Data.Hubs;
using System.Diagnostics;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterHubs(this IServiceCollection services)
        {
            services.AddScoped<MasterHub>();
            services.AddScoped<TenantHub>();
            return services;
        }

        public static IServiceCollection AddPlatTenantDbContext(this IServiceCollection services)
        {
            services.AddDbContext<PlatTenantDbContext>();

            return services;
        }

        public static async Task MigratePlatTenantDbContextAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var masterDbContext = serviceScope.ServiceProvider.GetRequiredService<PlatMasterDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<PlatTenantDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            var tenants = await masterDbContext.Tenants.ToListAsync();
            foreach (var tenant in tenants)
            {
                var tenantDbContext = PlatTenantDbContext.CreatePlatTenantDbContext(tenant.ConnectionString); ;
                await tenantDbContext.Database.MigrateAsync();
            }
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }

        public static IServiceCollection AddPlatMasterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlatMasterDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }

        public static async Task MigratePlatMasterDbContextAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<PlatMasterDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<PlatMasterDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            await dbContext.Database.MigrateAsync();
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }
    }
}
