namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class ApartmentImage
    {
        public Guid Id { get; init; }

        public bool IsMainPhoto { get; init; }

        public string Extension { get; init; }

        public byte[] Content { get; init; }

        public Apartment Apartment { get; init; }
    }
}
