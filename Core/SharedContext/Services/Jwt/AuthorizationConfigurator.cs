using Microsoft.Extensions.DependencyInjection;
using SharedContext.Services.Jwt.Contracts;

namespace SharedContext.Services.Jwt;

public class AuthorizationConfigurator : IAuthorizationConfigurator
{
    public void AuthorizationConfigure(IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy=> policy.RequireRole("manager"));
            options.AddPolicy("Employee", policy=> policy.RequireRole("employee"));
        });
    }
}

