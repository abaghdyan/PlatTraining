using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatTraining.Data.Helpers;
using PlatTraining.Data.MasterUnit;
using PlatTraining.Data.Models;
using PlatTraining.Data.Services;
using PlatTraining.Data.TenantUnit;
using System.Diagnostics;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy(this IServiceCollection services)
        {
            services.AddScoped<TenantInfo>();
            services.AddScoped<ITenantResolver, TenantResolver>();

            return services;
        }

        public static IServiceCollection AddPlatTenantDbContext(this IServiceCollection services)
        {
            //var tenant88 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=88tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //var tenant99 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=99tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //
            //services.AddDbContext<PlatTenantDbContext>(options =>
            //{
            //    options.UseSqlServer(tenant88);
            //});

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
            var tenants = await masterDbContext.Tenants.Include(t => t.TenantConnectionInfo).ToListAsync();
            foreach (var tenant in tenants)
            {
                var tenantInfo = new TenantInfo().InitiateForScope(tenant.Id, tenant.Name,
                    ConnectionHelper.GetConnectionBuilder(tenant.TenantConnectionInfo));
                var tenantDbContext = PlatTenantDbContext.CreatePlatTenantDbContext(tenantInfo);
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
