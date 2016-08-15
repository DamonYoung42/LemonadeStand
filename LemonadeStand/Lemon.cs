using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon : Ingredient
    {
        public Lemon() : base()
        {
            this.name = "lemon";
            this.numOfDaysBeforeExpiration = 7;
        }
    }
}
