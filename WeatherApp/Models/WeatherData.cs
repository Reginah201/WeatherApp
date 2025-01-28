using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class WeatherData
    {
        [JsonPropertyName("main")]
        public MainData Main { get; set; } = new MainData();

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; } = new List<Weather>();

        [JsonPropertyName("name")]
        public string CityName { get; set; } = string.Empty;
    }

    public class Weather
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("icon")]
        public string Icon { get; set; } = string.Empty;
    }

    public class MainData
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
    }
}
