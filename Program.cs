using System;

namespace Lesson_09
{
    public enum Alternatives
    {
        Rock, paper, scissors
    }
    class Program
    {
        public static int gameRound;
        public static int playerPoints;
        public static int cpuPoints;
        public static bool playerVictory;
        public static bool cpuVictory;
        public static string playerName;
    
        static void Main(string[] args)
        {
            Menu();
            while (gameRound <= 5 && playerVictory != true && cpuVictory != true)
            {
                Game();
            }
            ResultCheck();
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
        }
        static void Menu()
        {
            Console.WriteLine("Hello! Would you like to play some \"rock, paper, scissors\"? (y/n)");
            switch (Console.ReadLine())
            {
                case "y":
                {
                    Console.WriteLine("Great, what is you name? ");
                    Console.Write("> ");
                    playerName = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("\nOkay {0}, lets play! \n\nFirst to 3 wins", playerName);
                    Console.WriteLine("\n(Press any key to continue)");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                case "n":
                {
                    Console.WriteLine("Oh .... okay, see you later I guess.");
                    break;
                }
                default:
                {
                    Console.WriteLine("### ERROR: Incorrect choise ###");
                    System.Threading.Thread.Sleep(500);
                    Console.Clear();
                    Menu();
                    break;
                }
            }
        }
        static void Game()
        {
            int input = 0;
            Console.WriteLine("### Round {0} ### \n", gameRound);
            Console.WriteLine("Current score is: \n{0}:{1}    CPU:{2} \n\n", playerName, playerPoints, cpuPoints);
            Console.WriteLine("Rock (1), Paper (2) or Scissors (3)?");
            
            #region ERR input
            try
            {
                Console.Write("> ");
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Console.Clear();
                Game();
            }
            catch (OverflowException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Console.Clear();
                Game();
            }
            if (input < 0 || input > 3)
            {
                Console.WriteLine("Incorrect choise. try again");
                Console.ReadKey();
                Console.Clear();
                Game();
            }
            #endregion
            
            #region Game
            Random cpuChoise = new Random();
            int cpu = cpuChoise.Next(1,4);
            GameBack(input, cpu);
            if (playerPoints == 3)
            {
                playerVictory = true;
            }
            if (cpuPoints == 3)
            {
                cpuVictory = true;
            }
            System.Threading.Thread.Sleep(800);
            Console.Clear();
            #endregion
        }
        static void GameBack(int player, int cpu)
        {
            string message = "You chose: \"" + ((Alternatives)player-1) + "\", Your opponent chose: \"" + ((Alternatives)cpu-1) + "\"..... ";
            if (player == cpu)
            {
                Console.WriteLine(message + "Its a tie.");
            }
            else if (player < cpu || (player == 3 && cpu == 1))
            {
                Console.WriteLine(message + "You Win.");
                playerPoints++;
                gameRound++;
            }
            else
            {
                Console.WriteLine(message + "You lose.");
                cpuPoints++;
                gameRound++;
            }
        }
        static void ResultCheck()
        {
            if (playerVictory == true)
            {
                Console.WriteLine("\n\n\t### Congratulations You Won! ###\n"); 
            }
            else
            {
                Console.WriteLine("\n\n\t### You lost, try again next time ###\n");
            }
        }
    }
}
