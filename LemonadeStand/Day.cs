using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public Weather weatherForecast;
        public Weather weatherActual;
        public double demandLevel;

        public int numOfCustomers;
        public int numOfBuyingCustomers;
        public double pricePerCup;
        public double dailyRevenue;
        public double dailyExpenses;

        public Day()
        {
            weatherForecast = new Weather();
            //weatherActual = new Weather();
            numOfCustomers = 0;
            numOfBuyingCustomers = 0;
            pricePerCup = 0;
            dailyRevenue = 0;
            dailyExpenses = 0;
        }

        //create recipe, set price, tally daily revenue, update total revenue
    }
}
