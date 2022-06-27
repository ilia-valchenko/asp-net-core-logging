using AspNetCoreLogging.Services;
using AspNetCoreLogging.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var weatherForecasts = await this.weatherForecastService.GetAsync();
            return Ok(weatherForecasts);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(WeatherForecast forecast)
        {
            return Ok(await this.weatherForecastService.CreateAsync(forecast));
        }
    }
}