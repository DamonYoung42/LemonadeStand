using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Ice : Ingredient
    {

        public Ice() : base()
        {
            this.name = "ice";
            this.numOfDaysBeforeExpiration = 1;
        } 
    }
}
