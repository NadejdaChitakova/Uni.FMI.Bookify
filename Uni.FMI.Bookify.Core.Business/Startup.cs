using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Uni.FMI.Bookify.Core.Models.Mapper;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Services;
using Uni_FMI.Bookify.Core.Business.Utils;

namespace Uni_FMI.Bookify.Core.Business
{
    public static class Startup
    {
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperAndProfiles();

            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IConvertPhotoService, ConvertPhotoService>();
            services.AddScoped<IApartmentImageService, ApartmentImageService>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<ILoginService, LoginService>();

            return services;
        }
        }
}
