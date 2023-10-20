using IBGEExplorer.Data;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<Account.UseCases.Create.Handler>();
        builder.Services.AddTransient<Account.UseCases.Get.Handler>();

        var connectionString = builder.Configuration
            .GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("IBGEExplorer.API"));
            opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                builder.AddFilter((category, level) =>
                    level >= LogLevel.Information)));
        });

        builder.Services.AddScoped
            <IBGEExplorer.Account.UseCases.Create.Contracts.IRepository, 
            IBGEExplorer.Data.Contexts.Account.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <IBGEExplorer.Account.UseCases.Get.Contracts.IRepository, 
            Data.Contexts.Account.UseCases.Get.Repository>();
    }
}