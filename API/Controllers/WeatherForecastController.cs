//we don't use this, it's a template
//an API controller template, basically a definition of class




using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]//how do we get to API endpoint
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
    }//constructor

    [HttpGet(Name = "GetWeatherForecast")]

// The [HttpGet] attribute specifies that this method should handle GET requests. 
//The Name = "GetWeatherForecast" attribute parameter gives a name to this route, 
//which can be used for generating URL links.

    public IEnumerable<WeatherForecast> Get()//This is the implementation of the Get method.
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
