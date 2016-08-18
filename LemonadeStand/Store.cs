using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {

        public Inventory storeInventory;
        public double cashOnHand;
        public double initialInvestment;
        public int dailyCupsSold;
        public double totalRevenue;
        public double totalExpenses;
        public int maxNumOfDays;
        public bool bankrupt;

        public Store()
        {
            storeInventory = new Inventory();
            initialInvestment = 20.00;
            cashOnHand = initialInvestment;
            maxNumOfDays = 0;
            totalRevenue = 0;
            totalExpenses = 0;
            bankrupt = false;
        }
        public void SetStoreRevenue(Day day)
        {
            totalRevenue += day.dailyRevenue;
        }

        public void SetStoreExpenses(Day day)
        {
            totalExpenses += day.dailyExpenses;
        }

        public void AddToStoreCashOnHand(Day day)
        {
            cashOnHand += day.dailyRevenue;
        }

        public void SubtractFromCashOnHand(double cost)
        {
            cashOnHand -= cost;

        }
    }
}
