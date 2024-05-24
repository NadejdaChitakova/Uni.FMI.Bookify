namespace Uni.FMI.Bookify.Core.Models.NewFolder.Requests
{
    public record CreateApartmentRequest
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public decimal CleaningFee { get; init; }

    }
}
