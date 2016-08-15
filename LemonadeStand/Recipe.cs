using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        string name;
        List<Ingredient> ingredients;

        public Recipe(string name, List<Ingredient> ingredients)
        {
            this.name = name;
            this.ingredients = ingredients;

        }

    }
}
