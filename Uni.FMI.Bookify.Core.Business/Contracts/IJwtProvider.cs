using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IJwtProvider
{
    string Generate(ApplicationUser applicationUser);
}