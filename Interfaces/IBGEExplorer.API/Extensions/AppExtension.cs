using IBGEExplorer.Shared;
using IBGEExplorer.Shared.Services;
using IBGEExplorer.Shared.Services.Contracts;

namespace IBGEExplorer.API.Extensions;

public static class AppExtension
{
    private static void LoadJsonFile(this IServiceCollection service) =>
    service.AddSingleton<IConfiguration>(GetConfiguration());
    public static IConfiguration GetConfiguration()
    {
        IConfiguration config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
           .Build();

        return config;
    }

    public static void AddBaseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Configuration.GetSection("Discord").Bind(Configuration.Discord);
    }

    public static void AddBaseServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<ILoggerService, LogService>();
    }
}