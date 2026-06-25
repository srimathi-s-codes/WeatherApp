using WeatherApp.Models;
using System.Text.Json;

namespace WeatherApp.Services
{
    public interface IWeatherService
    {
        Task<WeatherData?> GetWeatherAsync(string city);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<WeatherData?> GetWeatherAsync(string city)
        {
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            
            try
            {
                // Get current weather
                var currentUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
                var currentResponse = await _httpClient.GetStringAsync(currentUrl);
                var currentWeather = JsonSerializer.Deserialize<OpenWeatherResponse>(currentResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (currentWeather == null) return null;

                var weatherData = new WeatherData
                {
                    CityName = currentWeather.Name,
                    Temperature = currentWeather.Main.Temp,
                    Description = currentWeather.Weather[0].Description,
                    Icon = currentWeather.Weather[0].Icon,
                    Humidity = currentWeather.Main.Humidity,
                    WindSpeed = currentWeather.Wind.Speed,
                    Pressure = currentWeather.Main.Pressure,
                    WeatherType = currentWeather.Weather[0].Main.ToLower(),
                    RainProbability = CalculateRainProbability(currentWeather.Weather[0].Main)
                };

                // Generate mock forecast (5 days)
                weatherData.Forecast = GenerateForecast(weatherData);
                
                // Generate mock historical data (7 days)
                weatherData.Historical = GenerateHistorical(weatherData);

                return weatherData;
            }
            catch
            {
                return null;
            }
        }

        private double CalculateRainProbability(string weatherMain)
        {
            return weatherMain.ToLower() switch
            {
                "rain" => 85,
                "drizzle" => 70,
                "thunderstorm" => 90,
                "clouds" => 30,
                "mist" => 40,
                _ => 10
            };
        }

        private List<ForecastDay> GenerateForecast(WeatherData current)
        {
            var forecast = new List<ForecastDay>();
            var random = new Random();
            
            for (int i = 1; i <= 5; i++)
            {
                forecast.Add(new ForecastDay
                {
                    Date = DateTime.Now.AddDays(i),
                    Temperature = current.Temperature + random.Next(-5, 6),
                    Description = GetRandomWeatherDescription(),
                    Icon = GetRandomWeatherIcon(),
                    RainChance = random.Next(0, 101)
                });
            }
            
            return forecast;
        }

        private List<HistoricalDay> GenerateHistorical(WeatherData current)
        {
            var historical = new List<HistoricalDay>();
            var random = new Random();
            
            for (int i = 1; i <= 7; i++)
            {
                historical.Add(new HistoricalDay
                {
                    Date = DateTime.Now.AddDays(-i),
                    Temperature = current.Temperature + random.Next(-8, 9),
                    Description = GetRandomWeatherDescription(),
                    Icon = GetRandomWeatherIcon()
                });
            }
            
            return historical;
        }

        private string GetRandomWeatherDescription()
        {
            var descriptions = new[] { "clear sky", "few clouds", "scattered clouds", "broken clouds", "shower rain", "rain", "thunderstorm", "snow", "mist" };
            return descriptions[new Random().Next(descriptions.Length)];
        }

        private string GetRandomWeatherIcon()
        {
            var icons = new[] { "01d", "02d", "03d", "04d", "09d", "10d", "11d", "13d", "50d" };
            return icons[new Random().Next(icons.Length)];
        }
    }
}