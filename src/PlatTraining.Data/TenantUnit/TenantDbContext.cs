using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.Models;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations;

namespace PlatTraining.Data.TenantUnit
{
    public class TenantDbContext : DbContext
    {
        private readonly TenantInfo _tenantInfo;


        //public PlatTenantDbContext(DbContextOptions<PlatTenantDbContext> options) : base(options)
        //{
        //}
        //
        //public static PlatTenantDbContext CreatePlatTenantDbContext(TenantInfo _tenantInfp)
        //{
        //    return new PlatTenantDbContext(default);
        //}

        public TenantDbContext(TenantInfo tenantInfo)
        {
            _tenantInfo = tenantInfo;
        }

        public static TenantDbContext CreateTenantDbContext(TenantInfo tenantInfo)
        {
            return new TenantDbContext(tenantInfo);
        }

        public DbSet<SomeTenantData> SomeTenantData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant88 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=88tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Connection Lifetime=500";
            var tenant99 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=99tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Pooling=true;Connection Lifetime=500";
            optionsBuilder.UseSqlServer(_tenantInfo.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SomeTenantDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
