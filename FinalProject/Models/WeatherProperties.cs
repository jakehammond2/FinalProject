using System;
namespace FinalProject.Models
{
    public class WeatherProperties
    {
        public WeatherProperties()
        {
        }

        public string WeatherDescription { get; set; }
        public string WeatherTenDay { get; set; }
        public string WeatherTempK { get; set; }
        public string WeatherHumidity { get; set; }
        public string WeatherWindSpeed { get; set; }
    }
}

