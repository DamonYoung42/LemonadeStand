using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {

        public Inventory storeInventory;
        public double cashOnHand;
        public int dailyCupsSold;
        public double totalRevenue;
        public double totalExpenses;
        public int maxNumOfDays;

        public double minimumLemonCashNeeded;
        public double minimumSugarCashNeeded;
        public double minimumIceCashNeeded;
        public double minimumCupCashNeeded;

        public int[] lemonMenuQuantities;
        public int[] sugarMenuQuantities;
        public int[] iceMenuQuantities;
        public int[] cupMenuQuantities;
        public double[] lemonMenuPrices;
        public double[] sugarMenuPrices;
        public double[] iceMenuPrices;
        public double[] cupMenuPrices;

        public Store()
        {
            storeInventory = new Inventory();
            cashOnHand = 20.00;
            maxNumOfDays = 0;
            totalRevenue = 0;
            totalExpenses = 0;
            minimumLemonCashNeeded = .60;
            minimumSugarCashNeeded = .60;
            minimumIceCashNeeded = .80;
            minimumCupCashNeeded = 3.00;

            lemonMenuQuantities = new int[4] { 5, 20, 50, 0 };
            sugarMenuQuantities = new int[4] { 5, 20, 100, 0 };
            iceMenuQuantities = new int[4] { 100, 250, 500, 0 };
            cupMenuQuantities = new int[4] { 50, 100, 200, 0 };
            lemonMenuPrices = new double[4] { 0.60, 2.00, 4.00, 0 };
            sugarMenuPrices = new double[4] { 0.60, 2.00, 9.00, 0 };
            iceMenuPrices = new double[4] { 0.80, 1.80, 2.50, 0 };
            cupMenuPrices = new double[4] { 3.00, 5.00, 8.00, 0 };

        }
 
        public void SetStoreRevenue(double revenue)
        {
            totalRevenue += revenue;
        }

        public void AddToStoreExpenses(double expense)
        {
            totalExpenses += expense;
        }

        public void AddToStoreCashOnHand(double revenue)
        {
            cashOnHand += revenue;
        }

        public void SubtractFromCashOnHand(double cost)
        {
            cashOnHand -= cost;

        }

        public double GetCashOnHand()
        {
            return cashOnHand;
        }

        public void RemoveSpoiledInventory()
        {
            storeInventory.lemonInventory.RemoveAll(lemon => lemon.numOfDaysBeforeExpiration == 0);
            storeInventory.iceInventory.RemoveAll(ice => ice.numOfDaysBeforeExpiration == 0);
            storeInventory.sugarInventory.RemoveAll(sugar => sugar.numOfDaysBeforeExpiration == 0);
            storeInventory.cupInventory.RemoveAll(cup => cup.numOfDaysBeforeExpiration == 0);
        }

        public void SubtractSpoiledDay()
        {
            foreach (Lemon lemon in storeInventory.lemonInventory)
            {
                lemon.SubtractDayBeforeExpiration();
            }

            foreach (Sugar sugar in storeInventory.sugarInventory)
            {
                sugar.SubtractDayBeforeExpiration();
            }

            foreach (Cup cup in storeInventory.cupInventory)
            {
                cup.SubtractDayBeforeExpiration();
            }

            foreach (Ice ice in storeInventory.iceInventory)
            {
                ice.SubtractDayBeforeExpiration();
            }
        }

        public void RemoveUsedInventory(Recipe recipe)
        {
            storeInventory.RemoveLemonInventory(recipe.GetNumberOfLemons());
            storeInventory.RemoveSugarInventory(recipe.GetNumberOfSugar());
        }

        public bool EnoughInventory(Recipe recipe)
        {

            if (storeInventory.lemonInventory.Count() < recipe.numOfLemons)
            {
                Console.WriteLine("You don't have enough lemons for your recipe.");
                return false;
            }
            else if (storeInventory.iceInventory.Count() < recipe.numOfIce)
            {
                Console.WriteLine("You don't have enough ice for your recipe.");
                return false;
            }
            else if (storeInventory.sugarInventory.Count() < recipe.numOfSugar)
            {
                Console.WriteLine("You don't have enough sugar for your recipe.");
                return false;
            }
            //else if (player.franchise.storeInventory.cupInventory.Count() < 1)
            //{
            //    Console.WriteLine("You don't have enough cups to create your recipe!");
            //    return false;
            //}
            return true;
        }

        public bool NoInventory()
        {
            if ((storeInventory.lemonInventory.Count() == 0) ||
                    (storeInventory.sugarInventory.Count() == 0) ||
                    (storeInventory.iceInventory.Count() == 0) ||
                    (storeInventory.cupInventory.Count() == 0))
            {
                Console.WriteLine("You don't have sufficient inventory to make lemonade.");
                return true;
            }
            return false;
        }

        public bool IsBankrupt()
        {
            
            if (((storeInventory.GetLemonInventoryCount() == 0) && (GetCashOnHand() < minimumLemonCashNeeded)) ||
                    ((storeInventory.GetSugarInventoryCount() == 0) && (GetCashOnHand() < minimumSugarCashNeeded)) ||
                    ((storeInventory.GetIceInventoryCount() == 0) && (GetCashOnHand() < minimumIceCashNeeded)) ||
                    ((storeInventory.GetCupInventoryCount() == 0) && (GetCashOnHand() < minimumCupCashNeeded)))
                    
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double GetTotalRevenue()
        {
            return totalRevenue;
        }

        public double GetTotalExpenses()
        {
            return totalExpenses;
        }

        public Inventory GetStoreInventory()
        {
            return storeInventory;
        }
    }
}

