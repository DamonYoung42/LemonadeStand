using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Ice : Ingredient
    {
        public Ice()
        {
            numOfDaysBeforeExpiration = 1;
        }
        public void SubtractDayBeforeExpiration()
        {
            numOfDaysBeforeExpiration -= 1;
        }
    }
}
