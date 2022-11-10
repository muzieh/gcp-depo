using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        using(_logger.BeginScope($"=>{ nameof(Get)}"))
        {
            var forecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTimeOffset.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            _logger.LogWarning("forecast {@forecast} ", forecast);
            _logger.LogWarning("terrier {@foreca} ",
                new object?[]
                {
                    new {a="a\bbd", b=DateTimeOffset.Now},
                    new {a="\"abdsadf", b=DateTimeOffset.Now.AddDays(5)}
                });
            return forecast;
        }
    }
}