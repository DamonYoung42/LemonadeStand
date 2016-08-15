using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        UserInterface gameConsole;
        Player player;

        public Game()
        {
            gameConsole = new UserInterface();

            
            gameConsole.IntroduceGame();
            player = new Player(gameConsole.SetPlayerName().ToUpper());
            player.franchise.BuyInventory();
            //create store, set weather, buy inventory, create recipe, set price, sell to customers, update profit, 
            Console.ReadLine();


        }

    }
}
