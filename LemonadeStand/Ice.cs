using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice : Ingredient
    {
        int numOfDaysBeforeExpiration;

        public Ice()
        {
            numOfDaysBeforeExpiration = 1;
        } 
    }
}
