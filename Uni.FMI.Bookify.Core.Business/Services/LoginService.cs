using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using LoginRequest = Uni.FMI.Bookify.Core.Models.Models.Requests.LoginRequest;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public class UserService(IdentityCoreDbContext dbContext,
                                    IJwtProvider jwtProvider) : IUserService
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

        public async Task<bool> Registration(RegistrationRequest request)
        {
            var emailExists = await dbContext.Set<ApplicationUser>()
                                  .Select(x => x.Email)
                                  .AnyAsync(x => x == request.Email);

            if (emailExists)
            {
                return false;
            }

            byte[] bytes = Encoding.Unicode.GetBytes(request.Password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            var passwoBase64String = Convert.ToBase64String(inArray);

            var user = new ApplicationUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                PasswordHash = passwoBase64String
            };


            dbContext.Set<ApplicationUser>()
                .Add(user);

            var isSucceed = await dbContext.SaveChangesAsync();

            return isSucceed != -1;
        }
    }
}
