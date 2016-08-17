using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class UserInterface
    {
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


	        while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < 1) || (quantity > 4)))
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
            while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity < 1) || (quantity > 5)))
            {
                Console.WriteLine("Enter a quantity between 1-5.");

            }
            return quantity;

        }

        public int SetDaysofOperation()
        {
            int quantity;
            Console.WriteLine("How many days would you like to be open for business?");
            while ((!int.TryParse(Console.ReadLine(), out quantity)) || ((quantity <= 6) || (quantity > 21)))
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
