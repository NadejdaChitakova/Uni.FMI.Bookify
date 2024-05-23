using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal sealed class ApartmentImage : IEntityTypeConfiguration<ApartmentAmenity>
    {
        public void Configure(EntityTypeBuilder<ApartmentAmenity> builder)
        {
            builder.HasKey(amenity => amenity.Id);

            builder.HasOne(amenity => amenity.Amenity)
                .WithMany(amenity => amenity.ApartmentAmenities)
                .HasForeignKey(amenity => amenity.AmenityId);

            builder.HasOne(amenity => amenity.Apartment)
                .WithMany(amenity => amenity.Amenities)
                .HasForeignKey(x => x.ApartmentId);
        }
    }
}
