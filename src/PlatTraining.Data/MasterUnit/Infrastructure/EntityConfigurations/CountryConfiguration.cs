using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlatTraining.Data.MasterUnit.Entities;

namespace PlatTraining.Data.MasterUnit.Infrastructure.EntityConfigurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(ar => ar.Id)
                    .HasName("PK_Country");
        }
    }
}
