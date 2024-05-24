namespace Uni.FMI.Bookify.Core.Models.Models.Response;

public record ApartmentImageResponse 
{
    public Guid Id { get; init; }

    public bool IsMainPhoto { get; init; }

    public string Extension { get; init; }

    public byte[] Content { get; init; }

}