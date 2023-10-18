using IBGEExplorer.Account.UseCases.Get;
using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Shared.Services.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore().AddDataAnnotations();
builder.Services.AddSwaggerGen();

builder.AddBaseConfiguration();
builder.AddBaseServices();
builder.AddServices();

builder.Services.AuthenticationConfigure();
builder.Services.AuthorizationConfigure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("api/v1/account", (CreateAccount.Handler handler, CreateAccount.Request account) =>
{
    var result = handler.CreateAccountAsync(account);
    Console.WriteLine("foi");
});

app.MapPost("api/v1/token", async (Handler handler, string email, string password) =>
{
    var user = await handler.GetOneByEmailPasswordAsync(email, password);
    if (user == null)
        return Results.NotFound("Usuario nao encontrado");

    var token = TokenService.GenerateToken(user.Id.ToString());
    return Results.Ok(new
    {
        Email = email,
        Password = "",
        Token = token
    });
});

app.Run();