namespace Uni.FMI.Bookify.Core.Models.NewFolder.Requests
{
    public record Address
    {
        public string City { get; init; }

        public string Street { get; init; }

        public Guid CountryId { get; init; }
    }
}
