using Uni.FMI.Bookify.Insrastructure.Models.Common;

namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record ApartmentResponse 
{
    public Guid Id { get; set; }

    public string Name { get; init; }

    public string Description { get; init; }

    public DateTime? LastBookedOnUtc { get; internal set; }

    public decimal Price { get; init; }

    public decimal CleaningFee { get; init; }

    public Currency Currency { get; init; }

    public List<ApartmentImageResponse> ApartmentImages { get; set; }

    public AddressResponse Address { get; set; }

    public List<AmenityResponse> Amenities { get; set; }

};