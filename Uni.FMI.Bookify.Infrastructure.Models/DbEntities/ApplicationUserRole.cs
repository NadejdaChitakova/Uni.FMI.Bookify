using Microsoft.AspNetCore.Identity;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public DateTime TimeCreated { get; set; }

        public string CreatorName { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string RoleId { get; set; }

        public ApplicationRole Role { get; set; }
    }
}
