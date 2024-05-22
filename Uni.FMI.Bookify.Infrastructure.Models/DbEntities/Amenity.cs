namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public sealed class Amenity
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public double Price { get; init; }

        public ICollection<ApartmentAmenity> ApartmentAmenities { get; set; }

    }
}
