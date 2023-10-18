using IBGEExplorer.Shared;
using IBGEExplorer.Shared.Services;
using IBGEExplorer.Shared.Services.Contracts;

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