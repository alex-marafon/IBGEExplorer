using Microsoft.Extensions.DependencyInjection;

namespace SharedContext.Services.Jwt;

public static class AuthorizationConfigurator //: IAuthorizationConfigurator
{
    public static void AuthorizationConfigure(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy=> policy.RequireRole("manager"));
            options.AddPolicy("Employee", policy=> policy.RequireRole("employee"));
        });
    }
}

