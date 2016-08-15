using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store : IInventory
    {
        public string name;
        public List<Ingredient> storeInventory;


        public Store(string name)
        {
            string storeName = name;
            List<Ingredient> storeInventory = new List<Ingredient> { };
        }

        public void AddToInventory(Ingredient item)
        {
            storeInventory.Add(item);
        }

        public void SubtractFromInventory(Ingredient item)
        {
            storeInventory.Remove(item);
        }

        public int GetInventoryItemCount(Ingredient item)
        {
            return storeInventory.Count(x => x == item);

        }
        
        //public void CheckForSpoilage()
        //{
        //    return numOfDaysBeforeExpiration;
        //}

    }
}
