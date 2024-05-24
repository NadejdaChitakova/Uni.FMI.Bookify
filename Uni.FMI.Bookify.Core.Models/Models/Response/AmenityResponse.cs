using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Core.Models.Models.Response
{
    public record AmenityResponse 
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public double Price { get; init; }
    }
}
