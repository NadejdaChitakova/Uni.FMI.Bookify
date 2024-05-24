namespace Uni.FMI.Bookify.Core.Models.NewFolder.Requests
{
    public record UploadApartmentPhoto
    {
        public byte[] Context { get; init; }

        public string Extension {  get; init; }

        public bool isMainPhoto { get; init; }
    }
}
