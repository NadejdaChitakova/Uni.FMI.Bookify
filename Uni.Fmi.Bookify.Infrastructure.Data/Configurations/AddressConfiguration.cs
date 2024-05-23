using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(address => address.Id);

            builder.Property(address => address.City)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(address => address.Street)
                .HasMaxLength(200)
            .IsRequired();

            builder.HasOne(address => address.Country)
                .WithMany(address => address.Address)
                .HasForeignKey(address => address.CountryId);

            builder.HasOne(x => x.Apartment)
                .WithOne(x => x.Address)
                .HasForeignKey<Address>(x=> x.ApartmentId);

        }
    }
}
