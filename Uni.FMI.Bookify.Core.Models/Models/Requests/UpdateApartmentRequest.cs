namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record UpdateApartmentRequest
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public string Description { get; init; }

        public string Street { get; init; }

        public string CountryId { get; init; }

        public string City { get; init; }

        public decimal CleaningFee { get; init; }

        public decimal Price { get; init; }

        public List<Guid> AmenitiesId { get; init; }

        public List<UpdateImageRequest> Images { get; init; }
    }
}
