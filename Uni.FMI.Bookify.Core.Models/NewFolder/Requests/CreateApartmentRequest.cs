using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
using Uni.FMI.Bookify.Insrastructure.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.NewFolder.Requests
{
    public record CreateApartmentRequest
    {
        public string Name { get; init; }

        public string Description { get; init; }

        public decimal Price { get; init; }

        public decimal CleaningFee { get; init; }

        public Address Address { get; init; }

        public Currency Currency { get; init; }

        public List<Amenity> Amenities { get; init; }

        public List<UploadApartmentPhoto> ApartmentPhotos { get; set; }

    }
}
