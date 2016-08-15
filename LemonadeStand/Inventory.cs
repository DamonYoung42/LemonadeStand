using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Inventory
    {
        int available;
        int numOfDaysBeforeExpiration;

        public void AddToInventory()
        {
            available += 1;
        }

        public void SubtractFromInventory()
        {
            available -= 1;
        }

        public int CheckInventory()
        {
            return available;
        }

        public int CheckForSpoilage()
        {
            return numOfDaysBeforeExpiration;
        }
    }

}
