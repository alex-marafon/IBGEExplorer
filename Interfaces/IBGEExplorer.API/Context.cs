namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<Account.UseCases.Create.Handler>();
    }
}