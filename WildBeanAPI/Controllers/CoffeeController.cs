using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Collections.Generic;
using System;
using WildBeanAPI.Models;
using WildBeanAPI.Utils;

namespace WildBeanAPI.Controllers
{
    [Route("api/coffee")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private List<string> Cities = new List<string> { "London, UK", "Bangkok, Thailand", "Oodnadatta, Australia", "Auckland, New Zealand" };

        // GET: api/Coffee/<brew-coffee>
        [HttpGet("brew-coffee")]
        [EnableRateLimiting("ratePolicy")]
        public IActionResult Get()
        {
            var result = StatusCode(404, null);

            try
            {
                if (string.Equals(DateTimeProvider.Now.ToString("dd-MM"), "01-04"))
                {
                    result = StatusCode(418, null);
                }
                else
                {
                    var respMessage = string.Empty;

                    Random rnd = new Random();
                    int rndIndex = rnd.Next(Cities.Count);
                    string rndCity = Cities[rndIndex];

                    var weatherForecast = Library.OpenWeather.GetForecastByCity(rndCity);

                    //Changed this to "TempMax" for better results instead of using the current temp
                    if (Math.Floor(weatherForecast.Details.TempMax) > 30)
                    {
                        respMessage = "Your refreshing iced coffee is ready";
                    }
                    else
                    {
                        respMessage = "Your piping hot coffee is ready";
                    }
                    
                    result = StatusCode(200, new CoffeeModel { Message = respMessage, Prepared = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK") });
                }
            }
            catch (Exception ex)
            {
                result = BadRequest(ex.Message);
            }

            return result;
        }
    }
}
