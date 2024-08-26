using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Infrastructure.Data.Configurations;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Booking")]
    [EnableCors]
    [Authorize]
    public class ReservationsController(IUserService userService,
        IBookingService bookingService) : BaseController(userService)
    {
        [HttpPost(nameof(Reserve))]
        public ActionResult Reserve(MakeReservationRequest request)
        {
            var result = bookingService.Reserve(request, UserId);

            return Ok(result);
        }

        [HttpGet(nameof(GetMyReservation))]
        public IActionResult GetMyReservation()
        {
            var result = bookingService.GetMyReservation(UserId);
            return Ok(result.Result);
        }

        [HttpDelete(nameof(DeclineReservation))]
        public IActionResult DeclineReservation(int reservationId, CancellationToken cancellationToken)
        {
            var result = bookingService.DeclineReservation(reservationId, cancellationToken);

            return Ok();
        }
    }
}
