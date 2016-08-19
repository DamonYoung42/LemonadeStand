using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Sugar : Ingredient
    {
        public Sugar()
        {
            numOfDaysBeforeExpiration = 3;
        }
        public void SubtractDayBeforeExpiration()
        {
            numOfDaysBeforeExpiration -= 1;
        }
    }
}
