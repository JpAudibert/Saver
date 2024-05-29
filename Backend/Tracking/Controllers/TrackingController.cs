using Microsoft.AspNetCore.Mvc;

namespace Backend.Tracking.Controllers;

[ApiController]
[Route("[controller]")]
public class TrackingController : ControllerBase
{
    private readonly ILogger<TrackingController> _logger;

    public TrackingController(ILogger<TrackingController> logger)
    {
        _logger = logger;
    }

    //[HttpGet(Name = "GetWeatherForecast")]
    //public IEnumerable<WeatherForecast> Get()
    //{
    //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //    {
    //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //        TemperatureC = Random.Shared.Next(-20, 55),
    //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //    })
    //    .ToArray();
    //}
}
