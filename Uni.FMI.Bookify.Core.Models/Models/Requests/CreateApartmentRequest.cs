using Uni.FMI.Bookify.Core.Models.NewFolder.Requests;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record CreateApartmentRequest
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public decimal CleaningFee { get; init; }

        public Address Address { get; init; }

        public Currency Currency { get; init; } = Currency.BGN;

        public List<Guid> ApartmentPhotosIds { get; set; }

    }
}
