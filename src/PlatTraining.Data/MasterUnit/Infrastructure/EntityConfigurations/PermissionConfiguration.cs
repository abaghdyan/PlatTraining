using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Permission");
        }
    }
}
