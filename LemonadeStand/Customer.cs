using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        int chanceOfPurchase;
        bool buyingCustomer;
        decimal amountSpent;

        public Customer(Weather weather)
        {
            if (weather.temperature < 60)
            {
                chanceOfPurchase = 20;
            }
            else if (weather.temperature < 75)
            {
                chanceOfPurchase = 70;
            }
            else
            {
                chanceOfPurchase = 90;
            }

            switch (weather.conditions)
            {
                case "Sunny":
                    chanceOfPurchase += 10;
                    break;
                case "Overcast":   
                    chanceOfPurchase -= 10;
                    break;
                case "Rainy":
                    chanceOfPurchase = 0;
                    break;
            }

        }
    }
}
