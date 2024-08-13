using Uni.FMI.Bookify.Core.Models.Models.Response;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface ICountryService
{
    List<GetAllCountries> GetAll();
}