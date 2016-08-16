using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public List<RecipeIngredient> recipeIngredients;
       
        public Recipe()
        {
            recipeIngredients = new List<RecipeIngredient> { };
        }


    }
}
