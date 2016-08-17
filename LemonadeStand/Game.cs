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
                    player.franchise.maxNumOfDays = gameConsole.SetDaysofOperation();
                    gameConsole.DisplayWeather(player.franchise);
                    gameConsole.DisplayCash(player.franchise);
                    player.franchise.BuyInventory();
                    player.franchise.CreateRecipe();
                    player.franchise.CheckInventory();
                    player.franchise.SetProductPrice();
                    player.franchise.GenerateDemandLevel();
                    player.franchise.soldOut = false;
                    player.franchise.SellToCustomers();
                    player.franchise.DisplayDailyResults();
                    player.franchise.RemoveSpoiledInventory();

                    player.franchise.dayOfOperation++;

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
