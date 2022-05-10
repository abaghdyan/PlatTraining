using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatTraining.TenantData;
using System.Diagnostics;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatTenantDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlatTenantDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }

        public static async Task MigratePlatTenantDbContextAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var dbCOntext = serviceScope.ServiceProvider.GetRequiredService<PlatTenantDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<PlatTenantDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            await dbCOntext.Database.MigrateAsync();
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }
    }
}
