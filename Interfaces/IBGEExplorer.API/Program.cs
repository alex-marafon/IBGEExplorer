using IBGEExplorer.API;
using IBGEExplorer.API.Extensions;
using IBGEExplorer.Core.Contexts.Account.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddBaseConfiguration();
builder.AddBaseServices();
builder.AddServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("api/v1/account", (Handler handler, string email, string password) =>
{
    var result = handler.CreateAccountAsync(email, password);
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}