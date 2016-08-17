using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public UserInterface gameConsole;
        public Player player;
        public bool endGame;
        public string playAgain;

        public Game()
        {
            endGame = false;
            gameConsole = new UserInterface();
            gameConsole.IntroduceGame();
            player = new Player(gameConsole.SetPlayerName().ToUpper());

            while (!endGame)
            {
                while ((!player.franchise.bankrupt) && (player.franchise.dayOfOperation <= player.franchise.maxNumOfDays))
                {
                    player.franchise.weatherConditions = new Weather();
                    player.franchise.recipe = new Recipe();
                    player.franchise.DisplayWeather();
                    Console.WriteLine("You have {0:$0.00} cash to buy supplies.", player.franchise.cashOnHand);
                    player.franchise.BuyInventory();
                    player.franchise.CreateRecipe();
                    player.franchise.SetProductPrice();
                    player.franchise.GenerateDemandLevel();
                    player.franchise.soldOut = false;
                    player.franchise.SellToCustomers();
                    player.franchise.DisplayDailyResults();
                    player.franchise.RemoveSpoiledInventory();

                    player.franchise.dayOfOperation++;

                    //create store, set weather, buy inventory, create recipe, set price, sell to customers, update revenue 
                }
                player.franchise.DisplayFinalResults();
                //Console.WriteLine("Do you want to play again - Y/N?");
                //playAgain = Console.ReadLine().ToUpper();

                //if (playAgain == "N")
                //{
                //    endGame = true;
                //}
                //else
                //{
                //    Game game = new Game();
                //}
            }
            Console.WriteLine("Thanks for playing. Goodbye!");
        }
    }
}
