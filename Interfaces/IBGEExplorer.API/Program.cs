using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Core.Contexts.Account.Create;
using SharedContext.Services.Jwt;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.AddBaseConfiguration();
builder.AddBaseServices();
builder.AddServices();

//Testando Jwt
builder.AddBaseServiceJwt();


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


app.MapPost("api/v1/login", (TokenService tokenService, string email, string password) =>
{
    if (email != "alex@gmail.com" || password != "123456")
        return Results.NotFound(new { message = "Email ou Senha invalido", succes = false });

    var token = tokenService.GenerateToken(email, password);

    return Results.Ok(new
    {
        email = email,
        password = "",
        token = token
    });

});


app.Run();
