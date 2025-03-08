using Microsoft.AspNetCore.Identity;

namespace WebApp.Server.Auth;
public static class IdentityEndpoints
{
    public static IEndpointRouteBuilder MapIdentityEndpoints(this IEndpointRouteBuilder group)
    {
        group.MapIdentityApi<IdentityUser>();
        return group;
    }
}