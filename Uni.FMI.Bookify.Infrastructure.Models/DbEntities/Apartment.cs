using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.Common;

namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class Apartment
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public DateTime? LastBookedOnUtc { get; internal set; }

        public Money Price { get; init; }

        public Money CleaningFee { get; init; }

        public Guid AddressId { get; init; }

        public Address Address { get; init; }

        public ICollection<ApartmentAmenity> Amenities { get; init; }

        public ICollection<ApartmentImage> ApartmentImages { get; set; }

public string OwnewId { get; init; }

public ApplicationUser Owner { get; set; }

public ICollection<Booking> Bookings { get; set; }
    }
}
