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
        public int maxNumOfDays;
        public int dayOfOperation;
        public double minimumCashNeeded = 1.00;

        public Game()
        {
            dayOfOperation = 1;
            gameConsole = new UserInput();
            gameConsole.IntroduceGame();

        }
        public void RunGame()
        {
            player = new Player(gameConsole.SetPlayerName().ToUpper());
            maxNumOfDays = gameConsole.SetDaysofOperation();

            while (dayOfOperation < maxNumOfDays + 1)
            {
                day = new Day();
                if (day.RunDay(gameConsole, player.store, dayOfOperation))
                {
                    //day.RunDay(gameConsole, player.store, dayOfOperation);
                    gameConsole.DisplayDailyResults(day, dayOfOperation);
                    gameConsole.DisplaySpoilage(player.store.storeInventory);
                    player.store.RemoveSpoiledInventory();
                    dayOfOperation++;
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You went bankrupt!!");
                    dayOfOperation = maxNumOfDays;
                }

            }

            gameConsole.DisplayFinalResults(player.store);
            Console.WriteLine("Thanks for playing {0}. Goodbye!", player.name);
            Console.ReadLine();
        }
    

        //public bool NoInventory()
        //{
        //    if ((player.franchise.storeInventory.lemonInventory.Count() == 0) || 
        //            (player.franchise.storeInventory.sugarInventory.Count() == 0) || 
        //            (player.franchise.storeInventory.iceInventory.Count() == 0) || 
        //            (player.franchise.storeInventory.cupInventory.Count() == 0))
        //    {
        //        Console.WriteLine("You don't have sufficient inventory to make lemonade. Please buy your ingredients.");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool IsBankrupt()
        //{
        //    if (player.franchise.cashOnHand < minimumCashNeeded)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public void CheckIfSoldOut ()
        //{
        //    //if ((day.numOfBuyingCustomers == day.recipe.maxNumOfCups) || (!EnoughInventory()))
        //    if ((day.numOfBuyingCustomers == day.recipe.maxNumOfCups))
        //    {
        //        Console.WriteLine("You sold out of lemonade!");
        //        day.soldOut = true;
        //    }
            
        //}

        //public void SetProductPrice()
        //{
        //    day.pricePerCup = gameConsole.SetPrice();

        //}
        
        //public void CreateRecipe()
        //{
        //    int availableLemonPitchers;
        //    int availableSugarPitchers;

        //    gameConsole.DisplayInventory(player.franchise.storeInventory);
        //    Console.WriteLine("Set your recipe for the day.");
        //    day.recipe.numOfLemons = gameConsole.SetRecipe("lemons");
        //    day.recipe.numOfSugar = gameConsole.SetRecipe("sugar");
        //    day.recipe.numOfIce = gameConsole.SetRecipe("ice");

        //    if (EnoughInventory())
        //    {
        //        availableLemonPitchers = Convert.ToInt32(player.franchise.storeInventory.lemonInventory.Count() / day.recipe.numOfLemons);
        //        availableSugarPitchers = Convert.ToInt32(player.franchise.storeInventory.sugarInventory.Count() / day.recipe.numOfSugar);

        //        day.recipe.maxNumOfPitchers = Math.Min(availableLemonPitchers, availableSugarPitchers);

        //        day.recipe.maxNumOfCups = day.recipe.maxNumOfPitchers * day.recipe.cupsPerPitcher;
        //    }
        //    else
        //    {
        //        CreateRecipe();
        //    }

        //}

        //public void RemoveUsedInventory()
        //{
        //    player.franchise.storeInventory.lemonInventory.RemoveRange(0, (day.recipe.numOfLemons));
        //    player.franchise.storeInventory.sugarInventory.RemoveRange(0, (day.recipe.numOfSugar));
        //}


        //public bool EnoughInventory()
        //{

        //    if (player.franchise.storeInventory.lemonInventory.Count() < day.recipe.numOfLemons)
        //    {
        //        Console.WriteLine("You don't have enough lemons for your recipe.");
        //        return false;
        //    }
        //    else if (player.franchise.storeInventory.iceInventory.Count() < day.recipe.numOfIce)
        //    {
        //        Console.WriteLine("You don't have enough ice for your recipe.");
        //        return false;
        //    }
        //    else if(player.franchise.storeInventory.sugarInventory.Count() < day.recipe.numOfSugar)
        //    {
        //        Console.WriteLine("You don't have enough sugar for your recipe.");
        //        return false;
        //    }
        //    //else if (player.franchise.storeInventory.cupInventory.Count() < 1)
        //    //{
        //    //    Console.WriteLine("You don't have enough cups to create your recipe!");
        //    //    return false;
        //    //}
        //    return true;
        //}


        //public void SellToCustomers()
        //{
        //        foreach (Customer customer in day.customers)
        //        {
        //            if ((customer.chanceOfPurchase >= day.demandLevel) && (!day.soldOut))
        //            {
        //                    day.numOfBuyingCustomers++;
        //                    player.franchise.storeInventory.cupInventory.RemoveAt(0);
        //                    player.franchise.storeInventory.iceInventory.RemoveRange(0, day.recipe.numOfIce);

        //                    if (((day.numOfBuyingCustomers % day.recipe.cupsPerPitcher) == 0) && (day.numOfPitchers < day.recipe.maxNumOfPitchers))
        //                    {
        //                        MakePitcher();
        //                    }
        //                    day.AddToDailyRevenue(day.pricePerCup);                     
        //            }
        //            if (!day.soldOut)
        //            {
        //                CheckIfSoldOut();
        //            }
        //    }

        //    player.franchise.SetStoreRevenue(day);
        //    player.franchise.AddToStoreCashOnHand(day);

        //}



    //    public void AddLemonInventory()
    //    {
    //        int userInput;
    //        double cost = 0;
    //        Lemon newLemon;
    //        bool addItems = true;
    //        int numOfItemsToAdd = 0;

    //        Console.WriteLine("You have {0} lemons in your inventory.", player.franchise.storeInventory.lemonInventory.Count());
    //        userInput = gameConsole.SetInventory("lemon");

    //        switch (userInput)
    //        {
    //            case 1:
    //                cost = .60;
    //                numOfItemsToAdd = 5;
    //                break;
    //            case 2:
    //                cost = 2.00;
    //                numOfItemsToAdd = 20;
    //                break;
    //            case 3:
    //                cost = 4.00;
    //                numOfItemsToAdd = 50;
    //                break;
    //            default:
    //                addItems = false;
    //                break;
    //        }

    //        if (addItems)
    //        {
    //            if (CheckCashOnHand(cost))
    //            {
    //                for (int i = 1; i <= numOfItemsToAdd; i++)
    //                {
    //                    newLemon = new Lemon();
    //                    player.franchise.storeInventory.lemonInventory.Add(newLemon);
    //                }
    //                player.franchise.AddToStoreExpenses(day);
    //                day.AddToDailyExpenses(cost);
    //                UpdateCashOnHand(cost);
    //            }
    //            else
    //            {
    //                AddLemonInventory();
    //            }
    //        }
    //}


        //public void UpdateCashOnHand(double cost)
        //{
        //    player.franchise.SubtractFromCashOnHand(cost);
            
        //    Console.WriteLine("Cash on hand: {0:$0.00}", player.franchise.cashOnHand);
        //}

        //public void AddSugarInventory()
        //{
        //    int userInput;
        //    double cost = 0;
        //    Sugar newSugar;
        //    bool addItems = true;
        //    int numOfItemsToAdd = 0;

        //    Console.WriteLine("You have {0} sugar in your inventory.", player.franchise.storeInventory.sugarInventory.Count());
        //    userInput = gameConsole.SetInventory("sugar");

        //    switch (userInput)
        //    {
        //        case 1:
        //            cost = .60;
        //            numOfItemsToAdd = 5;
        //            break;
        //        case 2:
        //            cost = 2.00;
        //            numOfItemsToAdd = 20;
        //            break;
        //        case 3:
        //            cost = 9.00;
        //            numOfItemsToAdd = 100;
        //            break;
        //        default:
        //            addItems = false;
        //            break;
        //    }

        //    if (addItems)
        //    {
        //        if (CheckCashOnHand(cost))
        //        {
        //            for (int i = 1; i <= numOfItemsToAdd; i++)
        //            {
        //                newSugar = new Sugar();
        //                player.franchise.storeInventory.sugarInventory.Add(newSugar);
        //            }
        //            player.franchise.AddToStoreExpenses(day);
        //            day.AddToDailyExpenses(cost);
        //            UpdateCashOnHand(cost);
        //        }
        //        else
        //        {
        //            AddSugarInventory();
        //        }
        //    }
        //}

        //public void AddIceInventory()
        //{
        //    int userInput;
        //    double cost = 0;
        //    Ice newIce;
        //    bool addItems = true;
        //    int numOfItemsToAdd = 0;

        //    Console.WriteLine("You have {0} ice cubes in your inventory.", player.franchise.storeInventory.iceInventory.Count());
        //    userInput = gameConsole.SetInventory("ice");

        //    switch (userInput)
        //    {
        //        case 1:
        //            cost = .80;
        //            numOfItemsToAdd = 100;
        //            break;
        //        case 2:
        //            cost = 1.80;
        //            numOfItemsToAdd = 250;
        //            break;
        //        case 3:
        //            cost = 2.50;
        //            numOfItemsToAdd = 500;
        //            break;
        //        default:
        //            addItems = false;
        //            break;
        //    }

        //    if (addItems)
        //    {
        //        if (CheckCashOnHand(cost) && (addItems))
        //        {
        //            for (int i = 1; i <= numOfItemsToAdd; i++)
        //            {
        //                newIce = new Ice();
        //                player.franchise.storeInventory.iceInventory.Add(newIce);
        //            }
        //            player.franchise.AddToStoreExpenses(day);
        //            day.AddToDailyExpenses(cost);
        //            UpdateCashOnHand(cost);
        //        }
        //        else
        //        {
        //            AddIceInventory();
        //        }
        //    }

        //}

        //public void AddCupInventory()
        //{
        //    int userInput;
        //    double cost = 0;
        //    Cup newCup;
        //    bool addItems = true;
        //    int numOfItemsToAdd = 0;

        //    Console.WriteLine("You have {0} cups in your inventory.", player.franchise.storeInventory.cupInventory.Count());
        //    userInput = gameConsole.SetInventory("cup");

        //    switch (userInput)
        //    {
        //        case 1:
        //            cost = 3.00;
        //            numOfItemsToAdd = 50;
        //            break;
        //        case 2:
        //            cost = 5.00;
        //            numOfItemsToAdd = 100;
        //            break;
        //        case 3:
        //            cost = 8.00;
        //            numOfItemsToAdd = 200;
        //            break;
        //        default:
        //            addItems = false;
        //            break;
        //    }

        //    if (addItems)
        //    {
        //        if (CheckCashOnHand(cost))
        //        {
        //            for (int i = 1; i <= numOfItemsToAdd; i++)
        //            {
        //                newCup = new Cup();
        //                player.franchise.storeInventory.cupInventory.Add(newCup);
        //            }
        //            player.franchise.AddToStoreExpenses(day);
        //            day.AddToDailyExpenses(cost);
        //            UpdateCashOnHand(cost);
        //        }
        //        else
        //        {
        //            AddCupInventory();
        //        }
        //    }

        //}


        //public void RemoveSpoiledInventory()
        //{
        //    player.franchise.storeInventory.lemonInventory.RemoveAll(lemon => lemon.numOfDaysBeforeExpiration == 0);
        //    player.franchise.storeInventory.iceInventory.RemoveAll(ice => ice.numOfDaysBeforeExpiration == 0);
        //    player.franchise.storeInventory.sugarInventory.RemoveAll(sugar => sugar.numOfDaysBeforeExpiration == 0);
        //    player.franchise.storeInventory.cupInventory.RemoveAll(cup => cup.numOfDaysBeforeExpiration == 0);
        //}

        //public void SubtractSpoiledDay()
        //{
        //    foreach (Lemon lemon in player.franchise.storeInventory.lemonInventory)
        //    {
        //        lemon.SubtractDayBeforeExpiration();
        //    }

        //    foreach (Sugar sugar in player.franchise.storeInventory.sugarInventory)
        //    {
        //        sugar.SubtractDayBeforeExpiration();
        //    }

        //    foreach (Cup cup in player.franchise.storeInventory.cupInventory)
        //    {
        //        cup.SubtractDayBeforeExpiration();
        //    }

        //    foreach (Ice ice in player.franchise.storeInventory.iceInventory)
        //    {
        //        ice.SubtractDayBeforeExpiration();
        //    }

        //}
    }
}

