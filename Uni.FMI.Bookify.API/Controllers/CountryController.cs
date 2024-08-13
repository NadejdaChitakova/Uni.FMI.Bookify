using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Countries")]
    [EnableCors]
    public class CountryController(
        ICountryService countryService) : Controller
    {
        [HttpGet("GetAll")]
        public ActionResult GetAll()
        {
            var result = countryService.GetAll();

            return Ok(result);
        }
    }
}
