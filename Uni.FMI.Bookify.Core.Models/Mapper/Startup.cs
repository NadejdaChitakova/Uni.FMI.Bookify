using Microsoft.Extensions.DependencyInjection;

namespace Uni.FMI.Bookify.Core.Models.Mapper
{
    public static class Startup
    {
        public static IServiceCollection AddAutoMapperAndProfiles(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ApartmentMappingProfile));
    }
}
