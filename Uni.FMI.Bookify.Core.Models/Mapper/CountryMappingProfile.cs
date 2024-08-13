using AutoMapper;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Core.Models.Mapper
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, GetAllCountries>();
        }
    }
}
