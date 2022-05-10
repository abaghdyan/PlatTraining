using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.Entities.Tenant;

namespace ServiceTitan.SourceryEngine.Dal.Infrastructure.ApiDataContext.EntityConfigurations
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
