using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class Address
    {
        public Guid Id { get; set; }

        public Guid CityId { get; set; }

        public City City { get; set; }

        public string Street { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public Guid ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
    }
}
