using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations
{
    internal class SomeTenantDataConfiguration : IEntityTypeConfiguration<SomeTenantData>
    {
        public void Configure(EntityTypeBuilder<SomeTenantData> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_SomeTenantData");
        }
    }
}
