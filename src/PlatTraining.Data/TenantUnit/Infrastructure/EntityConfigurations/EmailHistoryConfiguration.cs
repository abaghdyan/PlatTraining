using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations
{
    internal class EmailHistoryConfiguration : IEntityTypeConfiguration<EmailHistory>
    {
        public void Configure(EntityTypeBuilder<EmailHistory> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_EmailHistory");
        }
    }
}
