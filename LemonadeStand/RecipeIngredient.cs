using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class RecipeIngredient
    {
        public string name;
        public int quantity;

        public RecipeIngredient(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }
    }
}
