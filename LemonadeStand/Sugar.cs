using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Sugar : Ingredient
    {

        public Sugar() : base()
        {
            this.name = "sugar";
            this.numOfDaysBeforeExpiration = 3;
        }
    }
}
