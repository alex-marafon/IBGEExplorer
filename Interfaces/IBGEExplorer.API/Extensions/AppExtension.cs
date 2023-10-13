using SharedContext;
using SharedContext.Services.Log;
using SharedContext.Services.Log.Contracts;

namespace IBGEExplorer.API.Extensions;

public static class AppExtension
{
    public static void AddBaseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.GetSection("Discord").Bind(Configuration.Discord);
    }

    public static void AddBaseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ILoggerService, LogService>();
    }
}