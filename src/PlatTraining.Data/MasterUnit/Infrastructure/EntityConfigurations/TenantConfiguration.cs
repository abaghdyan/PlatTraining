using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.Entities.Master;

namespace ServiceTitan.SourceryEngine.Dal.Infrastructure.ApiDataContext.EntityConfigurations
{
    internal class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Tenant");
        }
    }
}
