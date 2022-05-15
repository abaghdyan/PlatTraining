using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.MasterUnit.Entities;
using PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations;
using PlatTraining.Data.MasterUnit;

namespace PlatTraining.Data.MasterUnit
{
    public class PlatMasterDbContext : DbContext
    {
        public PlatMasterDbContext(DbContextOptions<PlatMasterDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionInfo> TenantConnectionInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            modelBuilder.ApplyConfiguration(new TenantConnectionInfoConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
