using Uni.FMI.Bookify.Core.Models.Models.Requests;
using LoginRequest = Uni.FMI.Bookify.Core.Models.Models.Requests.LoginRequest;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IUserService
{
    Task<string> Login(LoginRequest request);

    Task<bool> Registration(RegistrationRequest request);

    string? GetEmployeeByUsername(string username);
}