using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon : Ingredient
    {
        int numOfDaysBeforeExpiration;

        public Lemon()
        {
            numOfDaysBeforeExpiration = 7;
        }
    }
}
