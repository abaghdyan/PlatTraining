using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.Entities.Master;
using ServiceTitan.SourceryEngine.Dal.Infrastructure.ApiDataContext.EntityConfigurations;

namespace PlatTraining.Data.DbContexts
{
    public class PlatMasterDbContext : DbContext
    {
        public PlatMasterDbContext(DbContextOptions<PlatMasterDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
