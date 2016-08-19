using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    public class UserInput
    {
        protected int inventoryQuantityMin;
        protected int inventoryQuantityMax;
        protected int recipeIngredientQuantityMin;
        protected int recipeIngredientQuantityMax;
        protected int numOfDaysMin;
        protected int numOfDaysMax;
        
        public UserInput()
        {
            inventoryQuantityMin = 1;
            inventoryQuantityMax = 4;
            recipeIngredientQuantityMin = 1;
            recipeIngredientQuantityMax = 5;
            numOfDaysMin = 7;
            numOfDaysMax = 21;
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

        public int SetInventory(string ingredient)
        {
            int option;

            switch (ingredient)
            {
                case "lemon":
                    Console.WriteLine("How many lemons, which spoil after 7 days, would you like to buy?");
                    Console.WriteLine("Option 1: 5 for $0.60");
                    Console.WriteLine("Option 2: 20 for $2.00");
                    Console.WriteLine("Option 3: 50 for $4.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "sugar":
                    Console.WriteLine("How many cups of sugar, which spoil after 3 days, would you like to buy?");
                    Console.WriteLine("Option 1: 5 for $0.60");
                    Console.WriteLine("Option 2: 20 for $2.00");
                    Console.WriteLine("Option 3: 100 for $9.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "ice":
                    Console.WriteLine("How many ice cubes, which spoil each day, would you like to buy?");
                    Console.WriteLine("Option 1: 100 for $0.80");
                    Console.WriteLine("Option 2: 250 for $1.80");
                    Console.WriteLine("Option 3: 500 for $2.50");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;

                case "cup":
                    Console.WriteLine("How many cups, which never spoil, would you like to buy?");
                    Console.WriteLine("Option 1: 50 for $3.00");
                    Console.WriteLine("Option 2: 100 for $5.00");
                    Console.WriteLine("Option 3: 200 for $8.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number (1-4) of your selection:");
                    break;
            }

	        while ((!int.TryParse(Console.ReadLine(), out option)) || ((option < inventoryQuantityMin) || (option > inventoryQuantityMax)))
	        {
                     Console.WriteLine("Please enter one of the four options!");             
	        }
            return option;

        }

        public double SetPrice()
        {
            double price;
            Console.WriteLine("How much will a cup of lemonade cost today?");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Please enter a valid price.");
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
                Console.WriteLine("Please enter a quantity between 1-5.");

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
            Console.WriteLine("The weather forecast for Day {0} calls for {1} degrees and {2} conditions", dayNumber, weather.GetWeatherTemperature(), weather.GetWeatherConditions());
        }

        public void DisplayActualWeather(Weather weather, int dayNumber)
        {
            Console.WriteLine("The actual weather for Day {0} was {1} degrees and {2} skies", dayNumber, weather.GetWeatherTemperature(), weather.GetWeatherConditions());
        }

        public void DisplayCash(Store store)
        {
            Console.WriteLine("You have {0:$0.00} cash to buy supplies.", store.GetCashOnHand());
        }

        public void DisplayDailyResults(Day day, int dayNumber)
        {
            Console.WriteLine("You had {0} potential customers and sold {1} cups of lemonade for {2:$0.00} in revenue on Day {3}.", day.GetNumOfCustomers(), 
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
            Console.WriteLine("You made {0:$0.00} in total revenue.", store.GetTotalRevenue());
            Console.WriteLine("You spent {0:$0.00} on inventory.", store.GetTotalExpenses());
            Console.WriteLine("You made a net profit of {0:$0.00}", store.GetTotalRevenue() - store.GetTotalExpenses());
        }
    }
}
