using RestSharp;
using Newtonsoft.Json;
using WildBeanAPI.Models;
using Microsoft.Extensions.Configuration;

namespace WildBeanAPI.Library
{
    public class OpenWeather
    {
        private const string openWeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";
        private const string urlParameters = "?q=London,uk&APPID=905c264d60dff80d60e61dc6dc609c61&units=metric";

        public static WeatherForecastModel GetForecastByCity(string city)
        {
            var apiKey = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["OpenWeatherApiKey"];

            using (var client = new RestClient(string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", city, apiKey)))
            {
                var resp = client.Execute(new RestRequest());
                var deserializedResp = JsonConvert.DeserializeObject<WeatherForecastModel>(resp.Content);
                
                return deserializedResp;
            }
        }
    }
}
