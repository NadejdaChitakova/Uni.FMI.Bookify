namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class Address
    {
        public Guid Id { get; init; }

        public string State { get; init; }

        public string ZipCode { get; init; }

        public string City { get; init; }

        public string Street { get; init; }

        public Country Country { get; init; }
    }
}
