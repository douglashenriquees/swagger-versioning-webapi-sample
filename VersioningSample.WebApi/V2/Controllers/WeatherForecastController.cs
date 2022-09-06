using Microsoft.AspNetCore.Mvc;
using VersioningSample.WebApi.V2.Models;

namespace VersioningSample.WebApi.V2.Controllers;

[ApiController]
[ApiVersion("2.0")]
[ApiExplorerSettings(GroupName = "v2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
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

    [HttpGet("sample-action-name")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 1).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}