namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class Address
    {
        public Guid Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public Guid CountryId { get; init; }

        public Country Country { get; set; }

        public Guid ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
    }
}
