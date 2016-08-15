using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public string name;
        public List<RecipeIngredient> recipeIngredients;
        public UserInterface inputConsole = new UserInterface();
       
        public Recipe(string name)
        {
            this.name = name;
            recipeIngredients = new List<RecipeIngredient> { };
        }

        public Recipe GetRecipeRequirements()
        {
            Recipe newRecipe = new Recipe("Lemonade");
            int userInput = 0;
            RecipeIngredient ingredient;

            //foreach(Ingredient item in )
            userInput = inputConsole.AskForInput("How many lemons would you like to use per cup in your recipe: ");
            ingredient = new RecipeIngredient("lemon", userInput);
            newRecipe.recipeIngredients.Add(ingredient);

            userInput = inputConsole.AskForInput("How much sugar would you like to use per cup in your recipe: ");
            ingredient = new RecipeIngredient("suger", userInput);
            newRecipe.recipeIngredients.Add(ingredient);

            userInput = inputConsole.AskForInput("How much ice would you like to use per cup in your recipe: ");
            ingredient = new RecipeIngredient("ice", userInput);
            newRecipe.recipeIngredients.Add(ingredient);

            foreach (RecipeIngredient item in newRecipe.recipeIngredients)
            {
                Console.WriteLine(item.name + item.quantity);
            }
            return newRecipe;
        }
    }
}
