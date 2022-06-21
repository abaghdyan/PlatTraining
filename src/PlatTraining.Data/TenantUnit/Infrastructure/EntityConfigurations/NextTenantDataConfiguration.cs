using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations
{
    internal class NextTenantDataConfiguration : IEntityTypeConfiguration<NextTenantData>
    {
        public void Configure(EntityTypeBuilder<NextTenantData> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_NextTenantData");

            builder.ToTable(nameof(NextTenantData), "next");
        }
    }
}
