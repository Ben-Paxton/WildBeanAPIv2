using Newtonsoft.Json;

namespace WildBeanAPI.Models
{
    public class WeatherForecastModel
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("main")]
        public WeatherForecastDetails Details { get; set; }

        [JsonProperty("weather")]
        public IEnumerable<WeatherForecastDescription> Description { get; set; }
    }

    public class WeatherForecastDetails
    {
        [JsonProperty("temp")]
        public double TempAvg { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherForecastDescription
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
