using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Uni.FMI.Bookify.Core.Models.Authentication;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string Generate(ApplicationUser applicationUser)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Sub, applicationUser.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, applicationUser.Email.ToString()),
                new("role", applicationUser.UserRoles.FirstOrDefault().Role.Name )
            };

            var signingCredentials = new SigningCredentials(
                                                            new SymmetricSecurityKey(
                                                             Encoding.UTF8.GetBytes(_options.SecretKey)),
                                                            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                                             _options.Issuer,
                                             _options.Audience,
                                             claims,
                                             null,
                                             DateTime.UtcNow.AddHours(1),
                                             signingCredentials);

            string tokenValue = new JwtSecurityTokenHandler()
                .WriteToken(token);

            return tokenValue;

        }
    }
}
