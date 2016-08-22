using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        private int temperature;
        private string conditions;
        private List<string> clouds = new List<string> { "Sunny", "Overcast", "Rainy" };

       
        public Weather()
        {
        }

        public void SetWeather()
        {
            int temperatureMin = 30;
            int temperatureMax = 100;

            Random random = new Random(DateTime.Now.Millisecond);

            temperature = random.Next(temperatureMin, temperatureMax);

            Random index = new Random(DateTime.Now.Millisecond);

            conditions = clouds[index.Next(0, clouds.Count())];
        }

        public void SetWeather(Weather weatherForecast)
        {
            int weatherVariance = 5;

            Random random = new Random(DateTime.Now.Millisecond);
            temperature = random.Next(weatherForecast.temperature - weatherVariance, weatherForecast.temperature + weatherVariance);
            Random index = new Random(DateTime.Now.Millisecond);
            conditions = clouds[index.Next(0, clouds.Count())];
        }

        public void DisplayWeather(Weather weather)
        {
            Console.WriteLine("The weather forecast is {1} and {2}", weather.temperature, weather.conditions);
        }

        public int GetWeatherTemperature()
        {
            return temperature;
        }

        public string GetWeatherConditions()
        {
            return conditions;
        }
    }

   
}
