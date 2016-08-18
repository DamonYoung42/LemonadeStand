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
        public bool validRecipe;
       
        public Recipe()
        {
            numOfLemons = 0;
            numOfSugar = 0;
            numOfIce = 0;
            maxNumOfCups = 0;
            maxNumOfPitchers = 0;
            cupsPerPitcher = 7;
            validRecipe = true;
        }


    }
}
