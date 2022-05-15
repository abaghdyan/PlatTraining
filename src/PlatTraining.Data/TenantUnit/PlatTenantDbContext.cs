using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.Models;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations;
using PlatTraining.Data.TenantUnit;

namespace PlatTraining.Data.TenantUnit
{
    public class PlatTenantDbContext : DbContext
    {
        private readonly TenantInfo _tenantInfp;


        //public PlatTenantDbContext(DbContextOptions<PlatTenantDbContext> options) : base(options)
        //{
        //}
        //
        //public static PlatTenantDbContext CreatePlatTenantDbContext(TenantInfo _tenantInfp)
        //{
        //    return new PlatTenantDbContext(default);
        //}

        public PlatTenantDbContext(TenantInfo tenantInfo)
        {
            _tenantInfp = tenantInfo;
        }

        public static PlatTenantDbContext CreatePlatTenantDbContext(TenantInfo tenantInfo)
        {
            return new PlatTenantDbContext(tenantInfo);
        }

        public DbSet<SomeTenantData> SomeTenantData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant88 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=88tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Connection Lifetime=500";
            var tenant99 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=99tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Connection Lifetime=500";
            optionsBuilder.UseSqlServer(tenant88);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SomeTenantDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
