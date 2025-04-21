using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");    

app.MapGet("/city/{cityName}", async (string cityName, [FromServices] IHttpClientFactory httpClientFactory, [FromServices] ILogger<Program> logger) =>
{
    var apiUrl = $"https://restcountries.com/v3.1/capital/{cityName}";
    var httpClient = httpClientFactory.CreateClient();

    try
    {
        var response = await httpClient.GetFromJsonAsync<List<CountryResponse>>(apiUrl);

        if (response != null && response.Any())
        {
            var country = response.First();
            return Results.Ok(new
            {
                City = cityName,
                Country = country.Name.Common
            });
        }
        else
        {
            return Results.NotFound(new { City = cityName, Country = "Unknown" });
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error fetching country for city: {CityName}", cityName);
        return Results.Problem("An error occurred while processing your request.");
    }
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


