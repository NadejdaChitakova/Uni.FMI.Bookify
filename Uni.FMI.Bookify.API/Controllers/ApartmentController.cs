using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Authentication;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Core.Models.NewFolder.Requests;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Apartments")]
    [EnableCors]
    //[Authorize]
    public class ApartmentController(IApartmentService apartmentService) : ControllerBase
    {
        private readonly IApartmentService _apartmentService = apartmentService;

        [HttpGet("GetApartmentById")]
        public async Task<ActionResult> GetApartment(Guid id)
        {
            var result = _apartmentService.GetApartment(id);

            return Ok(result);
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult> GetAll(SearchApartmentsRequest request)
        {
            var result = await _apartmentService.GetApartments(request);

            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> Insert(CreateApartmentRequest request)
        {
 //await _apartmentService.Insert(request);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<ActionResult> Update(UpdateApartmentRequest request, CancellationToken cancellationToken = default)
        {
             await _apartmentService.Update(request, cancellationToken);

            return Ok();
        }
    }
}
