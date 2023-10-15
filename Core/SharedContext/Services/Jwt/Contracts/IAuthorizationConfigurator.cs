using Microsoft.Extensions.DependencyInjection;

namespace SharedContext.Services.Jwt.Contracts;

public interface IAuthorizationConfigurator
{
    void AuthorizationConfigure(IServiceCollection services);
}