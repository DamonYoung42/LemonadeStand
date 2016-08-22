using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    public class UserInput
    {
        private int inventoryOptionMin;
        private int inventoryOptionMax;
        private int recipeIngredientQuantityMin;
        private int recipeIngredientQuantityMax;
        private int numOfDaysMin;
        private int numOfDaysMax;
        private double priceMax;
        private double priceMin;
        
        public UserInput()
        {
            inventoryOptionMin = 1;
            inventoryOptionMax = 4;
            recipeIngredientQuantityMin = 1;
            recipeIngredientQuantityMax = 10;
            numOfDaysMin = 7;
            numOfDaysMax = 21;
            priceMax = 2.00;
            priceMin = 0.01;
        }

        public void IntroduceGame()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("You'll create your own recipe and try to sell as much you can over a period of days.");
            Console.WriteLine("The amount of lemonade you sell is affected by weather and the price you set.");
            Console.WriteLine("Good luck! Let's get started. You have $20.00 to start buying inventory.");
        }

        public string SetPlayerName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public int SetInventory(string ingredient, Store store)
        {
            int option;

            switch (ingredient)
            {
                case "lemon":
                    Console.WriteLine("\nYou have {0} lemons in your inventory.", store.storeInventory.GetLemonInventoryCount());
                    Console.WriteLine("\nHow many lemons, which spoil after 7 days, would you like to buy?");
                    Console.WriteLine("Option 1: {0} for {1:$0.00}", store.lemonMenuQuantities[0], store.lemonMenuPrices[0]);
                    Console.WriteLine("Option 2: {0} for {1:$0.00}", store.lemonMenuQuantities[1], store.lemonMenuPrices[1]);
                    Console.WriteLine("Option 3: {0} for {1:$0.00}", store.lemonMenuQuantities[2], store.lemonMenuPrices[2]);
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "sugar":
                    Console.WriteLine("\nYou have {0} cups of sugar in your inventory.", store.storeInventory.GetSugarInventoryCount());
                    Console.WriteLine("\nHow many cups of sugar, which spoil after 3 days, would you like to buy?");
                    Console.WriteLine("Option 1: {0} for {1:$0.00}", store.sugarMenuQuantities[0], store.sugarMenuPrices[0]);
                    Console.WriteLine("Option 2: {0} for {1:$0.00}", store.sugarMenuQuantities[1], store.sugarMenuPrices[1]);
                    Console.WriteLine("Option 3: {0} for {1:$0.00}", store.sugarMenuQuantities[2], store.sugarMenuPrices[2]);
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "ice":
                    Console.WriteLine("\nYou have {0} ice cubes in your inventory.", store.storeInventory.GetIceInventoryCount());
                    Console.WriteLine("\nHow many ice cubes, which spoil each day, would you like to buy?");
                    Console.WriteLine("Option 1: {0} for {1:$0.00}", store.iceMenuQuantities[0], store.iceMenuPrices[0]);
                    Console.WriteLine("Option 2: {0} for {1:$0.00}", store.iceMenuQuantities[1], store.iceMenuPrices[1]);
                    Console.WriteLine("Option 3: {0} for {1:$0.00}", store.iceMenuQuantities[2], store.iceMenuPrices[2]);
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "cup":
                    Console.WriteLine("\nYou have {0} cups in your inventory.", store.storeInventory.GetCupInventoryCount());
                    Console.WriteLine("\nHow many cups, which never spoil, would you like to buy?");
                    Console.WriteLine("Option 1: {0} for {1:$0.00}", store.cupMenuQuantities[0], store.cupMenuPrices[0]);
                    Console.WriteLine("Option 2: {0} for {1:$0.00}", store.cupMenuQuantities[1], store.cupMenuPrices[1]);
                    Console.WriteLine("Option 3: {0} for {1:$0.00}", store.cupMenuQuantities[2], store.cupMenuPrices[2]);
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;
            }

	        while ((!int.TryParse(Console.ReadLine(), out option)) || ((option < inventoryOptionMin) || (option > inventoryOptionMax)))
	        {
                     Console.WriteLine("Please enter one of the four options!");             
	        }
            return option;

        }

        public double SetPrice()
        {
            double price;
            Console.WriteLine("How much will a cup of lemonade cost today?");
            while ((!double.TryParse(Console.ReadLine(), out price)) || ((price < priceMin) || (price > priceMax)))
            {
                Console.WriteLine("Please enter a price from {0:$0.00}-{1:$0.00}.", priceMin, priceMax);
            }
            return price;
        }

        public int SetRecipe(string ingredient)
        {
            int quantity;
            switch (ingredient)
            {
                case "ice":
                    Console.WriteLine("How many ice cubes per cup?");
                    break;
                case "sugar":
                    Console.WriteLine("How many cups of sugar per pitcher");
                    break;
                default:
                    Console.WriteLine("How many {0} per pitcher?", ingredient);
                    break;

            }

            while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < recipeIngredientQuantityMin) || (quantity > recipeIngredientQuantityMax)))
            {
                Console.WriteLine("Please enter a quantity between 1-10.");

            }
            return quantity;

        }

        public int SetDaysofOperation()
        {
            int quantity;
            Console.WriteLine("How many days (7-21) would you like to be open for business?");
            while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < numOfDaysMin) || (quantity > numOfDaysMax)))
            {
                {
                    Console.WriteLine("Enter a number between 7-21.");

                }
            }
            return quantity;
        }

        public void DisplayWeatherForecast(Weather weather, int dayNumber)
        {
            Console.WriteLine("\nThe weather forecast for Day {0} calls for {1} degrees and {2} conditions", dayNumber, weather.GetWeatherTemperature(), weather.GetWeatherConditions().ToLower());
        }

        public void DisplayActualWeather(Weather weather, int dayNumber)
        {
            Console.WriteLine("\nThe actual weather for Day {0} was {1} degrees and {2} skies", dayNumber, weather.GetWeatherTemperature(), weather.GetWeatherConditions().ToLower());
        }

        public void DisplayCash(Store store)
        {
            Console.WriteLine("\nYou have {0:$0.00} to buy supplies.", store.GetCashOnHand());
        }

        public void DisplayDailyResults(Day day, int dayNumber)
        {
            Console.WriteLine("\nYou had {0} potential customers and sold {1} cups of lemonade for {2:$0.00} in revenue on Day {3}.", day.GetNumOfCustomers(), 
                day.GetNumOfBuyingCustomers(), day.GetDailyRevenue(), dayNumber);
            Console.WriteLine("Your total expenses for Day {0} equaled {1:$0.00}.", dayNumber, day.GetDailyExpenses());
            Console.WriteLine("Your net income for Day {0} was {1:$0.00}", dayNumber, (day.GetDailyRevenue() - day.GetDailyExpenses()));

        }

        public void DisplayInventory(Inventory inventory)
        {
            Console.WriteLine("Your inventory includes {0} lemons, {1} cups of sugar, {2} ice cubes and {3} cups.", inventory.GetLemonInventoryCount(), inventory.GetSugarInventoryCount(), inventory.GetIceInventoryCount(), inventory.GetCupInventoryCount());
        }

        public void DisplaySpoilage(Inventory inventory)
        {
            Console.WriteLine("You lost {0} lemons, {1} sugars and {2} ice cubes to spoilage.", +
            inventory.GetLemonsExpiredCount(),
            inventory.GetSugarExpiredCount(),
            inventory.GetIceExpiredCount());
        }

        public void DisplayFinalResults(Store store)
        {
            Console.WriteLine("Your stand is now closed. You collected {0:$0.00} in revenue and spent {1:$0.00} on supplies for a net income of {2:$0.00}.",
                store.GetTotalRevenue(), store.GetTotalExpenses(), store.GetTotalRevenue() - store.GetTotalExpenses()); 
                
        }
    }
}
