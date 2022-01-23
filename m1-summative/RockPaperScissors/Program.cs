using Microsoft.VisualBasic;
using System;
using System.Runtime.ConstrainedExecution;

namespace RockPaperScissors
{
    class Program
    {
        static void WriteError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("That is an invalid response.");
            Console.ResetColor();
        }
        static void Beep(int b) ///bonus music at end
        {
            if (b == 1)
            {
                Console.Beep(494, 500);
                Console.Beep(622, 500);
                Console.Beep(740, 500);
                Console.Beep(987, 500);
            }
            else if (b == 2)
            {
                ///Console.Beep(987, 500);
                Console.Beep(740, 500);
                Console.Beep(587, 500);
                Console.Beep(494, 500);
            }
            else
            {
                Console.Beep(494, 500);
                Console.Beep(370, 500);
                Console.Beep(494, 500);
            }
        }
        static void Colorize(int l) ///bonus aesthetic message colorizor
        {
            string win = @"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗ ██████╗ ███╗   ██╗    ██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██╔═══██╗████╗  ██║    ██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║   ██║██╔██╗ ██║    ██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║   ██║██║╚██╗██║    ╚═╝
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝╚██████╔╝██║ ╚████║    ██╗
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝  ╚═════╝ ╚═╝  ╚═══╝    ╚═╝


", loss = @"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗      ██████╗ ███████╗████████╗    
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║     ██╔═══██╗██╔════╝╚══██╔══╝    
 ╚████╔╝ ██║   ██║██║   ██║    ██║     ██║   ██║███████╗   ██║       
  ╚██╔╝  ██║   ██║██║   ██║    ██║     ██║   ██║╚════██║   ██║       
   ██║   ╚██████╔╝╚██████╔╝    ███████╗╚██████╔╝███████║   ██║       
   ╚═╝    ╚═════╝  ╚═════╝     ╚══════╝ ╚═════╝ ╚══════╝   ╚═╝       


",
                tie = @"
██╗    ██╗███████╗    ████████╗██╗███████╗██████╗     
██║    ██║██╔════╝    ╚══██╔══╝██║██╔════╝██╔══██╗    
██║ █╗ ██║█████╗         ██║   ██║█████╗  ██║  ██║    
██║███╗██║██╔══╝         ██║   ██║██╔══╝  ██║  ██║    
╚███╔███╔╝███████╗       ██║   ██║███████╗██████╔╝    
 ╚══╝╚══╝ ╚══════╝       ╚═╝   ╚═╝╚══════╝╚═════╝     


", s;
            if (l == 1)
                s = win;
            else if (l == 2)
                s = loss;
            else
                s = tie;
            int slength = s.Length;
            int color;
            char[] sChar = s.ToCharArray();
            for (int i = 0; i < slength; i++)
            {
                if (s == win)
                {
                    Random rnd = new Random();
                    color = rnd.Next(1, 3);
                }
                else if (s == loss)
                {
                    Random rnd = new Random();
                    color = rnd.Next(3, 5);
                }
                else
                    color = 5;
                switch (color)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(sChar[i]);
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(sChar[i]);
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(sChar[i]);
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write(sChar[i]);
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(sChar[i]);
                        break;
                }

            }
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            int rounds,
                userChoice,
                compChoice;
            string input;

            while (true) /// y/n program loop
            {
                int wins = 0,
                ties = 0,
                losses = 0;
                while (true) /// # of rounds tryparse loop
                {
                    Console.Write("-How many rounds would you like to play? (1-10) ");

                    input = Console.ReadLine();
                    if (!int.TryParse(input, out rounds) || rounds > 10 || rounds < 1)                        
                    {
                        WriteError();
                        ///Console.WriteLine("Exiting...");
                        ///Environment.Exit(0); /// not sure why, but directions said to quit program if out of bounds.
                        continue;
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("OK! Let's play " + rounds + " round(s).");
                    Console.ResetColor();
                    Console.WriteLine("\n------------------\n");
                    break;
                }
                for (int i = 1; i <= rounds; i++)
                {
                    while (true) /// 1/2/3 tryparse loop
                    {

                        if (rounds == 1)
                            Console.Write("Rock (1), Paper (2), or Scissors (3)? ");
                        else if (i == rounds)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("---Final Round!---");
                            Console.ResetColor();
                            Console.Write("Rock (1), Paper (2), or Scissors (3)? ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("---Round " + i + "!---");
                            Console.ResetColor();
                            Console.Write("Rock (1), Paper (2), or Scissors (3)? ");
                        }

                        input = Console.ReadLine();
                        int.TryParse(input, out userChoice);

                        if (userChoice >= 1 && userChoice <= 3)
                            break;
                        else
                            WriteError();
                    }

                    Random rnd = new Random();
                    compChoice = rnd.Next(1, 4);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    {
                        Console.Write("You chose ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (userChoice == 1)
                            Console.Write("rock,");
                        else if (userChoice == 2)
                            Console.Write("paper,");
                        else
                            Console.Write("scissors,");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" but I chose ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        if (compChoice == 1)
                            Console.Write("rock!\n");
                        else if (compChoice == 2)
                            Console.Write("paper!\n");
                        else
                            Console.Write("scissors!\n");
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    {
                        if (compChoice == userChoice)
                        {
                            Console.WriteLine("---This round is a tie.");
                            ties++;
                        }
                        else if ((userChoice == 1 && compChoice == 3) || (userChoice == 2 && compChoice == 1) || (userChoice == 3 && compChoice == 2))
                        {
                            Console.WriteLine("---Round won!");
                            wins++;
                        }
                        else
                        {
                            Console.WriteLine("---Round lost.");
                            losses++;
                        }

                        Console.WriteLine("");
                    }
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                if (wins > losses)
                {
                    Colorize(1); ///win
                    Beep(1);
                }

                else if (wins < losses)
                {
                    Colorize(2); ///lose
                    Beep(2);
                }
                else
                {
                    Colorize(3); ///tie
                    Beep(3);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine("Wins: " + wins + ", losses: " + losses + ", ties: " + ties);
                Console.ResetColor();

                while (true) ///check user; need y/n
                {
                    Console.Write("-Do you wish to play again? Enter \"y\" or \"n\": ");
                    input = Console.ReadLine().ToLower();
                    if (input == "y" || input == "n")
                        break;

                    WriteError();
                }

                if (input == "y")
                {
                    Console.Clear();
                    continue;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Thanks for playing!");
                Console.ResetColor();
                break;

            }
        }
    }
}

