using Microsoft.AspNetCore.Authorization;

namespace Uni.FMI.Bookify.Core.Models.Authentication
{
    public sealed class HasPermissionAttribute(Permission permission) : AuthorizeAttribute(permission.ToString())
    {

    }
}
