using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentController(IApartmentService apartmentService) : ControllerBase
    {
        //private readonly ILogger<ApartmentController> _logger;
        private readonly IApartmentService _apartmentService = apartmentService;

        [HttpGet("GetApartmentById")]
        public async Task<ActionResult> GetApartment(Guid id)
        {
            var result = await _apartmentService.GetApartment(id);

            return Ok(result);
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAll(SearchApartmentsRequest request)
        {
            var result = await _apartmentService.GetApartments(request);

            return Ok(result);
        }
    }
}
