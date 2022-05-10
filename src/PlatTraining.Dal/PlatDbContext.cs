using Microsoft.EntityFrameworkCore;
using PlatTraining.Dal.Entities;

namespace PlatTraining.Dal
{
    public class PlatDbContext : DbContext
    {
        public PlatDbContext(DbContextOptions<PlatDbContext> options) : base(options)
        {
        }

        public DbSet<PlatIndex> Indexes{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
