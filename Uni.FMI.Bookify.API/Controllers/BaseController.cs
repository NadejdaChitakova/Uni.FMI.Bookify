using Microsoft.AspNetCore.Mvc;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    public class BaseController(IUserService userService) : ControllerBase
    {
        public string UserName => User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Select(x => x.Value).First();

        public string UserId
        {
            get
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    throw new Exception("UserName is null !");
                }

                var id = userService.GetEmployeeByUsername(UserName);

                if (id is null)
                {
                    throw new Exception("User not found");
                }

                return id;
            }
        }
    }
    }

