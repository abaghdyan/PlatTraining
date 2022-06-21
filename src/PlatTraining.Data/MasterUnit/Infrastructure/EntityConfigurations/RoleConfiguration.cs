using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Role");
        }
    }
}
