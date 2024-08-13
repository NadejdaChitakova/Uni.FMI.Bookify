namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record GetAllCountries
{
public Guid Id { get; set; }

public string Name { get; init; }
}