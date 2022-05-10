using Microsoft.EntityFrameworkCore;
using PlatTraining.Common.Contexts;
using PlatTraining.Dal.Entities;

namespace PlatTraining.TenantData
{
    public class PlatTenantDbContext : DbContext
    {
        private readonly TenantHub _tenantHub;

        public PlatTenantDbContext(TenantHub tenantContext)
        {
            _tenantHub = tenantContext;
        }

        public DbSet<SomeTenantData> SomeTenantData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tenantHub.ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
