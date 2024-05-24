namespace Uni.FMI.Bookify.Core.Models.Models.Response
{
    public record AddressResponse 
    {
        public Guid Id { get; set; }

        public string City { get; init; }

        public string Street { get; init; }

        public Guid CountryId { get; init; }

    }
}
