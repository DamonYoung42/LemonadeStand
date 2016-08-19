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
    }
}
