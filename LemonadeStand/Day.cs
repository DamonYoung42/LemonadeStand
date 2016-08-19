using System;
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

        public void RunDay(UserInput gameConsole, Store store, int dayNumber)
        {
            weatherForecast.SetWeather();
            gameConsole.DisplayWeatherForecast(weatherForecast, dayNumber);
            gameConsole.DisplayCash(store);

            AddLemonInventory(store, gameConsole);
            AddSugarInventory(store, gameConsole);
            AddIceInventory(store, gameConsole);
            AddCupInventory(store, gameConsole);

            while (NoInventory())
            {
                AddLemonInventory(store, gameConsole);
                AddSugarInventory(store, gameConsole);
                AddIceInventory(store, gameConsole);
                AddCupInventory(store, gameConsole);
            }

            CreateRecipe(store, gameConsole);

            SetProductPrice();

            weatherActual.SetWeather(weatherForecast);
            GenerateDemandLevel();
            GenerateCustomers();
            gameConsole.DisplayActualWeather(weatherActual, dayNumber);

            MakePitcher(store);
            SellToCustomers(store);

            store.SubtractSpoiledDay();


            gameConsole.DisplaySpoilage(store.storeInventory);

            store.RemoveSpoiledInventory();


            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
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
                availableLemonPitchers = Convert.ToInt32(store.storeInventory.lemonInventory.Count() / recipe.numOfLemons);
                availableSugarPitchers = Convert.ToInt32(store.storeInventory.sugarInventory.Count() / recipe.numOfSugar);

                recipe.maxNumOfPitchers = Math.Min(availableLemonPitchers, availableSugarPitchers);

                recipe.maxNumOfCups = recipe.maxNumOfPitchers * recipe.cupsPerPitcher;
            }
            else
            {
                CreateRecipe(store, gameConsole);
            }

        }
        public bool EnoughInventory(Store store)
        {

            if (store.storeInventory.lemonInventory.Count() < recipe.numOfLemons)
            {
                Console.WriteLine("You don't have enough lemons for your recipe.");
                return false;
            }
            else if (store.storeInventory.iceInventory.Count() < recipe.numOfIce)
            {
                Console.WriteLine("You don't have enough ice for your recipe.");
                return false;
            }
            else if (store.storeInventory.sugarInventory.Count() < recipe.numOfSugar)
            {
                Console.WriteLine("You don't have enough sugar for your recipe.");
                return false;
            }
            //else if (player.franchise.storeInventory.cupInventory.Count() < 1)
            //{
            //    Console.WriteLine("You don't have enough cups to create your recipe!");
            //    return false;
            //}
            return true;
        }

        public bool CheckCashOnHand(Store store, double cost)
        {
            if (store.GetCashOnHand() < cost)
            {
                Console.WriteLine("Sorry, you don't have enough money to purchase those ingredients.");
                return false;
            }
            return true;
        }

        public void UpdateCashOnHand(Store store, double cost)
        {
            store.SubtractFromCashOnHand(cost);

            Console.WriteLine("Cash on hand: {0:$0.00}", store.cashOnHand);
        }

        public void AddSugarInventory(Store store, UserInput gameConsole)
        {
            int userInput;
            double cost = 0;
            Sugar newSugar;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} sugar in your inventory.", store.storeInventory.sugarInventory.Count());
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
                if (CheckCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        newSugar = new Sugar();
                        store.storeInventory.sugarInventory.Add(newSugar);
                    }
                    store.AddToStoreExpenses(dailyExpenses);
                    AddToDailyExpenses(cost);
                    UpdateCashOnHand(store, cost);
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
            Ice newIce;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} ice cubes in your inventory.", store.storeInventory.iceInventory.Count());
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
                if (CheckCashOnHand(store, cost) && (addItems))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        newIce = new Ice();
                        store.storeInventory.iceInventory.Add(newIce);
                    }
                    store.AddToStoreExpenses(dailyExpenses);
                    AddToDailyExpenses(cost);
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
            Cup newCup;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} cups in your inventory.", store.storeInventory.cupInventory.Count());
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
                if (CheckCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        newCup = new Cup();
                        store.storeInventory.cupInventory.Add(newCup);
                    }
                    store.AddToStoreExpenses(dailyExpenses);
                    AddToDailyExpenses(cost);
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
            Lemon newLemon;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} lemons in your inventory.", store.storeInventory.lemonInventory.Count());
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
                if (CheckCashOnHand(store, cost))
                {
                    for (int i = 1; i <= numOfItemsToAdd; i++)
                    {
                        newLemon = new Lemon();
                        store.storeInventory.lemonInventory.Add(newLemon);
                    }
                    store.AddToStoreExpenses(dailyExpenses);
                    AddToDailyExpenses(cost);
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
            numOfPitchers++;
            store.RemoveUsedInventory(recipe);
        }

        public void CheckIfSoldOut()
        {
            //if ((day.numOfBuyingCustomers == day.recipe.maxNumOfCups) || (!EnoughInventory()))
            if ((numOfBuyingCustomers == recipe.maxNumOfCups))
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
                    numOfBuyingCustomers++;
                    store.storeInventory.cupInventory.RemoveAt(0);
                    store.storeInventory.iceInventory.RemoveRange(0, recipe.numOfIce);

                    if (((numOfBuyingCustomers % recipe.cupsPerPitcher) == 0) && (numOfPitchers < recipe.maxNumOfPitchers))
                    {
                        MakePitcher(store);
                    }
                    AddToDailyRevenue(pricePerCup);
                }
                if (!soldOut)
                {
                    CheckIfSoldOut();
                }
            }

            store.SetStoreRevenue(dailyRevenue);
            store.AddToStoreCashOnHand(dailyRevenue);

        }


    }
}
