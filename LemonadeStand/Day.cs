﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        public Weather weatherForecast;
        public Weather weatherActual;
        public List<Customer> customers;
        public double demandLevel;
        public Recipe recipe;
        public UserInput userInput;


        public int numOfCustomers;
        public int numOfBuyingCustomers;
        public double pricePerCup;
        public double dailyRevenue;
        public double dailyExpenses;
        public bool soldOut;
        public int numOfPitchers;

        public Day()
        {
            weatherForecast = new Weather();
            weatherActual = new Weather();
            recipe = new Recipe();
            customers = new List<Customer>();
            numOfCustomers = 0;
            numOfBuyingCustomers = 0;
            pricePerCup = 0;
            dailyRevenue = 0;
            dailyExpenses = 0;
            soldOut = false;
            numOfPitchers = 0;
            userInput = new UserInput();
        }

        public bool RunDay(UserInput gameConsole, Store store, int dayNumber)
        {
            weatherForecast.SetWeather();
            gameConsole.DisplayWeatherForecast(weatherForecast, dayNumber);
            gameConsole.DisplayCash(store);

            //AddLemonInventory(store, gameConsole);
            //AddSugarInventory(store, gameConsole);
            //AddIceInventory(store, gameConsole);
            //AddCupInventory(store, gameConsole);

            do
            {
                if (!store.IsBankrupt()){ AddLemonInventory(store, gameConsole); } else { return false; }
                if (!store.IsBankrupt()){ AddSugarInventory(store, gameConsole); } else { return false; }
                if (!store.IsBankrupt()){ AddIceInventory(store, gameConsole); } else { return false; }
                if (!store.IsBankrupt()){ AddCupInventory(store, gameConsole); } else { return false; }
            }
            while (store.NoInventory());
            
            CreateRecipe(store, gameConsole);

            SetProductPrice();

            weatherActual.SetWeather(weatherForecast);
            GenerateDemandLevel();
            GenerateCustomers();
            gameConsole.DisplayActualWeather(weatherActual, dayNumber);

            SellToCustomers(store);

            store.SubtractSpoiledDay();
            return true;

        }
    

        public void AddToDailyExpenses(double cost)
        {
            dailyExpenses += cost;
        }

        public void AddToDailyRevenue(double price)
        {
            dailyRevenue += price;
        }

        public double SetProductPrice()
        {
            return pricePerCup = userInput.SetPrice();
        }

        public void AddToNumberOfBuyingCustomers()
        {
            numOfBuyingCustomers++;
        }

        public void GenerateCustomers()
        {
            int numOfCustomersMin = 25;
            int numOfCustomersMax = 150;
            Random random = new Random(DateTime.Now.Millisecond);

            numOfCustomers = random.Next(numOfCustomersMin, numOfCustomersMax);

            for (int i = 0; i < numOfCustomers; i++)
            {
                Customer newCustomer = new Customer(weatherActual, pricePerCup);
                customers.Add(newCustomer);
            }

        }

        public void GenerateDemandLevel()
        {
            int temperatureLevelOne = 60;
            int temperatureLevelTwo = 75;
            int temperatureLevelThree = 85;
            double sunnyFactor = 1.1;
            double overcastFactor = .80;
            double rainyFactor = .20;

            Random chance = new Random(DateTime.Now.Millisecond);
            demandLevel = chance.Next(0, 100);
            if (weatherActual.temperature < temperatureLevelOne)
            {
                demandLevel *= .30;
            }
            else if (weatherActual.temperature < temperatureLevelTwo)
            {
                demandLevel *= .60;
            }
            else if (weatherActual.temperature < temperatureLevelThree)
            {
                demandLevel *= .75;
            }
            else
            {
                demandLevel *= .90;
            }

            switch (weatherActual.conditions)
            {
                case "Sunny":
                    demandLevel *= sunnyFactor;
                    break;
                case "Overcast":
                    demandLevel *= overcastFactor;
                    break;
                case "Rainy":
                    demandLevel *= rainyFactor;
                    break;
            }
        }

        public void CreateRecipe(Store store, UserInput gameConsole)
        {
            int availableLemonPitchers;
            int availableSugarPitchers;

            gameConsole.DisplayInventory(store.storeInventory);
            Console.WriteLine("Set your recipe for the day.");
            recipe.numOfLemons = gameConsole.SetRecipe("lemons");
            recipe.numOfSugar = gameConsole.SetRecipe("sugar");
            recipe.numOfIce = gameConsole.SetRecipe("ice");

            if (EnoughInventory(store))
            {
                availableLemonPitchers = Convert.ToInt32(store.storeInventory.GetLemonInventoryCount() / recipe.GetNumberOfLemons());
                availableSugarPitchers = Convert.ToInt32(store.storeInventory.GetSugarInventoryCount() / recipe.GetNumberOfSugar());
                //availableLemonPitchers = Convert.ToInt32(store.storeInventory.lemonInventory.Count() / recipe.numOfLemons);
                //availableSugarPitchers = Convert.ToInt32(store.storeInventory.sugarInventory.Count() / recipe.numOfSugar);

                recipe.SetMaxNumberOfPitchers(availableLemonPitchers, availableSugarPitchers);

                //recipe.maxNumOfPitchers = Math.Min(availableLemonPitchers, availableSugarPitchers);

                recipe.SetMaxNumberOfCups();
                //recipe.maxNumOfCups = recipe.maxNumOfPitchers * recipe.cupsPerPitcher;
            }
            else
            {
                CreateRecipe(store, gameConsole);
            }

        }
        public bool EnoughInventory(Store store)
        {

            if (store.storeInventory.GetLemonInventoryCount() < recipe.GetNumberOfLemons())
            {
                Console.WriteLine("You don't have enough lemons for your recipe.");
                return false;
            }
            else if (store.storeInventory.GetIceInventoryCount() < recipe.GetNumberOfIce())
            {
                Console.WriteLine("You don't have enough ice for your recipe.");
                return false;
            }
            else if (store.storeInventory.GetSugarInventoryCount() < recipe.GetNumberOfSugar())
            {
                Console.WriteLine("You don't have enough sugar for your recipe.");
                return false;
            }
            return true;
        }

        public bool VerifyCashOnHand(Store store, double cost)
        {
            if (store.GetCashOnHand() <= cost)
            {
                Console.WriteLine("\nSorry, you don't have enough money to purchase those ingredients.");
                return false;
            }


            return true;
        }

        public void UpdateCashOnHand(Store store, double cost)
        {
            store.SubtractFromCashOnHand(cost);

            Console.WriteLine("\nCash on hand: {0:$0.00}", store.GetCashOnHand());
        }

        public void AddSugarInventory(Store store, UserInput gameConsole)
        {
            int userInput;
            double cost = 0;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("\nYou have {0} cups of sugar in your inventory.", store.storeInventory.GetSugarInventoryCount());
            userInput = gameConsole.SetInventory("sugar");

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
                default:
                    addItems = false;
                    break;
            }

            if (addItems) 
            {
                if (VerifyCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        //newSugar = new Sugar();
                        store.storeInventory.AddToSugarInventory();
                        //store.storeInventory.sugarInventory.Add(newSugar);
                    }
                    AddToDailyExpenses(cost);
                    store.AddToStoreExpenses(dailyExpenses);

                    UpdateCashOnHand(store, cost);
                    //Check for Bankrupt -- not enough cash to buy inventory, 
                    //if ((store.GetCashOnHand() <= store.GetMinimumCashNeeded()) && ((store.storeInventory.GetSugarInventoryCount() == 0) ||
                    //(store.storeInventory.GetIceInventoryCount() == 0) ||
                    //(store.storeInventory.GetCupInventoryCount() == 0)))
                    //{
                    //    Console.WriteLine("Sorry you have gone bankrupt");
  
                    //}
                }
                else
                {
                    AddSugarInventory(store, gameConsole);
                }
            }
        }

        public void AddIceInventory(Store store, UserInput gameConsole)
        {
            int userInput;
            double cost = 0;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("\nYou have {0} ice cubes in your inventory.", store.storeInventory.GetIceInventoryCount());
            userInput = gameConsole.SetInventory("ice");

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

            if (addItems)
            {
                if (VerifyCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        store.storeInventory.AddToIceInventory();
                    }
                    AddToDailyExpenses(cost);
                    store.AddToStoreExpenses(dailyExpenses);
                    UpdateCashOnHand(store, cost);
                }
                else
                {
                    AddIceInventory(store, gameConsole);
                }
            }

        }

        public void AddCupInventory(Store store, UserInput gameConsole)
        {
            int userInput;
            double cost = 0;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("\nYou have {0} cups in your inventory.", store.storeInventory.GetCupInventoryCount());
            userInput = gameConsole.SetInventory("cup");

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

            if (addItems)
            {
                if (VerifyCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        store.storeInventory.AddToCupInventory();
                    }
                    AddToDailyExpenses(cost);
                    store.AddToStoreExpenses(dailyExpenses);
                    UpdateCashOnHand(store, cost);
                }
                else
                {
                    AddCupInventory(store, gameConsole);
                }
            }

        }

        public void AddLemonInventory(Store store, UserInput gameConsole)
        {
            int userInput;
            double cost = 0;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("\nYou have {0} lemons in your inventory.", store.storeInventory.GetLemonInventoryCount());
            userInput = gameConsole.SetInventory("lemon");

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

            if (addItems)
            {
                if (VerifyCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        store.storeInventory.AddToLemonInventory();
                    }
                    AddToDailyExpenses(cost);
                    store.AddToStoreExpenses(dailyExpenses);
                    UpdateCashOnHand(store, cost);
                }
                else
                {
                    AddLemonInventory(store, gameConsole);
                }
            }
        }

        public void MakePitcher(Store store)
        {
            AddToNumberOfPitchers();
            store.RemoveUsedInventory(recipe);
        }

        public int GetNumberofBuyingCustomers()
        {
            return numOfBuyingCustomers;
        }

        public void CheckIfSoldOut(Inventory inventory)
        {
            //if ((day.numOfBuyingCustomers == day.recipe.maxNumOfCups) || (!EnoughInventory()))
            if ((GetNumberofBuyingCustomers() == recipe.GetMaxNumberOfCups()) || (inventory.iceInventory.Count() < recipe.numOfIce))
            {
                Console.WriteLine("You sold out of lemonade!");
                soldOut = true;
            }

        }
        
        public void SellToCustomers(Store store)
        {
            foreach (Customer customer in customers)
            {
                if ((customer.chanceOfPurchase >= demandLevel) && (!soldOut))
                {
                    if (GetNumberOfPitchers() == 0)
                    {
                        MakePitcher(store);
                    }

                    AddToNumberOfBuyingCustomers();
                    store.storeInventory.RemoveCupInventory();
                    //store.storeInventory.cupInventory.RemoveAt(0);
                    store.storeInventory.RemoveIceInventory(recipe.GetNumberOfIce());
                    //store.storeInventory.iceInventory.RemoveRange(0, recipe.numOfIce);

                    if (((GetNumberofBuyingCustomers() % recipe.cupsPerPitcher) == 0) && (GetNumberOfPitchers() < recipe.maxNumOfPitchers))
                    {
                        MakePitcher(store);
                    }
                    AddToDailyRevenue(pricePerCup);
                }
                if (!soldOut)
                {
                    CheckIfSoldOut(store.storeInventory);
                }
            }

            store.SetStoreRevenue(dailyRevenue);
            store.AddToStoreCashOnHand(dailyRevenue);

        }

        public int GetNumberOfPitchers()
        {
            return numOfPitchers;
        }

        public void AddToNumberOfPitchers()
        {
            numOfPitchers++;
        }

        public int GetNumOfCustomers()
        {
            return numOfCustomers;
        }

        public double GetDailyRevenue()
        {
            return dailyRevenue;
        }

        public double GetDailyExpenses()
        {
            return dailyExpenses;
        }

        public int GetNumOfBuyingCustomers()
        {
            return numOfBuyingCustomers;
        }

    }
}
