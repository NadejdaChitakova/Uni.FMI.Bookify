namespace Uni.FMI.Bookify.Core.Models.Models.Requests
{
    public record UpdateImageRequest
    {
        public Guid? Id { get; init; }

        public byte[] Content { get; init; }

        public string Extension { get; init; }
    }
}
