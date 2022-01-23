using System;

namespace HealthyHearts
{
    class Program
    {
        static void Main(string[] args)
        {
            int age, hr;
            while (true)
            {
                Console.Write("Enter your age: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out age))
                    break;
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That is not a valid age.");
                    Console.ResetColor();
                }                
            }
            Console.WriteLine("Your maximum heart rate should be " + (hr = (220 - age)) + " beats per minute.");
            Console.WriteLine("Your target HR Zone is {0} - {1} beats per minute.", (hr * .5), (hr * .85));
        }
    }
}
