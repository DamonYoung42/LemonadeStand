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
        private int temperatureLevelOne = 60;
        private int temperatureLevelTwo = 75;
        private double temperatureLevelOneFactor = .20;
        private double temperatureLevelTwoFactor = .60;
        private double temperatureLevelThreeFactor = .90;
        private double sunnyFactor = 1.1;
        private double overcastFactor = .75;
        private double rainyFactor = .10;
        private double priceLevelOne = .50;
        private double priceLevelTwo = 1;

        public Customer(Weather weather, double price)
        {
            chanceOfPurchase = customerChance.Next(0,100);

            if (weather.temperature < temperatureLevelOne)
            {
                chanceOfPurchase *= temperatureLevelOneFactor;
            }
            else if (weather.temperature < temperatureLevelTwo)
            {
                chanceOfPurchase *= temperatureLevelTwoFactor;
            }
            else
            {
                chanceOfPurchase *= temperatureLevelThreeFactor;
            }

            switch (weather.conditions)
            {
                case "Sunny":
                    chanceOfPurchase *= sunnyFactor;
                    break;
                case "Overcast":   
                    chanceOfPurchase *= overcastFactor;
                    break;
                case "Rainy":
                    chanceOfPurchase *= rainyFactor;
                    break;
            }

            if (price < priceLevelOne)
            {
                chanceOfPurchase *= customerChance.Next(2, 3);
            }
            else if (price < priceLevelTwo)
            {
                chanceOfPurchase *= customerChance.Next(1, 2);
            }
            else 
            {
                chanceOfPurchase *= customerChance.Next(0, 1);
            }
        }
    }
}
