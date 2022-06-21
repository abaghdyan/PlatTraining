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

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<EmailHistory> EmailHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new EmailHistoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
