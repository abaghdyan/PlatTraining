using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.TenantUnit.Entities;

namespace PlatTraining.Data.TenantUnit.Infrastructure.EntityConfigurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Invoice");
        }
    }
}
