using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    [EnableCors]
    public class LoginController(IUserService userService) : ControllerBase
    {
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request)
        {
            var token = await userService.Login(request);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpPost(nameof(Registration))]
        public async Task<IActionResult> Registration(
            [FromBody] RegistrationRequest request)
        {
            var isSuccessful = await userService.Registration(request);

            if (!isSuccessful)
            {
                return BadRequest();
            }

            return Ok(isSuccessful);
        }
    }
}
