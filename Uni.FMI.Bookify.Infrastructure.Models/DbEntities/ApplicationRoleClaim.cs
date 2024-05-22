using Microsoft.AspNetCore.Identity;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public ApplicationRole Role { get; set; }
    }
}
