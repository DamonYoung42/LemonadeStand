using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
       public double chanceOfPurchase;
        static Random customerChance = new Random(DateTime.Now.Millisecond);

        public Customer(Weather weather, double price)
        {
            Random chance = new Random(DateTime.Now.Millisecond);
            chanceOfPurchase = customerChance.Next(0,100);

            if (weather.temperature < 60)
            {
                chanceOfPurchase *= .20;
            }
            else if (weather.temperature < 75)
            {
                chanceOfPurchase *= .60;
            }
            else
            {
                chanceOfPurchase *= .90;
            }

            switch (weather.conditions)
            {
                case "Sunny":
                    chanceOfPurchase *= 1.1;
                    break;
                case "Overcast":   
                    chanceOfPurchase *= .90;
                    break;
                case "Rainy":
                    chanceOfPurchase *= .10;
                    break;
            }

            if (price < .05)
            {
                chanceOfPurchase *= customerChance.Next(1, 2);
            }
        }
    }
}
