using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public int numOfLemons;
        public int numOfSugar;
        public int numOfIce;
        public int maxNumOfCups;
        public int maxNumOfPitchers;
        public int cupsPerPitcher;
       
        public Recipe()
        {
            numOfLemons = 0;
            numOfSugar = 0;
            numOfIce = 0;
            maxNumOfCups = 0;
            maxNumOfPitchers = 0;
            cupsPerPitcher = 10;
        }




        public int GetNumberOfLemons()
        {
            return numOfLemons;
        }

        public int GetNumberOfSugar()
        {
            return numOfSugar;
        }

        public int GetNumberOfIce()
        {
            return numOfIce;
        }

        public int GetMaxNumberOfCups()
        {
            return maxNumOfCups;
        }

        public int GetMaxNumberOfPitchers()
        {
            return maxNumOfPitchers;
        }

        public int GetCupsPerPitcher()
        {
            return cupsPerPitcher;
        }
        public void SetMaxNumberOfPitchers(int availableLemonPitchers, int availableSugarPitchers)
        {

            maxNumOfPitchers= Math.Min(availableLemonPitchers, availableSugarPitchers);
        }

        public void SetMaxNumberOfCups(Inventory inventory)
        {

            maxNumOfCups = Math.Min((maxNumOfPitchers * cupsPerPitcher), Math.Min((inventory.GetIceInventoryCount()/GetNumberOfIce()), inventory.GetCupInventoryCount()));
        }


    }
}
