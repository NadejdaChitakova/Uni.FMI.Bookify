using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public sealed class City
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
