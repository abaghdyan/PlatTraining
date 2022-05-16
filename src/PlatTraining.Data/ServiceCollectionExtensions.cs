using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PlatTraining.Data.Helpers;
using PlatTraining.Data.MasterUnit;
using PlatTraining.Data.MasterUnit.Entities;
using PlatTraining.Data.Models;
using PlatTraining.Data.SampleDataGenerator;
using PlatTraining.Data.Services;
using PlatTraining.Data.TenantUnit;
using PlatTraining.Data.TenantUnit.Entities;
using System.Diagnostics;

namespace PlatTraining
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMultiTenantDbContext(this IServiceCollection services)
        {
            services
                .AddScoped<TenantInfo>()
                .AddScoped<ITenantResolver, TenantResolver>()
                .AddDbContext<TenantDbContext>((provider, cfg) => 
                {
                    var tenantInfo = provider.GetRequiredService<TenantInfo>();
                    cfg.UseSqlServer(tenantInfo.ConnectionString);
                });

            return services;
        }

        //public static IServiceCollection AddMultitenancy(this IServiceCollection services)
        //{
        //    services.AddScoped<TenantInfo>();
        //    services.AddScoped<ITenantResolver, TenantResolver>();

        //    return services;
        //}

        //public static IServiceCollection AddTenantDbContext(this IServiceCollection services)
        //{
        //    //var tenant88 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=88tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    //var tenant99 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=99tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    //
        //    //services.AddDbContext<PlatTenantDbContext>(options =>
        //    //{
        //    //    options.UseSqlServer(tenant88);
        //    //});

        //    services.AddDbContext<TenantDbContext>();

        //    return services;
        //}

        //public static async Task MigrateTenantDbContextAsync(this IServiceProvider provider)
        //{
        //    using var serviceScope = provider.CreateScope();
        //    var masterDbContext = serviceScope.ServiceProvider.GetRequiredService<MasterDbContext>();
        //    var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<TenantDbContext>>();
        //    var migrationTime = new Stopwatch();
        //    logger.LogInformation("Migration started");
        //    migrationTime.Start();
        //    var tenants = await masterDbContext.Tenants.Include(t => t.TenantConnectionInfo).ToListAsync();
        //    foreach (var tenant in tenants)
        //    {
        //        var tenantInfo = new TenantInfo().InitiateForScope(tenant.Id, tenant.Name,
        //            ConnectionHelper.GetConnectionBuilder(tenant.TenantConnectionInfo));
        //        //var tenantDbContext = TenantDbContext.CreateTenantDbContext(tenantInfo);
        //        var tenantDbContext = serviceScope.ServiceProvider.GetRequiredService<TenantDbContext>();
        //        await tenantDbContext.Database.MigrateAsync();
        //    }
        //    migrationTime.Stop();
        //    logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        //}
        public static async Task MigrateTenantDbContextAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var masterDbContext = serviceScope.ServiceProvider.GetRequiredService<MasterDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<TenantDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            var tenants = await masterDbContext.Tenants.Include(t => t.TenantConnectionInfo).ToListAsync();
            foreach (var tenant in tenants)
            {
                var tenantDbContext = serviceScope.ServiceProvider.GetTenantDbContext(tenant);
                await tenantDbContext.Database.MigrateAsync();
            }
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }

        public static IServiceCollection AddMasterDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MasterDbContext>(options =>
                    options.UseSqlServer(connectionString));

            return services;
        }

        public static async Task MigrateMasterDbContextAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<MasterDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<MasterDbContext>>();
            var migrationTime = new Stopwatch();
            logger.LogInformation("Migration started");
            migrationTime.Start();
            await dbContext.Database.MigrateAsync();
            migrationTime.Stop();
            logger.LogInformation($"Migrating finished", new { Duration = migrationTime.ElapsedMilliseconds });
        }
        public static async Task AddMasterSampleDataAsync(this IServiceProvider provider)
        {
            try
            {
                using var serviceScope = provider.CreateScope();
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<MasterDbContext>();
                if (!await dbContext.Tenants.AnyAsync())
                {
                    dbContext.Tenants.AddRange(SampleDataGenerator.GenerateTenants());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        public static async Task AddTenantSampleDataAsync(this IServiceProvider provider)
        {
            using var serviceScope = provider.CreateScope();
            var masterDbContext = serviceScope.ServiceProvider.GetRequiredService<MasterDbContext>();
            var tenants = await masterDbContext.Tenants.Include(t => t.TenantConnectionInfo).ToListAsync();
            foreach (var tenant in tenants)
            {
                try
                {
                    var tenantDbContext = serviceScope.ServiceProvider.GetTenantDbContext(tenant);
                    if (!await tenantDbContext.SomeTenantData.AnyAsync())
                    {
                        tenantDbContext.SomeTenantData.Add(new SomeTenantData
                        {
                            Data = tenant.Data
                        });
                        await tenantDbContext.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private static TenantDbContext GetTenantDbContext(this IServiceProvider provider, Tenant tenant)
        {
            provider.GetRequiredService<TenantInfo>()
                    .InitiateForScope(
                        tenant.Id,
                        tenant.Name,
                        ConnectionHelper.GetConnectionBuilder(tenant.TenantConnectionInfo)
                    );

            return provider.GetRequiredService<TenantDbContext>();
        }
    }
}
