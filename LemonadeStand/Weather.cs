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

        public Weather()
        {
            SetWeather();
        }

        public void SetWeather()
        {
            Random random = new Random(DateTime.Now.Millisecond);

            temperature = random.Next(50,110);

            Random index = new Random(DateTime.Now.Millisecond);

            conditions = clouds[index.Next(0, 3)];
        }

    }

   
}
