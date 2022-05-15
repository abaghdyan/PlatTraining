using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class TenantConnectionInfoConfiguration : IEntityTypeConfiguration<TenantConnectionInfo>
    {
        public void Configure(EntityTypeBuilder<TenantConnectionInfo> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_TenantConnectionInfo");
        }
    }
}
