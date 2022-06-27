using AspNetCoreLogging.Services.Models;

namespace AspNetCoreLogging.Services
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecast>> GetAsync();

        Task<WeatherForecast> CreateAsync(WeatherForecast forecast);
    }
}
