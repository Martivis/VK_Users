using Microsoft.AspNetCore.Authentication;

namespace VK_Users.Api;

public static class AuthConfiguration
{
    public static IServiceCollection AddAppAuth(this IServiceCollection services)
    {
        services.AddAuthentication("Basic")
            .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);
        return services;
    }
}
