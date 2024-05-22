using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public class ApartmentAmenity
    {
        public Guid Id { get; set; }

        public Guid ApartmentId { get; set; }

        public Guid AmenityId { get; set; }

        public Apartment Apartment { get; set; }

        public Amenity Amenity { get; set; }
    }
}
