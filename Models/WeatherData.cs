using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        public string CityName { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int Pressure { get; set; }
        public string WeatherType { get; set; } = string.Empty;
        public List<ForecastDay> Forecast { get; set; } = new();
        public List<HistoricalDay> Historical { get; set; } = new();
        public double RainProbability { get; set; }
    }

    public class ForecastDay
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public double RainChance { get; set; }
    }

    public class HistoricalDay
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class OpenWeatherResponse
    {
        public string Name { get; set; } = string.Empty;
        public Main Main { get; set; } = new();
        public Weather[] Weather { get; set; } = Array.Empty<Weather>();
        public Wind Wind { get; set; } = new();
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
    }

    public class Wind
    {
        public double Speed { get; set; }
    }
}