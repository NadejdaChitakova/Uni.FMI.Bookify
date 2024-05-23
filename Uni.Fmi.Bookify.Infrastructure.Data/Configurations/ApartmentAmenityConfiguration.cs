using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Data.Configurations
{
    internal class ApartmentAmenityConfiguration : IEntityTypeConfiguration<ApartmentAmenity>
    {
        public void Configure(EntityTypeBuilder<ApartmentAmenity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Apartment)
                .WithMany(x => x.Amenities)
                .HasForeignKey(x=> x.ApartmentId);

            builder.HasOne(x => x.Amenity)
                .WithMany(x => x.ApartmentAmenities)
                .HasForeignKey(x => x.AmenityId);
        }
    }
}
