using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    public sealed class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(country => country.Id);

            builder.Property(country => country.Name)
                .HasMaxLength(200);

            //builder.HasMany(country => country.Address)
            //    .WithOne(country => country.Country)
            //    .HasForeignKey(county => county.CountryId);

            builder.HasMany(x => x.Cities)
                .WithOne(x => x.Country)
                .HasForeignKey(x => x.CountryId);
        }
    }
}
