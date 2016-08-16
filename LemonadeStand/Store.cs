﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {

        public List<Ingredient> storeInventory;
        public Weather weatherConditions;
        public int dayOfOperation;
        public double cashOnHand;
        public double initialInvestment;
        public double productPrice;
        public Recipe recipe;
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
        public int numOfCustomers;
        public int spoiledLemons;
        public int spoiledIce;
        public int spoiledSugar;


        public Store()
        {
            storeInventory = new List<Ingredient> { };
            initialInvestment = 10.00;
            cashOnHand = initialInvestment;
            recipe = new Recipe();
            dayOfOperation = 1;
            maxNumOfDays = 7;
            weatherConditions = new Weather();
            productPrice = 0;
            dailyCupsSold = 0;
            dailyRevenue = 0;
            dailyExpenses = 0;
            totalExpenses = 0;
            bankrupt = false;
            soldOut = false;
            dailyCustomers = new List<Customer> { };
            spoiledLemons = 0;
            spoiledIce = 0;
            spoiledSugar = 0;
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
            //DisplayInventory();
            AddLemonInventory();
            AddSugarInventory();
            AddIceInventory();
            AddCupInventory();
        
        }

        public void AddLemonInventory()
        {
            int userInput;
            double cost = 0;
            Lemon newLemon = new Lemon();
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} lemons in your inventory.", storeInventory.Count(x => x.name == "lemon"));
            Console.WriteLine("How many lemons would you like to buy?");
            Console.WriteLine("Option 1: 5 for $0.60");
            Console.WriteLine("Option 2: 20 for $2.00");
            Console.WriteLine("Option 3: 50 for $4.00");
            Console.WriteLine("Please enter the number of your selection:");

            userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    cost = .60;
                    numOfItemsToAdd = 5;
                    break;
                case 2:
                    cost = 2.00;
                    numOfItemsToAdd = 20;
                    break;
                case 3:
                    cost = 4.00;
                    numOfItemsToAdd = 50;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    AddToInventory(newLemon);
                }

                UpdateCashOnHand(cost);
            }

        }

        public void AddSugarInventory()
        {
            int userInput;
            double cost = 0;
            Sugar newSugar = new Sugar();
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} sugar in your inventory.", storeInventory.Count(x => x.name == "sugar"));
            Console.WriteLine("How much sugar would you like to buy?");
            Console.WriteLine("Option 1: 5 for $0.60");
            Console.WriteLine("Option 2: 20 for $2.00");
            Console.WriteLine("Option 3: 100 for $9.00");
            Console.WriteLine("Please enter the number of your selection:");

            userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    cost = .60;
                    numOfItemsToAdd = 5;
                    break;
                case 2:
                    cost = 2.00;
                    numOfItemsToAdd = 20;
                    break;
                case 3:
                    cost = 9.00;
                    numOfItemsToAdd = 100;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    AddToInventory(newSugar);
                }
                UpdateCashOnHand(cost);
            }

        }

        public void AddIceInventory()
        {
            int userInput;
            double cost = 0;
            Ice newIce = new Ice();
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} ice cubes in your inventory.", storeInventory.Count(x => x.name == "ice"));
            Console.WriteLine("How many ice cubes would you like to buy?");
            Console.WriteLine("Option 1: 100 for $0.80");
            Console.WriteLine("Option 2: 250 for $1.80");
            Console.WriteLine("Option 3: 500 for $2.50");
            Console.WriteLine("Please enter the number of your selection:");

            userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    cost = .80;
                    numOfItemsToAdd = 100;
                    break;
                case 2:
                    cost = 1.80;
                    numOfItemsToAdd = 250;
                    break;
                case 3:
                    cost = 2.50;
                    numOfItemsToAdd = 500;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    AddToInventory(newIce);
                }
                UpdateCashOnHand(cost);
            }

        }

        public void AddCupInventory()
        {
            int userInput;
            double cost = 0;
            Cup newCup = new Cup();
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} cups in your inventory.", storeInventory.Count(x => x.name == "cup"));
            Console.WriteLine("How many cups would you like to buy?");
            Console.WriteLine("Option 1: 50 for $3.00");
            Console.WriteLine("Option 2: 100 for $5.00");
            Console.WriteLine("Option 3: 200 for $8.00");
            Console.WriteLine("Please enter the number of your selection or ENTER to continue with your current supply:");

            userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    cost = 3.00;
                    numOfItemsToAdd = 50;
                    break;
                case 2:
                    cost = 5.00;
                    numOfItemsToAdd = 100;
                    break;
                case 3:
                    cost = 8.00;
                    numOfItemsToAdd = 200;
                    break;
                default:
                    addItems = false;
                    break;
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    AddToInventory(newCup);
                }

                UpdateCashOnHand(cost);
            }

        }
        public bool CheckCashOnHand(double cost)
        {
            if (cashOnHand < cost)
            {
                Console.WriteLine("Sorry, you don't have enough cash to purchase those ingredients.");
                return false;
            }
            return true;
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

        public void SetProductPrice()
        {
            Console.WriteLine("How much will a cup of lemonade cost today?");
            productPrice = double.Parse(Console.ReadLine());
        }

        public void UpdateCashOnHand(double cost)
        {
            cashOnHand -= cost;
            Console.WriteLine("Cash on hand: {0:$0.00}", cashOnHand);
        }


        public void CreateRecipe()
        {
            int userInput = 0;
            RecipeIngredient ingredient;
            Console.WriteLine("Now it's time to set your recipe for the day.");
            Console.WriteLine("How many lemons would you like to use per cup in your recipe?");
            userInput = int.Parse(Console.ReadLine());
            ingredient = new RecipeIngredient("lemon", userInput);
            recipe.recipeIngredients.Add(ingredient);

            Console.WriteLine("How much sugar would you like to use per cup in your recipe?");
            userInput = int.Parse(Console.ReadLine());
            ingredient = new RecipeIngredient("suger", userInput);
            recipe.recipeIngredients.Add(ingredient);

            Console.WriteLine("How much ice would you like to use per cup in your recipe?");
            userInput = int.Parse(Console.ReadLine());
            ingredient = new RecipeIngredient("ice", userInput);
            recipe.recipeIngredients.Add(ingredient);
        }

        public void SellToCustomers()
        {
            while (!soldOut) 
            {
                //Reset weather
                //Create Recipe
                //open for business, generate customers
                //Update daily revenue, total revenue

                Console.WriteLine("selling ... selling ... selling!!!");

                GenerateCustomers();
                foreach(Customer customer in dailyCustomers)
                {
                    if (customer.chanceOfPurchase > demandLevel)
                    {
                        //cust buys lemonade
                        dailyCupsSold++;
                        dailyRevenue += productPrice;
                        
                        //remove inventory
                        
                        //check inventory levels
                    }
                }
                soldOut = true;

            }
            totalRevenue += dailyRevenue;
            cashOnHand += dailyRevenue;

            //spoilage numbers

            foreach (Ingredient ingredient in storeInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
                //SubtractSpoiledDay(ingredient);
            }
        }

        public void GenerateCustomers()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            numOfCustomers = random.Next(25, 100);
            for (int i = 0; i < Convert.ToInt32(numOfCustomers); i++)
            {
                Customer newCustomer = new Customer(weatherConditions, productPrice);
                dailyCustomers.Add(newCustomer);
            }

        }

        public void GenerateDemandLevel()
        {
            Random chance = new Random(DateTime.Now.Millisecond);
            demandLevel = chance.Next(0, 100);
            if (weatherConditions.temperature < 60)
            {
                demandLevel *= .20;
            }
            else if (weatherConditions.temperature < 75)
            {
                demandLevel *= .60;
            }
            else
            {
                demandLevel *= .90;
            }

            switch (weatherConditions.conditions)
            {
                case "Sunny":
                    demandLevel *= 1.1;
                    break;
                case "Overcast":
                    demandLevel *= .90;
                    break;
                case "Rainy":
                    demandLevel *= .10;
                    break;
            }
        }

        public void RemoveSpoiledInventory()
        {
            storeInventory.RemoveAll(item => item.numOfDaysBeforeExpiration == 0);
        }

        public void DisplayDailyResults()
        {
            Console.WriteLine("You sold {0} cups of lemonade and added {1:$0.00} in revenue on Day {2}.", dailyCupsSold, dailyRevenue, dayOfOperation);
            Console.WriteLine("You lost {0} lemons, {1} sugars and {2} ice cubes to spoilage.", storeInventory.Count(ingredient => (ingredient.name == "lemon") && (ingredient.numOfDaysBeforeExpiration == 0)), storeInventory.Count(ingredient => (ingredient.name == "sugar") && (ingredient.numOfDaysBeforeExpiration == 0)), storeInventory.Count(ingredient => (ingredient.name == "ice") && (ingredient.numOfDaysBeforeExpiration == 0)));
        }

        public void DisplayFinalResults()
        {
            Console.WriteLine("You made {0:$0.00} in total revenue.", totalRevenue);
            Console.WriteLine("You spent {0:$0.00} on inventory.", totalExpenses);
            Console.WriteLine("You made a net profit of {0:$0.00}", totalRevenue - totalExpenses);
        }
    }
}
