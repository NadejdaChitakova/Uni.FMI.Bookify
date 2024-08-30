namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record GetMyApartments
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
};