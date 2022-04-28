using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatTraining.Dal;
using System.Diagnostics;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPlatDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PlatDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }

        public static async Task MigrateDBContext(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var dbCOntext = serviceScope.ServiceProvider.GetRequiredService<PlatDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<PlatDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            await dbCOntext.Database.MigrateAsync();
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }
    }
}
