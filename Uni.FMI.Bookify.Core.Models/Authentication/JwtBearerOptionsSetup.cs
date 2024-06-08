using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Uni.FMI.Bookify.Core.Models.Authentication
{
    public class JwtBearerOptionsSetup(IOptions<JwtOptions> options) : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtOptions _options = options.Value;

        public void Configure(string? name, JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _options.Issuer,
                ValidAudience = _options.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                                                            Encoding.UTF8.GetBytes(_options.SecretKey))
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
