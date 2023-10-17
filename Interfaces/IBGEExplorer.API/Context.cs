namespace IBGEExplorer.API;

public static class Context
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IBGEExplorer.Core.Contexts.Account.Create.Handler>();
        
    }
}