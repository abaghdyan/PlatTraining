using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.Entities.Master;
using PlatTraining.Data.MasterUnit.Entities;

namespace ServiceTitan.SourceryEngine.Dal.Infrastructure.ApiDataContext.EntityConfigurations
{
    internal class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasOne(t => t.TenantConnectionInfo)
                    .WithOne(tc => tc.Tenant)
                    .HasForeignKey<TenantConnectionInfo>(t => t.TenantId);

            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Tenant");
        }
    }
}
