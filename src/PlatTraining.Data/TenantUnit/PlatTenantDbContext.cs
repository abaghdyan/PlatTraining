using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.Entities.Tenant;
using PlatTraining.Data.Hubs;
using ServiceTitan.SourceryEngine.Dal.Infrastructure.ApiDataContext.EntityConfigurations;

namespace PlatTraining.Data.DbContexts
{
    public class PlatTenantDbContext : DbContext
    {
        private readonly TenantHub _tenantHub;


        //public PlatTenantDbContext(DbContextOptions<PlatTenantDbContext> options) : base(options)
        //{
        //}
        //
        //public static PlatTenantDbContext CreatePlatTenantDbContext(TenantHub tenantHub)
        //{
        //    return new PlatTenantDbContext(default);
        //}

        public PlatTenantDbContext()
        {
        }

        public static PlatTenantDbContext CreatePlatTenantDbContext(TenantHub tenantHub)
        {
            return new PlatTenantDbContext();
        }

        public DbSet<SomeTenantData> SomeTenantData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var tenant88 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=88tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            var tenant99 = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=99tenant;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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
