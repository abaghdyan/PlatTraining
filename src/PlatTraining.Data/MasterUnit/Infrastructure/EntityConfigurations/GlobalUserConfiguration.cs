using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class GlobalUserConfiguration : IEntityTypeConfiguration<GlobalUser>
    {
        public void Configure(EntityTypeBuilder<GlobalUser> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_GlobalUser");
        }
    }
}
