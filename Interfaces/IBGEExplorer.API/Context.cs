using SharedContext.Services.Jwt;
using SharedContext.Services.Jwt.Contracts;

namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBGEExplorer.Core.Contexts.Account.Create.Handler>();
        
        //Services add
        builder.Services.AddSingleton<ITokenService, TokenService>();
    }
}