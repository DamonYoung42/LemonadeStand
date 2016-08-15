using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    interface IInventory
    {
        int GetInventoryItemCount(Ingredient item);
        void AddToInventory(Ingredient item);
        void SubtractFromInventory(Ingredient item);
        //void CheckForSpoilage();

    }


}
