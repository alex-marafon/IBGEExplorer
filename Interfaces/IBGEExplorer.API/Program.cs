using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using SharedContext.Services.Jwt;

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

app.MapPost("api/v1/token", ( string email, string password) =>
{
    //recer email e senha.   validar se esta de acordo com regra de negocio.
    // encriptar senha.
    //verificar dados no banco (validar)
    // se "user" CanLogin for false Exception "Usuario nao validou seu cadastro no e-mail"
    // se usuario valido proxiga
    // se ok, gerar token.


    var role = new List<string> { "Admin" };
    var name = "Alex";

    var user = new
    {
        id = "guiddd",
        Name = name,
        Email = email,
        Password = password,
        Roles = role,
    };


    var token = TokenService.GenerateToken(user.id);
    return Results.Ok(new
    {
        Email = email,
        Password = "",
        Token = token
    });
});


app.Run();