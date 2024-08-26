using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public sealed class Country
    {
        public Guid Id { get; init; }

        public string Name { get; init; }

        public List<City> Cities { get; set; }
    }
}
