using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Apartments")]
    [EnableCors]
    public class ApartmentController(IApartmentService apartmentService,
        IUserService userService) : BaseController(userService)
    {
        [HttpGet("GetApartmentById")]
        public async Task<IActionResult> GetApartment(Guid id)
        {
            var result = apartmentService.GetApartment(id);

            return Ok(result);
        }

        [HttpPost(nameof(GetUnavailableDate))]
        public async Task<IActionResult> GetUnavailableDate(GetUnavailableDatesRequest request)
        {
            var result = await apartmentService.GetUnavailableDate(request);

            return Ok(result);
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAll(SearchApartmentsRequest request)
        {
            var result = await apartmentService.GetApartments(request);

            return Ok(result);
        }

        [HttpGet(nameof(GetMyApartments))]
        public async Task<IActionResult> GetMyApartments(CancellationToken cancellationToken)
        {
            var myApartments = await apartmentService.GetMyApartments(UserId, cancellationToken);
            return Ok(myApartments);
        }

        [HttpGet(nameof(GetMyApartmentReservations))]
        public async Task<IActionResult> GetMyApartmentReservations([FromQuery] Guid apartmentId, CancellationToken cancellationToken)
        {
            var result = await apartmentService.GetMyApartmentReservations(apartmentId, cancellationToken);
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Insert(CreateApartmentRequest request)
        {
            await apartmentService.Insert(request, UserId);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(UpdateApartmentRequest request, CancellationToken cancellationToken = default)
        {
             await apartmentService.Update(request, cancellationToken);

            return Ok();
        }
    }
}
