using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LemonadeStand
{
    public class Game
    {
        public UserInput gameConsole;
        public Player player;
        public Day day;
        public int maxNumOfDays;
        public int dayOfOperation;
        public FileInputOutput savedData;
        public Dictionary<string, string> savedResults;



        public Game()
        {
            savedData = new FileInputOutput();
            gameConsole = new UserInput();
            gameConsole.IntroduceGame();
            dayOfOperation = 1;


        }
        public void RunGame()
        {

            player = new Player(gameConsole.SetPlayerName().ToUpper());

            maxNumOfDays = gameConsole.SetDaysofOperation();

            while (dayOfOperation < maxNumOfDays + 1)
            {
                day = new Day();
                if (day.RunDay(gameConsole, player.store, dayOfOperation))
                {
                    gameConsole.DisplayDailyResults(day, dayOfOperation);
                    savedData.WriteDailyResults(day, dayOfOperation);
                    gameConsole.DisplaySpoilage(player.store.storeInventory);
                    player.store.RemoveSpoiledInventory();
                    dayOfOperation++;
                    Console.WriteLine("Press any key to continue:");
                    Console.ReadKey();
                    if (dayOfOperation > maxNumOfDays)
                    {
                        gameConsole.DisplayFinalResults(player.store);
                    }
                }
                else
                {
                    Console.WriteLine("\nYou don't enough supplies to make lemonade and you don't have enough money to buy more ingredients. You have gone bankrupt!!");
                    dayOfOperation = maxNumOfDays + 1;
                }

            }


            Console.WriteLine("\nThanks for playing {0}. Goodbye!", player.name);
            Console.ReadLine();
        }
    }

}