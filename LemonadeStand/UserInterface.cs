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
            Console.WriteLine("Good luck! Let's get started.");
        }
        
        public string SetPlayerName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }

        public int AskForInput(string message)
        {
            Console.WriteLine(message);
            return Convert.ToInt32(Console.ReadLine());
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
