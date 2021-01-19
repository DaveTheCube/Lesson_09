using System;


namespace Lesson_09S
{
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
            if (playerVictory == true)
            {
                Console.WriteLine("\t### Congratulations You Won! ###"); 
            }
            else
            {
                Console.WriteLine("\t### You lost, try again next time ###");
            }
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
                    Console.WriteLine("Okay {0}, lets play! \nFirst to 3 wins", playerName);
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
                    Console.WriteLine("Incorrect choise.");
                    break;
                }
            }
        }
        static void Game()
        {
            Random cpuChoise = new Random();
            int input = 0;
            Console.WriteLine("### Round {0} ### \n", gameRound);
            Console.WriteLine("Current score is: \n{0}:{1}    cpu:{2} \n\n", playerName, playerPoints, cpuPoints);
            Console.WriteLine("Rock (1), Paper (2) or Scissors (3)?");
            try
            {
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
                Game();
            }
            else
            {
                int cpu = cpuChoise.Next(1,4);
                string playerChoise = Convert.ToString(input);
                switch (playerChoise)
                {
                    case "1":
                    {
                        if (cpu == 2)
                        {
                            Console.WriteLine("You chose: \"Rock\", Your opponent chose: \"Paper\"..... You lose. ");
                            cpuPoints++;
                            gameRound++;
                        }
                        else if (cpu == 1)
                        {
                            Console.WriteLine("You chose: \"Rock\", Your opponent chose: \"Rock\"..... Its a tie. ");
                        }
                        else
                        {
                            Console.WriteLine("You chose: \"Rock\", Your opponent chose: \"Scissors\"..... You Win. ");
                            playerPoints++;
                            gameRound++;
                        }
                        break;
                    }
                    case "2":
                    {
                        if (cpu == 3)
                        {
                            Console.WriteLine("You chose: \"Paper\", Your opponent chose: \"Scissors\"..... You lose. ");
                            cpuPoints++;
                            gameRound++;
                        }
                        else if (cpu == 2)
                        {
                            Console.WriteLine("You chose: \"Paper\", Your opponent chose: \"Paper\"..... Its a tie. ");
                        }
                        else
                        {
                            Console.WriteLine("You chose: \"Paper\", Your opponent chose: \"Rock\"..... You Win. ");
                            playerPoints++;
                            gameRound++;
                        }
                        break;
                    }
                    case "3":
                    {
                        if (cpu == 1)
                        {
                            Console.WriteLine("You chose: \"Scissors\", Your opponent chose: \"Rock\"..... You lose. ");
                            cpuPoints++;
                            gameRound++;
                        }
                        else if (cpu == 3)
                        {
                            Console.WriteLine("You chose: \"Scissors\", Your opponent chose: \"Scissors\"..... Its a tie. ");
                        }
                        else
                        {
                            Console.WriteLine("You chose: \"Scissors\", Your opponent chose: \"Paper\"..... You Win. ");
                            playerPoints++;
                            gameRound++;
                        }
                        break;
                    }
                }
                if (playerPoints == 3)
                {
                    playerVictory = true;
                }
                if (cpuPoints == 3)
                {
                    cpuVictory = true;
                }
                System.Threading.Thread.Sleep(500);

                Console.Clear();
            }
        }
        static void Handeling()
        {

        }
    }
}
