using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal.Entities;

namespace PlatTraining.TenantData
{
    public class PlatTenantDbContext : DbContext
    {
        public PlatTenantDbContext(DbContextOptions<PlatTenantDbContext> options) : base(options)
        {
        }

        public DbSet<PlatIndex> PlatIndexes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
