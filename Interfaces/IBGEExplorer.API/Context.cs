using IBGEExplorer.Data;
using Microsoft.EntityFrameworkCore;

namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration
            .GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(connectionString, b => b.MigrationsAssembly("IBGEExplorer.API"));
            opt.UseLoggerFactory(LoggerFactory.Create(builder =>
                builder.AddFilter((category, level) =>
                    level >= LogLevel.Information)));
        });

        //user
        builder.Services.AddTransient<CreateAccount.Handler>();
        builder.Services.AddTransient<GetAccount.Handler>();
        builder.Services.AddTransient<GetRole.Handler>();
        builder.Services.AddTransient<CreateUserRole.Handler>();
        //city
        builder.Services.AddTransient<GetCity.Handler>();
        builder.Services.AddTransient<UpdateCity.Handler>();
        builder.Services.AddTransient<CreateCity.Handler>();
        builder.Services.AddTransient<ImportCity.Handler>();
        //state
        builder.Services.AddTransient<CreateState.Handler>();
        builder.Services.AddTransient<GetState.Handler>();
        //county
        builder.Services.AddTransient<CreateCounty.Handler>();
        builder.Services.AddTransient<GetCounty.Handler>();



        //user
        builder.Services.AddScoped
            <CreateAccount.Contracts.IRepository,Data.Contexts.Account.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <GetAccount.Contracts.IRepository, Data.Contexts.Account.UseCases.Get.Repository>();
        builder.Services.AddScoped
            <GetRole.Contracts.IRepository, Data.Contexts.Roles.UsesCases.Get.Repository>();
        builder.Services.AddScoped
            <CreateRole.Contracts.IRepository, Data.Contexts.Roles.UsesCases.Create.Repository>();
        builder.Services.AddScoped
            <CreateUserRole.Contracts.IRepository, Data.Contexts.UserRole.UsesCases.Create.Repository>();
        //city
        builder.Services.AddScoped
            <CreateCity.Contracts.IRepository, Data.Contexts.Cities.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <UpdateCity.Contracts.IRepository, Data.Contexts.Cities.UseCases.Update.Repository>();
        builder.Services.AddScoped
            <GetCity.Contracts.IRepository, Data.Contexts.Cities.UseCases.Search.Repository>();
        builder.Services.AddScoped
            <ImportCity.Contracts.IRepository, Data.Contexts.Cities.UseCases.Import.Repository>();
        //county
        builder.Services.AddScoped
            <CreateCounty.Contracts.IRepository, Data.Contexts.County.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <GetCounty.Contracts.IRepository, Data.Contexts.County.UseCases.Get.Repository>();
        //state
        builder.Services.AddScoped
            <CreateState.Contracts.IRepository, Data.Contexts.State.UseCases.Create.Repository>();
        builder.Services.AddScoped
            <GetState.Contracts.IRepository, Data.Contexts.State.UseCases.Get.Repository>();
    }
}
