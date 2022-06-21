using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.HasOne(t => t.User)
                    .WithMany(tc => tc.Roles)
                    .HasForeignKey(t => t.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Role)
                    .WithMany(tc => tc.Users)
                    .HasForeignKey(t => t.GlobalUserId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasKey(ar => ar.Id)
                    .HasName("PK_RoleUser");
        }
    }
}
