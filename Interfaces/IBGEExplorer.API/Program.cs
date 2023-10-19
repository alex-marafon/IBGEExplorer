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

app.MapPost("api/v1/token", async (GetAccount.Handler handler, CreateAccount.Request account) =>
{
    var baseResponse = await handler.GetOneByEmailPasswordAsync(account);

    if (baseResponse.StatusCode == 400)
        return Results.BadRequest(baseResponse);
    else if (baseResponse.StatusCode == 500)
        return Results.StatusCode(500);

    return Results.Ok(baseResponse);
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithTags("Usuario");

app.Run();