using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(apartment => apartment.Id);

            builder.Property(apartment => apartment.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(apartment => apartment.Description)
                .HasMaxLength(2000);

            builder.Property(apartment => apartment.LastBookedOnUtc)
                .IsRequired(false);

            builder.HasOne(apartment => apartment.Address)
                .WithOne(apartment => apartment.Apartment)
                .HasForeignKey<Apartment>(apartment=> apartment.Id);

            builder.HasMany(apartment => apartment.Amenities)
                .WithOne(apartment => apartment.Apartment)
                .HasForeignKey(apartment => apartment.AmenityId);

            builder.HasMany(apartment => apartment.ApartmentImages)
                .WithOne(apartment => apartment.Apartment)
                .HasForeignKey(apartment => apartment.ApartmentId);

            builder.HasOne(apartment => apartment.Owner)
                .WithMany(apartment => apartment.Apartments)
                .HasForeignKey(apartment => apartment.OwnewId);

            builder.HasMany(apartment => apartment.Bookings)
                .WithOne(apartment => apartment.Apartment)
                .HasForeignKey(apartment => apartment.ApartmentId);
        }
    }
}
