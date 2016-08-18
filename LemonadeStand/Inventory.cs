using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public List<Lemon> lemonInventory;
        public List<Sugar> sugarInventory;
        public List<Ice> iceInventory;
        public List<Cup> cupInventory;

        public Inventory()
        {
            lemonInventory = new List<Lemon> { };
            sugarInventory = new List<Sugar> { };
            iceInventory = new List<Ice> { };
            cupInventory = new List<Cup> { };

        }




    }
}

 