namespace Uni.FMI.Bookify.Core.Models.Models.Requests;

public record RegistrationRequest
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool? RegisterLikeOwner { get; set; }
}