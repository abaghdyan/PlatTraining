using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.HasOne(t => t.Permission)
                    .WithMany(tc => tc.Roles)
                    .HasForeignKey(t => t.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Role)
                    .WithMany(tc => tc.Permissions)
                    .HasForeignKey(t => t.PermissionId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(ar => ar.Id)
                    .HasName("PK_RolePermission");
        }
    }
}
