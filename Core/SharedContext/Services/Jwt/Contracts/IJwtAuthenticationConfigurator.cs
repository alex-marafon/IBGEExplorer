using Microsoft.Extensions.DependencyInjection;

namespace SharedContext.Services.Jwt.Contracts;

public interface IJwtAuthenticationConfigurator
{ 
    void ConfigureJwtAuthentication(IServiceCollection services);
}