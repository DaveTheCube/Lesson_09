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
                    System.Threading.Thread.Sleep(800);
                    System.Environment.Exit(0);
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
            #region Game
            Game:
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
                input = 0;
                Console.ReadKey();
                Console.Clear();
                goto Game;
            }
            catch (OverflowException e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                Console.WriteLine("Press any key to try again");
                input = 0;
                Console.ReadKey();
                Console.Clear();
                goto Game;
            }
            if (input < 0 || input > 3)
            {
                Console.WriteLine("Incorrect choise. try again");
                input = 0;
                Console.ReadKey();
                Console.Clear();
                goto Game;
            }
            #endregion
            
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
            Console.ReadKey();
            Console.Clear();
            #endregion
        }
        static void GameBack(int player, int cpu)
        {
            if (player == cpu)
            {
                Console.WriteLine("You chose: \"{0}\", Your opponent chose: \"{0}\"..... Its a tie. ", (Alternatives)player -1);
            }
            else if (player == 1+cpu || (player == 1 && cpu == 3))
            {
                Console.WriteLine("You chose: \"{0}\", Your opponent chose: \"{1}\"..... You Win. ", (Alternatives)player -1 , (Alternatives)cpu -1);
                playerPoints++;
                gameRound++;
            }
            else
            {
                Console.WriteLine("You chose: \"{0}\", Your opponent chose: \"{1}\"..... You lose. ", (Alternatives)player -1 , (Alternatives)cpu -1);
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
