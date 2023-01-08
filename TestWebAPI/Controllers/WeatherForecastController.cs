using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TestWebAPI.Settings;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly SecretParametersSettings _secretParameters;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOptions<SecretParametersSettings> secretParameters)
        {
            _logger = logger;
            _secretParameters = secretParameters.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            
            _logger.LogError("Error");
            _logger.LogCritical("Critical");
            _logger.LogWarning("Warning");
            _logger.LogTrace("Trace");
            _logger.LogDebug("Debug");
            _logger.LogInformation("Information");
            
            var name = _secretParameters.Name;
            var password = _secretParameters.Password;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}