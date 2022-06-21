using Microsoft.EntityFrameworkCore;
using PlatTraining.Data.MasterUnit.Entities;
using PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations;

namespace PlatTraining.Data.MasterUnit
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options) : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionInfo> TenantConnectionInfo { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<GlobalUser> GlobalUsers { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TenantConfiguration());
            modelBuilder.ApplyConfiguration(new TenantConnectionInfoConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GlobalUserConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
            modelBuilder.ApplyConfiguration(new RoleUserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
