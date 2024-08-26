using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Uni.FMI.Bookify.Core.Models.Models.Requests;
using Uni.FMI.Bookify.Infrastructure.Data;
using Uni.FMI.Bookify.Infrastructure.Models.DbEntities;
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
            ApplicationRole? role = new();

            var emailExists = await dbContext.Set<ApplicationUser>()
                                  .Select(x => x.Email)
                                  .AnyAsync(x => x == request.Email);

            if (emailExists)
            {
                return false;
            }

            if (request.RegisterLikeOwner.HasValue)
            {
                role = await dbContext.Set<ApplicationRole>()
                           .Where(x => x.Name == "Owner")
                           .FirstOrDefaultAsync();
            }
            else
            {
                role = await dbContext.Set<ApplicationRole>()
                           .Where(x => x.Name == "User")
                           .FirstOrDefaultAsync();
            }

            byte[] bytes = Encoding.Unicode.GetBytes(request.Password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            var passwordBase64String = Convert.ToBase64String(inArray);

            var user = new ApplicationUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                PasswordHash = passwordBase64String,
            };

            
            dbContext.Set<ApplicationUser>()
                .Add(user);

            var userRole = new ApplicationUserRole()
            {
                RoleId = role.Id,
                Role = role,
                UserId = user.Id,
                TimeCreated = DateTime.Now,
                CreatorName = "system"
            };

            dbContext.Set<ApplicationUserRole>()
                .Add(userRole);

            var isSucceed = await dbContext.SaveChangesAsync();

            return isSucceed != -1;
        }

        public string? GetEmployeeByUsername(string username)
        {
            return dbContext.Set<ApplicationUser>()
                .Where(x => x.UserName == username)
                .Select(x=> x.Id)
                .FirstOrDefault();
        }
    }
}
