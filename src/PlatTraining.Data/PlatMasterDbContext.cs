using Microsoft.EntityFrameworkCore;
using PlatTraining.TenantData.Entities;

namespace PlatTraining.Dal
{
    public class PlatMasterDbContext : DbContext
    {
        public PlatMasterDbContext(DbContextOptions<PlatMasterDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
