using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Apartments")]
    [EnableCors]
    //[Authorize]
    public class ApartmentController(IApartmentService apartmentService) : ControllerBase
    {
        [HttpGet("GetApartmentById")]
        public async Task<ActionResult> GetApartment(Guid id)
        {
            var result = apartmentService.GetApartment(id);

            return Ok(result);
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAll(SearchApartmentsRequest request)
        {
            var result = await apartmentService.GetApartments(request);

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Insert(CreateApartmentRequest request)
        {
 await apartmentService.Insert(request);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(UpdateApartmentRequest request, CancellationToken cancellationToken = default)
        {
             await apartmentService.Update(request, cancellationToken);

            return Ok();
        }
    }
}
