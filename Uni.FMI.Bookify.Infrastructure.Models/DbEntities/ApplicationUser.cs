using Microsoft.AspNetCore.Identity;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;

namespace Uni.FMI.Bookify.Insrastructure.Models.DbEntities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsDisabled { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public ICollection<Apartment> Apartments { get; set; }
    }
}
