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
        public int dayOfOperation;
        public double cashOnHand;
        public double initialInvestment;
        public double productPrice;
        public int dailyCupsSold;
        public double dailyRevenue;
        public double totalRevenue;
        public double dailyExpenses;
        public double totalExpenses;
        public int maxNumOfDays;
        public bool soldOut;
        public bool bankrupt;
        public double demandLevel;
        public List<Customer> dailyCustomers;
        public int dailyNumOfCustomers;
        public int spoiledLemons;
        public int spoiledIce;
        public int spoiledSugar;
        public bool validRecipe;



        public Store()
        {
            storeInventory = new Inventory();
            initialInvestment = 20.00;
            cashOnHand = initialInvestment;
            dayOfOperation = 1;
            maxNumOfDays = 0;
            productPrice = 0;
            dailyCupsSold = 0;
            dailyRevenue = 0;
            totalRevenue = 0;
            dailyExpenses = 0;
            totalExpenses = 0;
            bankrupt = false;
            soldOut = false;
            dailyCustomers = new List<Customer> { };
            spoiledLemons = 0;
            spoiledIce = 0;
            spoiledSugar = 0;
            validRecipe = false;
        }



        public void SubtractSpoiledDay()
        {
            foreach(Lemon ingredient in storeInventory.lemonInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Ice ingredient in storeInventory.iceInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;

            }


            foreach (Sugar ingredient in storeInventory.sugarInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Cup ingredient in storeInventory.cupInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }

        }





        //public void DisplayInventory()
        //{
        //    var distinctInventoryItems = storeInventory.Select(x => x.name)
        //        .GroupBy(s => s)
        //        .Select(g => new { name = g.Key, Count = g.Count() });

        //    foreach (var item in distinctInventoryItems)
        //    {
        //        Console.WriteLine("Ingredient: {0}, Quantity: {1}", item.name, item.Count);
        //    }

        //}












        public void RemoveUsedInventory(Day day)
        {
            storeInventory.lemonInventory.RemoveRange(0, day.recipe.numOfLemons);
            storeInventory.sugarInventory.RemoveRange(0, day.recipe.numOfSugar);
        }       




        




    }
}
