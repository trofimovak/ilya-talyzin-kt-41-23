
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace ilya.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly ConcurrentBag<WeatherForecast> Forecasts = new();

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Вызван GET-запрос погоды");

            var forecasts = Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(
                        DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = "Тестовая погода"
                });

            return forecasts.Concat(Forecasts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return BadRequest("Описание погоды не может быть пустым");
            }

            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                TemperatureC = 20,
                Summary = description
            };

            Forecasts.Add(forecast);

            _logger.LogInformation(
                "Добавлено описание погоды: {Description}",
                description);

            return Ok(forecast);
        }
    }
}
