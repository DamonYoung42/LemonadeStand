using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Cup : Ingredient
    {

        public Cup() : base()
        {
            this.name = "cup";
            this.numOfDaysBeforeExpiration = 100;
        }
    }
}
