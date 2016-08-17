using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public UserInput gameConsole;
        public Player player;
        public bool endGame;
        public string playAgain;

        public Game()
        {
            endGame = false;
            gameConsole = new UserInput();
            gameConsole.IntroduceGame();
            player = new Player(gameConsole.SetPlayerName().ToUpper());
            player.franchise.maxNumOfDays = gameConsole.SetDaysofOperation();
        }

        public void RunGame()
        {
            while (!endGame)
            {
                while ((!player.franchise.bankrupt) && (player.franchise.dayOfOperation <= player.franchise.maxNumOfDays))
                {
                    player.franchise.weatherConditions = new Weather();
                    player.franchise.recipe = new Recipe();
                    player.franchise.soldOut = false;

                    gameConsole.DisplayWeather(player.franchise);
                    gameConsole.DisplayCash(player.franchise);
                    player.franchise.BuyInventory();
                    player.franchise.CreateRecipe();
                    player.franchise.CheckInventory();
                    player.franchise.SetProductPrice();
                    player.franchise.GenerateDemandLevel();
                    player.franchise.GenerateCustomers();
                    player.franchise.SellToCustomers();
                    player.franchise.SubtractSpoiledDay();
                    gameConsole.DisplayDailyResults(player.franchise);
                    player.franchise.RemoveSpoiledInventory();

                    player.franchise.dayOfOperation++;

                }
                gameConsole.DisplayFinalResults(player.franchise);
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
