namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record ApartmentAmenityResponse
{
    public Guid Id { get; set; }

    public Guid ApartmentId { get; set; }

    public Guid AmenityId { get; set; }
    public ApartmentResponse Apartment { get; set; }

    public AmenityResponse Amenity { get; set; }
}