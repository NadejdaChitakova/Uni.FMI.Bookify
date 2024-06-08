using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public class LoginService(IdentityCoreDbContext dbContext,
                                    IJwtProvider jwtProvider) : ILoginService
    {
        public async Task<string> Login(LoginRequest request)
        {
            var user = await dbContext.Set<ApplicationUser>()
                .Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync();

            if (user is null)
            {
                return String.Empty;
            }

            
            string token = jwtProvider.Generate(user);

            return token;
        }
    }
}
