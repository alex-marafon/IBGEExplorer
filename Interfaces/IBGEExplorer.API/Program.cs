using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Core.Contexts.Account.Create;
using SharedContext.Services.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
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


app.MapGet("api/v1/account", (Handler handler, string email, string password) =>
{
    var result = handler.CreateAccountAsync(email, password);
    Console.WriteLine("foi");
});

app.MapPost("api/v1/token", ( string email, string password) =>
{
    var token = TokenService.GenerateToken(email, password);
    return Results.Ok(new
    {
        Email = email,
        Password = "",
        Token = token
    });
});


app.Run();
