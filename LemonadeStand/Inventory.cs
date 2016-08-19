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

        public int GetLemonInventoryCount()
        {
            return lemonInventory.Count();
        }
        public int GetSugarInventoryCount()
        {
            return sugarInventory.Count();
        }

        public int GetCupInventoryCount()
        {
            return cupInventory.Count();
        }

        public int GetIceInventoryCount()
        {
            return iceInventory.Count();
        }

        public void AddToSugarInventory()
        {
            Sugar sugar = new Sugar();
            sugarInventory.Add(sugar);
        }

        public void AddToLemonInventory()
        {
            Lemon lemon = new Lemon();
            lemonInventory.Add(lemon);
        }

        public void AddToIceInventory()
        {
            Ice ice = new Ice();
            iceInventory.Add(ice);
        }

        public void AddToCupInventory()
        {
            Cup cup = new Cup();
            cupInventory.Add(cup);
        }

        public int GetLemonsExpiredCount()
        {
            return lemonInventory.Count(item => item.numOfDaysBeforeExpiration == 0);
        }

        public int GetSugarExpiredCount()
        {
            return sugarInventory.Count(item => item.numOfDaysBeforeExpiration == 0);
        }
        public int GetIceExpiredCount()
        {
            return iceInventory.Count(item => item.numOfDaysBeforeExpiration == 0);
        }
        public int GetCupExpiredCount()
        {
            return cupInventory.Count(item => item.numOfDaysBeforeExpiration == 0);
        }

        public void RemoveCupInventory()
        {
            cupInventory.RemoveAt(0);
        }

        public void RemoveIceInventory(int quantity)
        {
            iceInventory.RemoveRange(0, quantity);
        }

        public void RemoveLemonInventory(int quantity)
        {
           lemonInventory.RemoveRange(0, quantity);
        }

        public void RemoveSugarInventory(int quantity)
        {
            sugarInventory.RemoveRange(0, quantity);
        }
    }
}

 