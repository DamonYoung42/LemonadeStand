using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store : IInventory
    {
    
        public List<Ingredient> storeInventory;
        public Weather weatherConditions;
        public List<Ingredient> recipe;
        public int dayOfOperation;
        public double cashOnHand;
        public double initialInvestment;


        public Store()
        {
           storeInventory = new List<Ingredient> { };
           initialInvestment = 10.00;
           cashOnHand = initialInvestment;
           recipe = new List<Ingredient> { };
           weatherConditions = new Weather();
           DisplayWeather();
        }

        public void DisplayWeather()
        {
            Console.WriteLine("The weather forecast today is {0} and {1}", weatherConditions.temperature, weatherConditions.conditions);
        }

        public void AddToInventory(Ingredient item)
        {
                storeInventory.Add(item);

        }

        public void SubtractFromInventory(Ingredient item)
        {

                storeInventory.Remove(item);
        }

        public int GetInventoryItemCount(Ingredient item)
        {
            return storeInventory.Count(x => x.name == item.name);

        }

        public void SubtractSpoiledDay(Ingredient item)
        {
            item.numOfDaysBeforeExpiration -= 1;
        }


        public void BuyInventory()
        {
            int userInput;
            Lemon newLemon = new Lemon();
            Ice newIce = new Ice();
            Sugar newSugar = new Sugar();
            Cup newCup = new Cup();
            double lemonPrice = .75;
            double icePrice = .05;
            double cupPrice = .10;
            double sugarPrice = .99;
            double cost = 0;

            Console.WriteLine("You currently have {0} lemons. How many would you like to buy (75 cents per lemon):", storeInventory.Count(x => x.name == "lemon"));
            userInput = Convert.ToInt32(Console.ReadLine());
            cost = userInput * lemonPrice;
            if (cashOnHand < cost)
            {
                Console.WriteLine("Sorry, you don't have enough cash to purchase those ingredients.");
            }
            else
            {
                for (int i = 0; i < userInput; i++)
                {
                    AddToInventory(newLemon);
                }

                UpdateCashOnHand(userInput, lemonPrice);
            }


            Console.WriteLine("You currently have {0} sugars. How many would you like to buy (99 cents per sugar):", storeInventory.Count(x => x.name == "sugar"));
            userInput = userInput = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < userInput; i++)
            {
                AddToInventory(newSugar);
            }

            UpdateCashOnHand(userInput, sugarPrice);

            Console.WriteLine("You currently have {0} ice. How many would you like to buy (.05 cents per cube):", storeInventory.Count(x => x.name == "ice"));
            userInput = userInput = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < userInput; i++)
            {
                AddToInventory(newIce);
            }

            UpdateCashOnHand(userInput, icePrice);

            Console.WriteLine("You currently have {0} cups. How many would you like to buy (10 cents per cup):", storeInventory.Count(x => x.name == "cups"));
            userInput = userInput = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < userInput; i++)
            {
                AddToInventory(newCup);
            }

            UpdateCashOnHand(userInput, cupPrice);
            DisplayInventory();
        }

        public void UpdateCashOnHand(int quantity, double price)
        {
            cashOnHand -= quantity * price;
            Console.WriteLine("Cash on hand: {0}", cashOnHand);
        }

        public void DisplayInventory()
        {
            var query = storeInventory.Select(x => x.name)
                .GroupBy(s => s)
                .Select(g => new { name = g.Key, Count = g.Count() });

            foreach (var item in query)
            {
                Console.WriteLine("Ingredient: {0}, Count: {1}", item.name, item.Count);
            }

        }

        //public bool CanMakeRecipe(Recipe recipe)
        //{
        //    foreach (Ingredient item in recipe)
        //    {
        //        if (item.quantity > GetInventoryItemCount(item))
        //        {
        //            return false; // can't make recipe because ingredient not available
        //        }

        //    }
        //    return true;

        //}

    }
}
