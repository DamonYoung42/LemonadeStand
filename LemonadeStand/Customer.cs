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
        public int temperatureLevelOne = 30;
        public int temperatureLevelTwo = 60;
        public int temperatureLevelThree = 75;
        public double temperatureLevelOneFactor = .20;
        public double temperatureLevelTwoFactor = .60;
        public double temperatureLevelThreeFactor = .90;
        public double temperatureLevelFourFactor = 1.1;
        public double sunnyFactor = 1.1;
        public double overcastFactor = .75;
        public double rainyFactor = .20;
        public double priceLevelOne = .25;
        public double priceLevelOneFactor = 1.5;
        public double priceLevelTwo = .50;
        public double priceLevelTwoFactor = 1.25;
        public double priceLevelThree = .75;
        public double priceLevelThreeFactor = 1.00;
        public double priceLevelFour = .99;
        public double priceLevelFourFactor = .90;
        public double priceLevelFiveFactor = .75;

        public Customer(Weather weather, double price)
        {
            //chanceOfPurchase = customerChance.Next(0,100);
            chanceOfPurchase = customerChance.Next(50,100);

            if (weather.GetWeatherTemperature() < temperatureLevelOne)
            {
                chanceOfPurchase *= temperatureLevelOneFactor;
            }
            else if (weather.GetWeatherTemperature() < temperatureLevelTwo)
            {
                chanceOfPurchase *= temperatureLevelTwoFactor;
            }
            else if (weather.GetWeatherTemperature() < temperatureLevelThree)
            {
                chanceOfPurchase *= temperatureLevelThreeFactor;
            }
            else
            {
                chanceOfPurchase *= temperatureLevelFourFactor;
            }

            switch (weather.GetWeatherConditions())
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
                chanceOfPurchase *= priceLevelOneFactor;
            }
            else if (price < priceLevelTwo)
            {
                chanceOfPurchase *= priceLevelTwoFactor;
            }
            else if (price < priceLevelThree)
            {
                chanceOfPurchase *= priceLevelThreeFactor;
            }
            else if (price < priceLevelFour)
            {
                chanceOfPurchase *= priceLevelFourFactor;
            }
            else
            {
                chanceOfPurchase *= priceLevelFiveFactor;
            }
        }
    }
}
