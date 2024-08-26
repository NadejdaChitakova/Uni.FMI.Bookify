namespace Uni.FMI.Bookify.Core.Models.Models.Requests;

public record GetUnavailableDatesRequest
{
public Guid ApartmentId { get; set; }
public int Month { get; set; }
public int Year { get; set; }
}