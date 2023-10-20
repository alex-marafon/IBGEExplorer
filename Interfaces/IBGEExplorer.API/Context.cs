using IBGEExplorer.Account.UseCases.Role.Get;
using IBGEExplorer.Account.UseCases.Role.Get.Contracts;
using IBGEExplorer.Account.UseCases.UserRole.Create;
using IBGEExplorer.Account.UseCases.UserRole.Create.Contracts;
using IBGEExplorer.Data;
using IBGEExplorer.Data.Contexts.Roles.UsesCases.Get;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<CreateAccount.Handler>();
        builder.Services.AddTransient<GetAccount.Handler>();
        builder.Services.AddTransient<Account.UseCases.Role.Get.Handler>();
        builder.Services.AddTransient<Account.UseCases.UserRole.Create.Handler>();        

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
            <CreateAccount.Contracts.IRepository,Data.Contexts.Account.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <GetAccount.Contracts.IRepository, Data.Contexts.Account.UseCases.Get.Repository>();
        builder.Services.AddScoped
            <Account.UseCases.Role.Get.Contracts.IRepository, Repository>();
        builder.Services.AddScoped
            <Account.UseCases.Role.Create.Contracts.IRepository, Data.Contexts.Roles.UsesCases.Create.Repository>();
        builder.Services.AddScoped
            <Account.UseCases.UserRole.Create.Contracts.IRepository, Data.Contexts.UserRole.UsesCases.Create.Repository>();
    }
}