using Microsoft.Extensions.DependencyInjection;

namespace IBGEExplorer.Shared.Services.Jwt;

public static class AuthorizationConfigurator
{
    public static void AuthorizationConfigure(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("manager"));
            options.AddPolicy("Employee", policy=> policy.RequireRole("employee"));
        });
    }
}