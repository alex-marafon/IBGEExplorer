using IBGEExplorer.Data;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<Account.UseCases.Create.Handler>();

        var connectionString = builder.Configuration
            .GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("IBGEExplorer.API"));
            opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                builder.AddFilter((category, level) =>
                    level >= LogLevel.Information)));
        });
    }
}