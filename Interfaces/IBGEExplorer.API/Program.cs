using IBGEExplorer.Account.UseCases.Login;
using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Cities.UseCases.Import.Contracts;
using IBGEExplorer.Shared.Services.Contracts;
using IBGEExplorer.Shared.Services.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore().AddDataAnnotations();
//builder.Services.AddSwaggerGen();
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

app.MapPost("api/v1/account", async (CreateAccount.Handler handler, CreateAccount.Request account) =>
{
    var baseResponse = await handler.CreateAccountAsync(account);
    return baseResponse.StatusCode == 201 ?
                Results.CreatedAtRoute("GetUserById") :
                Results.BadRequest(baseResponse);
})
.Produces(StatusCodes.Status201Created)
.Produces(StatusCodes.Status500InternalServerError)
.WithName("CreateUser")
.WithTags("Usuario");

app.MapPost("api/v1/token", async (GetAccount.Handler handler, RequestLogin account) =>
{
    var baseResponse = await handler.GetOneByEmailPasswordAsync(account);

    if (baseResponse.StatusCode == 400)
        return Results.BadRequest(baseResponse);
    else if (baseResponse.StatusCode == 500)
        return Results.BadRequest(baseResponse);

    return Results.Ok(baseResponse);
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithTags("Usuario")
.WithName("UserLoginToken");

app.MapGet("api/v1/accoun", async (GetAccount.Handler handler, int id) =>
{
    var baseResponse = await handler.GetOneByIdAsync(id);
    if (baseResponse.StatusCode == 400)
        return Results.BadRequest(baseResponse);
    else if (baseResponse.StatusCode == 500)
        return Results.BadRequest(baseResponse);

    return Results.Ok(baseResponse);
})
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status500InternalServerError)
.WithTags("Usuario")
.WithName("GetUserById");




//Erro nos 2 andpoints ..  ambos apresentam erro de Ijeção de dependencia no Handler.

app.MapPost("api/v1/import", async (ImportCity.Handler handler, IFormFile request) =>
    {
        var baseResponse = await handler.ImportCityAsync(request);
        return baseResponse.StatusCode == 201 ?
            Results.Ok(baseResponse) :
            Results.BadRequest(baseResponse);
    })
    .Produces(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status500InternalServerError)
    .WithName("ImportCity")
    .WithTags("Cidades");


app.Run();