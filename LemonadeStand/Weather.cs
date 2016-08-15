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
        public string sky;
        public List<string> clouds = new List<string> { "Sunny", "Overcast", "Rainy" };

        public Weather()
        {
            
         }

        public void GetWeather()
        {
            Random random = new Random();

            temperature = random.Next(50-100);

            int index = random.Next(0 - 2);
            sky = clouds[index];

            
        }
    }

   
}
