using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        public int temperature;
        public string conditions;
        public List<string> clouds = new List<string> { "Sunny", "Overcast", "Rainy" };
        public int temperatureMin = 45;
        public int temperatureMax = 100;

        public Weather()
        {
            SetWeather();
        }

        public void SetWeather()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            temperature = random.Next(temperatureMin,temperatureMax);

            Random index = new Random(DateTime.Now.Millisecond);

            conditions = clouds[index.Next(0, clouds.Count())];
        }

    }

   
}
