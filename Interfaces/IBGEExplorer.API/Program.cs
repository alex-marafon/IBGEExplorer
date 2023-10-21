using IBGEExplorer.Account.UseCases.Login;
using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Cities.UseCases.Update.Contracts;
using IBGEExplorer.Shared.Services.Jwt;
using Microsoft.AspNetCore.Http.HttpResults;

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

UserEndpoints(app);
CityEndpoints(app);

void UserEndpoints(WebApplication app)
{
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
            return Results.StatusCode(500);

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
}

void CityEndpoints(WebApplication app)
{
    app.MapPost("api/v1/ibge", async (CreateCity.Handler handler, CreateCity.CityRequestCreate request) =>
    {
        var baseResponse = await handler.CreateAsync(request);
        return baseResponse.StatusCode == 201 ?
                    Results.CreatedAtRoute("GetByIBGECode") :
                    Results.BadRequest(baseResponse);
    })
    .Produces(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status500InternalServerError)
    .WithName("CreateIbge")
    .WithTags("IBGE");

    app.MapPut("api/v1/ibge", async (UpdateCity.Handler handler, UpdateCity.CityRequestUpdate request) =>
    {
        var baseResponse = await handler.UpateAsync(request);
        if (baseResponse.StatusCode == 404)
            return Results.BadRequest(baseResponse);
        else if (baseResponse.StatusCode == 500)
            return Results.StatusCode(500);

        return Results.CreatedAtRoute("GetByIBGECode");
    })
    .Produces(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status500InternalServerError)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("UpdateByIBGECode")
    .WithTags("IBGE");

    app.MapDelete("api/v1/ibge", async (UpdateCity.Handler handler, string IBGECode) =>
    {
        var baseResponse = await handler.DeleteAsync(IBGECode);
        if (baseResponse.StatusCode == 404)
            return Results.BadRequest(baseResponse);
        else if (baseResponse.StatusCode == 500)
            return Results.StatusCode(500);

        return Results.CreatedAtRoute("GetByIBGECode");
    })
    .Produces(StatusCodes.Status201Created)
    .Produces(StatusCodes.Status500InternalServerError)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("DeleteByIBGECode")
    .WithTags("IBGE");

    app.MapGet("api/v1/ibge", async (GetCity.Handler handler, string IBGECode) =>
    {
        var baseResponse = await handler.GetOneByIBGECodeAsync(IBGECode);

        return baseResponse.StatusCode == 200 ?
            Results.Ok(baseResponse) : 
            Results.NotFound(baseResponse);
    })
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetByIBGECode")
    .WithTags("IBGE");
}

app.Run();