using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        string name;
        List<Ingredient> ingredients;

        public Recipe(string name, List<Ingredient> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;

        }

        //public bool CanMakeRecipe()
        //{
        //    foreach (Ingredient item in ingredients)
        //    {
        //        if (item.CheckInventory() > item.quantityAvailable)
        //        {
        //            return false; // can't make recipe because ingredient not available
        //        }     
                
        //    }
        //    return true;

        //}
    }
}
