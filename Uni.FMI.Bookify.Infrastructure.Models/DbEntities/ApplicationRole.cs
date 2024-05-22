using Microsoft.AspNetCore.Identity;

namespace Uni.FMI.Bookify.Infrastructure.Models.DbEntities
{
    public sealed class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string roleName, string description)
            : base(roleName)
        {
            this.Description = description;
        }

        public ApplicationRole()
        {
        }

        public string Description { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public ICollection<ApplicationRoleClaim> Claims { get; set; }
    }
}
