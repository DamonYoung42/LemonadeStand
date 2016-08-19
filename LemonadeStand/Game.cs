using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public UserInput gameConsole;
        public Player player;
        public Day day;
        public bool bankrupt;
        public int maxNumOfDays;
        public int dayOfOperation;

        public Game()
        {
            bankrupt = false;
            dayOfOperation = 1;
            gameConsole = new UserInput();
            gameConsole.IntroduceGame();

        }

        public void RunGame()
        {
            player = new Player(gameConsole.SetPlayerName().ToUpper());
            maxNumOfDays = gameConsole.SetDaysofOperation();

                while ((!bankrupt) && (dayOfOperation < maxNumOfDays))
                {
                    day = new Day();
                    day.weatherForecast.SetWeather();
                    gameConsole.DisplayWeatherForecast(day.weatherForecast);
                    gameConsole.DisplayCash(player.franchise);

                    BuyInventory();
                    
                    CreateRecipe();

                    SetProductPrice();
                    day.weatherActual.SetWeather(day.weatherForecast);
                    GenerateDemandLevel();
                    GenerateCustomers();
                    gameConsole.DisplayActualWeather(day.weatherActual);
                    MakePitcher();
                    SellToCustomers();
                    SubtractSpoiledDay();
                    gameConsole.DisplayDailyResults(day);
                    gameConsole.DisplaySpoilage(player);
                    RemoveSpoiledInventory();
                    dayOfOperation++;
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }
            
            gameConsole.DisplayFinalResults(player.franchise);
                
            Console.WriteLine("Thanks for playing {0}. Goodbye!", player.name);
            Console.ReadLine();
        }



        public void BuyInventory()
        {
            if (player.franchise.cashOnHand > 1.00)
            {

                    AddLemonInventory();
                    AddSugarInventory();
                    AddIceInventory();
                    AddCupInventory();
                

            }
            else bankrupt = true;

        }

        public void CheckIfSoldOut ()
        {
            if ((day.numOfBuyingCustomers == day.recipe.maxNumOfCups) || (!EnoughInventory()))
            {
                Console.WriteLine("You are sold out!");
                day.soldOut = true;
            }
        }

        public void SetProductPrice()
        {
            day.pricePerCup = gameConsole.SetPrice();

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
            day.demandLevel = chance.Next(0, 100);
            if (day.weatherActual.temperature < temperatureLevelOne)
            {
                day.demandLevel *= .30;
            }
            else if (day.weatherActual.temperature < temperatureLevelTwo)
            {
                day.demandLevel *= .60;
            }
            else if (day.weatherActual.temperature < temperatureLevelThree)
            {
                day.demandLevel *= .75;
            }
            else
            {
                day.demandLevel *= .90;
            }

            switch (day.weatherActual.conditions)
            {
                case "Sunny":
                    day.demandLevel *= sunnyFactor;
                    break;
                case "Overcast":
                    day.demandLevel *= overcastFactor;
                    break;
                case "Rainy":
                    day.demandLevel *= rainyFactor;
                    break;
            }
        }

        public void GenerateCustomers()
        {
            int numOfCustomersMin = 25;
            int numOfCustomersMax = 150;
            Random random = new Random(DateTime.Now.Millisecond);
            
            day.numOfCustomers = random.Next(numOfCustomersMin, numOfCustomersMax);

            for (int i = 0; i < day.numOfCustomers; i++)
            {
                Customer newCustomer = new Customer(day.weatherActual, day.pricePerCup);
                day.customers.Add(newCustomer);
            }

        }

        public void CreateRecipe()
        {
            int availableLemonPitchers;
            int availableSugarPitchers;

            Console.WriteLine("Set your recipe for the day.");
            day.recipe.numOfLemons = gameConsole.SetRecipe("lemons");
            day.recipe.numOfSugar = gameConsole.SetRecipe("sugar");
            day.recipe.numOfIce = gameConsole.SetRecipe("ice");

            availableLemonPitchers = Convert.ToInt32(player.franchise.storeInventory.lemonInventory.Count() / day.recipe.numOfLemons);
            availableSugarPitchers = Convert.ToInt32(player.franchise.storeInventory.sugarInventory.Count() / day.recipe.numOfSugar);

            day.recipe.maxNumOfPitchers = Math.Min(availableLemonPitchers, availableSugarPitchers);

            day.recipe.maxNumOfCups = day.recipe.maxNumOfPitchers * day.recipe.cupsPerPitcher;
        }

        public void RemoveUsedInventory()
        {
            player.franchise.storeInventory.lemonInventory.RemoveRange(0, (day.recipe.numOfLemons));
            player.franchise.storeInventory.sugarInventory.RemoveRange(0, (day.recipe.numOfSugar));
        }

        public bool EnoughInventory()
        {

            if (player.franchise.storeInventory.lemonInventory.Count() < day.recipe.numOfLemons)
            {
                Console.WriteLine("You don't have enough lemons for your recipe.");
                return false;
            }
            else if (player.franchise.storeInventory.iceInventory.Count() < day.recipe.numOfIce)
            {
                Console.WriteLine("You don't have enough ice for your recipe.");
                return false;
            }
            else if(player.franchise.storeInventory.sugarInventory.Count() < day.recipe.numOfSugar)
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


        public void SellToCustomers()
        {
            //open for business, generate customers
            //Update daily revenue, total revenue, total expenses

                foreach (Customer customer in day.customers)
                {
                    if (customer.chanceOfPurchase >= day.demandLevel)
                    {
                        if (!day.soldOut)
                        {
                            day.numOfBuyingCustomers++;
                            player.franchise.storeInventory.cupInventory.RemoveAt(0);
                            player.franchise.storeInventory.iceInventory.RemoveRange(0, day.recipe.numOfIce);

                            if (((day.numOfBuyingCustomers % day.recipe.cupsPerPitcher) == 0) && (day.numOfPitchers < day.recipe.maxNumOfPitchers))
                            {
                                MakePitcher();
                                //MakePitcher, remove lemons/sugar ingredients from inventory
                            }
                            day.AddToDailyRevenue(day.pricePerCup);
                            ////remove inventory


                        }

                    }
                    CheckIfSoldOut();
                }

            player.franchise.SetStoreRevenue(day);
            player.franchise.AddToStoreCashOnHand(day);

        }

        public void MakePitcher()
        {
            day.numOfPitchers++;
            RemoveUsedInventory();
        }

        public void AddLemonInventory()
        {
            int userInput;
            double cost = 0;
            Lemon newLemon;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} lemons in your inventory.", player.franchise.storeInventory.lemonInventory.Count());
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

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newLemon = new Lemon();
                    player.franchise.storeInventory.lemonInventory.Add(newLemon);
                }
                player.franchise.SetStoreExpenses(day);
                day.AddToDailyExpenses(cost);
                UpdateCashOnHand(cost);
            }
            else
            {
                AddLemonInventory();
            }

        }
        public void UpdateCashOnHand(double cost)
        {
            player.franchise.SubtractFromCashOnHand(cost);
            
            Console.WriteLine("Cash on hand: {0:$0.00}", player.franchise.cashOnHand);
        }

        public void AddSugarInventory()
        {
            int userInput;
            double cost = 0;
            Sugar newSugar;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} sugar in your inventory.", player.franchise.storeInventory.sugarInventory.Count());
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
            }

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newSugar = new Sugar();
                    player.franchise.storeInventory.sugarInventory.Add(newSugar);
                }
                player.franchise.SetStoreExpenses(day);
                day.AddToDailyExpenses(cost);
                UpdateCashOnHand(cost);
            }
            else
            {
                AddSugarInventory();
            }

        }

        public void AddIceInventory()
        {
            int userInput;
            double cost = 0;
            Ice newIce;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} ice cubes in your inventory.", player.franchise.storeInventory.iceInventory.Count());
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

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newIce = new Ice();
                    player.franchise.storeInventory.iceInventory.Add(newIce);
                }
                player.franchise.SetStoreExpenses(day);
                day.AddToDailyExpenses(cost);
                UpdateCashOnHand(cost);
            }
            else
            {
                AddIceInventory();
            }
        }

        public void AddCupInventory()
        {
            int userInput;
            double cost = 0;
            Cup newCup;
            bool addItems = true;
            int numOfItemsToAdd = 0;

            Console.WriteLine("You have {0} cups in your inventory.", player.franchise.storeInventory.cupInventory.Count());
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

            if (CheckCashOnHand(cost) && (addItems))
            {
                for (int i = 1; i <= numOfItemsToAdd; i++)
                {
                    newCup = new Cup();
                    player.franchise.storeInventory.cupInventory.Add(newCup);
                }
                player.franchise.SetStoreExpenses(day);
                day.AddToDailyExpenses(cost);
                UpdateCashOnHand(cost);
            }
            else
            {
                AddCupInventory();
            }

        }
        public bool CheckCashOnHand(double cost)
        {
            if (player.franchise.cashOnHand < cost)
            {
                Console.WriteLine("Sorry, you don't have enough money to purchase those ingredients.");
                return false;
            }
            return true;
        }

        public void RemoveSpoiledInventory()
        {
            player.franchise.storeInventory.lemonInventory.RemoveAll(lemon => lemon.numOfDaysBeforeExpiration == 0);
            player.franchise.storeInventory.iceInventory.RemoveAll(ice => ice.numOfDaysBeforeExpiration == 0);
            player.franchise.storeInventory.sugarInventory.RemoveAll(sugar => sugar.numOfDaysBeforeExpiration == 0);
            player.franchise.storeInventory.cupInventory.RemoveAll(cup => cup.numOfDaysBeforeExpiration == 0);
        }

        public void SubtractSpoiledDay()
        {
            foreach (Lemon ingredient in player.franchise.storeInventory.lemonInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Ice ingredient in player.franchise.storeInventory.iceInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;

            }


            foreach (Sugar ingredient in player.franchise.storeInventory.sugarInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }


            foreach (Cup ingredient in player.franchise.storeInventory.cupInventory)
            {
                ingredient.numOfDaysBeforeExpiration -= 1;
            }

        }
    }
}

