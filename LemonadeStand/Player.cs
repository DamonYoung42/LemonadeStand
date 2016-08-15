using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public string name;
        public int numOfDays;
        public float totalRevenue;
        public Store franchise;

        public Player(string name)
        {
            this.name = name;
            totalRevenue = 0;
            numOfDays = 0;
            franchise = new Store();
        }

    }
}
