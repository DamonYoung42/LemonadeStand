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
            Console.WriteLine("You'll create your own recipe and try to sell as much you can over seven days.");
            Console.WriteLine("The amount of cups you sell is affected by weather and the price you set.");
            Console.WriteLine("Good luck! Let's get started. You have $10.00 to start buying inventory.");
        }
        
        public string SetPlayerName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public int SetInventory(string ingredient)
        {
            int quantity;

            switch (ingredient)
            {
                case "lemon":
                    Console.WriteLine("How many lemons would you like to buy?");
                    Console.WriteLine("Option 1: 5 for $0.60");
                    Console.WriteLine("Option 2: 20 for $2.00");
                    Console.WriteLine("Option 3: 50 for $4.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number of your selection:");
                    break;

                case "sugar":
                    Console.WriteLine("How much sugar would you like to buy?");
                    Console.WriteLine("Option 1: 5 for $0.60");
                    Console.WriteLine("Option 2: 20 for $2.00");
                    Console.WriteLine("Option 3: 100 for $9.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number of your selection:");
                    break;

                case "ice":
                    Console.WriteLine("How many ice cubes would you like to buy?");
                    Console.WriteLine("Option 1: 100 for $0.80");
                    Console.WriteLine("Option 2: 250 for $1.80");
                    Console.WriteLine("Option 3: 500 for $2.50");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number of your selection:");
                    break;

                case "cup":
                    Console.WriteLine("How many cups would you like to buy?");
                    Console.WriteLine("Option 1: 50 for $3.00");
                    Console.WriteLine("Option 2: 100 for $5.00");
                    Console.WriteLine("Option 3: 200 for $8.00");
                    Console.WriteLine("Option 4: Keep current inventory level");
                    Console.WriteLine("Please enter the number of your selection:");
                    break;

            }


	        while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < inventoryQuantityMin) || (quantity > inventoryQuantityMax)))
	        {
                     Console.WriteLine("Enter one of the four options!");             
	        }
            return quantity;

        }

        public double SetPrice()
        {
            double price;
            Console.WriteLine("How much will a cup of lemonade cost today?");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Enter a valid price.");

            }
            return price;
        }

        public int SetRecipe(string ingredient)
        {
            int quantity;
            Console.WriteLine("How many {0} per cup?", ingredient);

            while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < recipeIngredientQuantityMin) || (quantity > recipeIngredientQuantityMax)))
            {
                Console.WriteLine("Enter a quantity between 1-5.");

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

        public void DisplayWeather(Store store)
        {
            Console.WriteLine("The weather forecast for Day {0} is {1} and {2}", store.dayOfOperation, store.weatherConditions.temperature, store.weatherConditions.conditions);
        }

        public void DisplayCash(Store store)
        {
            Console.WriteLine("You have {0:$0.00} cash to buy supplies.", store.cashOnHand);
        }

        public void DisplayDailyResults(Store store)
        {
            Console.WriteLine("You had {0} customers and sold {1} cups of lemonade for {2:$0.00} in revenue on Day {3}.", store.dailyNumOfCustomers, store.dailyCupsSold, store.dailyRevenue, store.dayOfOperation);
            Console.WriteLine("Your total expenses for the day equaled {0:$0.00}.", store.dailyExpenses);
            Console.WriteLine("Your net income for Day {0} was {1:$0.00}", store.dayOfOperation, (store.dailyRevenue - store.dailyExpenses));
            Console.WriteLine("You lost {0} lemons, {1} sugars and {2} ice cubes to spoilage.", +
                store.storeInventory.lemonInventory.Count(item => item.numOfDaysBeforeExpiration == 0), +
                store.storeInventory.iceInventory.Count(item => item.numOfDaysBeforeExpiration == 0), +
                store.storeInventory.sugarInventory.Count(item => item.numOfDaysBeforeExpiration == 0));
        }

        public void DisplayFinalResults(Store store)
        {
            Console.WriteLine("You made {0:$0.00} in total revenue.", store.totalRevenue);
            Console.WriteLine("You spent {0:$0.00} on inventory.", store.totalExpenses);
            Console.WriteLine("You made a net profit of {0:$0.00}", store.totalRevenue - store.totalExpenses);
        }
        //public Recipe GetRecipeRequirements()
        //{
        //    Recipe newRecipe = new Recipe("Lemonade");
        //    int userInput;
        //    RecipeIngredient ingredient;

        //    Console.WriteLine("How many lemons would you like to use per cup in your recipe:");
        //    userInput = Convert.ToInt32(Console.ReadLine());
        //    ingredient = new RecipeIngredient("lemon", userInput);
        //    newRecipe.recipeIngredients.Add(ingredient);

        //    Console.WriteLine("How much sugar would you like to use per cup in your recipe:");
        //    userInput = Convert.ToInt32(Console.ReadLine());
        //    ingredient = new RecipeIngredient("suger", userInput);
        //    newRecipe.recipeIngredients.Add(ingredient);

        //    Console.WriteLine("How many ice cubes would you like to use per cup in your recipe:");
        //    userInput = Convert.ToInt32(Console.ReadLine());
        //    ingredient = new RecipeIngredient("ice", userInput);
        //    newRecipe.recipeIngredients.Add(ingredient);

        //    foreach (RecipeIngredient item in newRecipe.recipeIngredients)
        //    {
        //        Console.WriteLine(item.name + item.quantity);
        //    }
        //    return newRecipe;
        //}

        //public void BuyInventory(Store storeName)
        //{



        //}
    }
}
