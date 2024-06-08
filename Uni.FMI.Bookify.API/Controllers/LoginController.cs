using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/Login")]
    [EnableCors]
    public class LoginController(ILoginService loginService) : ControllerBase
    {
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(
            [FromBody] LoginRequest request)
        {
            var token = await loginService.Login(request);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
