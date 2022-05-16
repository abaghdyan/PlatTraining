using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.TenantUnit.Entities;
using PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations;

namespace PlatTraining.Data.TenantUnit
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options)
            : base(options)
        { }

        public DbSet<SomeTenantData> SomeTenantData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SomeTenantDataConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
