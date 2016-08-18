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
        public bool endGame;
        public string playAgain;

        public Game()
        {
            endGame = false;
            gameConsole = new UserInput();
            gameConsole.IntroduceGame();

        }

        public void RunGame()
        {
            player = new Player(gameConsole.SetPlayerName().ToUpper());
            player.franchise.maxNumOfDays = gameConsole.SetDaysofOperation();
            


            while (!endGame)
            {
                while ((!player.franchise.bankrupt) && (player.franchise.dayOfOperation <= player.franchise.maxNumOfDays))
                {
                    day = new Day();
                    day.weatherForecast.SetWeather();
                    day.weatherActual.SetWeather(day.weatherForecast);
                    gameConsole.DisplayWeather(day.weatherForecast);
                    gameConsole.DisplayCash(player.franchise);
                    CreateRecipe();
                    while (!ValidRecipe())
                    {
                        BuyInventory();
                    }
                    SetProductPrice();
                    GenerateDemandLevel();
                    GenerateCustomers();
                    gameConsole.DisplayWeather(day.weatherActual);
                    SellToCustomers();
                    player.franchise.storeInventory.RemoveSpoiledInventory();
                    gameConsole.DisplayDailyResults(day);
                    gameConsole.DisplaySpoilage(player);
                    player.franchise.dayOfOperation++;
                    
                }
                gameConsole.DisplayFinalResults(player.franchise);
                //Console.WriteLine("Do you want to play again - Y/N?");
                //playAgain = Console.ReadLine().ToUpper();

                //if (playAgain == "N")
                //{
                //    endGame = true;
                //}
                //else
                //{
                //    Game game = new Game();
                //}
            }
            Console.WriteLine("Thanks for playing. Goodbye!");
        }



        public void BuyInventory()
        {
            //DisplayInventory();
            AddLemonInventory();
            AddSugarInventory();
            AddIceInventory();
            AddCupInventory();

        }

        public bool SoldOut ()
        {
            if ((player.franchise.storeInventory.lemonInventory.Count() < day.recipe.numOfLemons) ||
                    (player.franchise.storeInventory.sugarInventory.Count() < day.recipe.numOfSugar) ||
                    (player.franchise.storeInventory.iceInventory.Count() < day.recipe.numOfIce) ||
                    (player.franchise.storeInventory.cupInventory.Count() < day.recipe.maxNumOfCups))
            {
                Console.WriteLine("You have run out of supplies.");
                return true;
            }
            return false;
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
            if (player.franchise.storeInventory.lemonInventory.Count() < day.recipe.numOfLemons)
            {
                Console.WriteLine("You don't have enough inventory to create your recipe!");
                BuyInventory();
            }

            day.recipe.numOfSugar = gameConsole.SetRecipe("sugar");

            day.recipe.numOfIce = gameConsole.SetRecipe("ice");

            availableLemonPitchers = Convert.ToInt32(player.franchise.storeInventory.lemonInventory.Count() / day.recipe.numOfLemons);
            availableSugarPitchers = Convert.ToInt32(player.franchise.storeInventory.sugarInventory.Count() / day.recipe.numOfSugar);

            day.recipe.maxNumOfPitchers = Math.Min(availableLemonPitchers, availableSugarPitchers);

            day.recipe.maxNumOfCups = day.recipe.maxNumOfPitchers * day.recipe.cupsPerPitcher;
        }


        public bool ValidRecipe()
        {

            if ((player.franchise.storeInventory.lemonInventory.Count() < day.recipe.numOfLemons)
                || (player.franchise.storeInventory.iceInventory.Count() < day.recipe.numOfIce)
                    || (player.franchise.storeInventory.sugarInventory.Count() < day.recipe.numOfSugar)
                    || (player.franchise.storeInventory.cupInventory.Count() < day.recipe.maxNumOfCups))
            {
                Console.WriteLine("You don't have enough inventory to create your recipe!");
                return false;
            }
            return true;
        }


        public void SellToCustomers()
        {
            //open for business, generate customers
            //Update daily revenue, total revenue, total expenses

            Console.WriteLine("selling ... selling ... selling!!!");

            foreach (Customer customer in day.customers)
            {
                while (!SoldOut())
                {
                    if (customer.chanceOfPurchase >= day.demandLevel)
                    {
                        day.numOfBuyingCustomers++;

                        day.dailyRevenue += day.pricePerCup;
                        ////remove inventory
                        player.franchise.storeInventory.cupInventory.RemoveAt(0);
                        player.franchise.storeInventory.iceInventory.RemoveRange(0, day.recipe.numOfIce);
                    }
                }
            }

            player.franchise.totalRevenue += day.dailyRevenue;
            player.franchise.cashOnHand += day.dailyRevenue;
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
                player.franchise.dailyExpenses += cost;
                player.franchise.totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }
        public void UpdateCashOnHand(double cost)
        {
            player.franchise.cashOnHand -= cost;
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
                player.franchise.dailyExpenses += cost;
                player.franchise.totalExpenses += cost;
                UpdateCashOnHand(cost);
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
                player.franchise.dailyExpenses += cost;
                player.franchise.totalExpenses += cost;
                UpdateCashOnHand(cost);
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
                player.franchise.dailyExpenses += cost;
                player.franchise.totalExpenses += cost;
                UpdateCashOnHand(cost);
            }

        }
        public bool CheckCashOnHand(double cost)
        {
            if (player.franchise.cashOnHand < cost)
            {
                Console.WriteLine("Sorry, you don't have enough cash to purchase those ingredients.");
                return false;
            }
            return true;
        }

    }
}

