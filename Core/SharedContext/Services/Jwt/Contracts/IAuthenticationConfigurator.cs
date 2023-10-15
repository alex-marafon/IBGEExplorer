using Microsoft.Extensions.DependencyInjection;

namespace SharedContext.Services.Jwt.Contracts;

public interface IAuthenticationConfigurator
{
    void AuthenticationConfigure(IServiceCollection services); //, string? Issuer, string? Audience
}