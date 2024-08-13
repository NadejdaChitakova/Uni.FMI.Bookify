using AutoMapper;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    internal sealed class CountryService(
    IdentityCoreDbContext dbContext,
    IMapper mapper
    ) : ICountryService
    {
        public List<GetAllCountries> GetAll()
        {
var query = dbContext.Set<Country>().ToList();
            var result = mapper.Map<List<Country>, List<GetAllCountries>>(query);
            return result;
        }
    }
}
