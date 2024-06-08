using Uni.FMI.Bookify.Core.Models.Models.Requests;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface ILoginService
{
    Task<string> Login(LoginRequest request);
}