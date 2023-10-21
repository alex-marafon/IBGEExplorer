using IBGEExplorer.Account.UseCases.Login;
using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Shared.Services.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore().AddDataAnnotations();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "IBGEExplorer",
        Description = "Developed by BRA-VO Team",
        Contact = new OpenApiContact { Name = "BRA-VO TEAM", Email = "bravoteam@gmail.com" },
        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
    });

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Inform the token: Bearer {token}",
        Name = "Authorization",
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
    });
});

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
    app.MapPost("api/v1/account", [Authorize] async (CreateAccount.Handler handler, CreateAccount.Request account) =>
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

    app.MapPost("api/v1/token", [AllowAnonymous] async (GetAccount.Handler handler, RequestLogin account) =>
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

    app.MapGet("api/v1/accoun", [AllowAnonymous] async (GetAccount.Handler handler, int id) =>
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
    app.MapPost("api/v1/ibge", [Authorize] async (CreateCity.Handler handler, CreateCity.CityRequestCreate request) =>
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

    app.MapPut("api/v1/ibge", [Authorize] async (UpdateCity.Handler handler, UpdateCity.CityRequestUpdate request) =>
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

    app.MapDelete("api/v1/ibge", [Authorize] async (UpdateCity.Handler handler, string IBGECode) =>
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

    app.MapGet("api/v1/ibge", [AllowAnonymous] async (GetCity.Handler handler, string IBGECode) =>
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

    app.MapGet("api/v1/ibge/state", [AllowAnonymous] async (GetCity.Handler handler, string stateName) =>
    {
        var baseResponse = await handler.GetByStateNameAsync(stateName);

        return baseResponse.StatusCode == 200 ?
            Results.Ok(baseResponse) :
            Results.NotFound(baseResponse);
    })
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetByState")
    .WithTags("IBGE");

    app.MapGet("api/v1/ibge/city", [AllowAnonymous] async (GetCity.Handler handler, string cityName) =>
    {
        var baseResponse = await handler.GetByStateNameAsync(cityName);

        return baseResponse.StatusCode == 200 ?
            Results.Ok(baseResponse) :
            Results.NotFound(baseResponse);
    })
    .Produces(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("GetByCity")
    .WithTags("IBGE");
}

app.Run();