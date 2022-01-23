using System;
using System.Collections.Generic;
using System.Text;
using BetterYahtzee.BLL;

namespace BetterYahtzee.UI
{
    class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                         _                  _   __                       __                                             ");
            Console.WriteLine("                        FJ         ____    FJ_  FJ  ____        _ ___    LJ    ___ _    _    _                          ");
            Console.WriteLine("                       J |        F __ J  J  _| L- F ___J      J '__ J   FJ   F __` L  J |  | L                         ");
            Console.WriteLine("                       | |       | _____J | |-' - | '----_     | |--| | J  L | |--| |  | |  | |                         ");
            Console.WriteLine("                       F L_____  F L___--.F |__-. )-____  L    F L__J J J  L F L__J J  F L__J J                         ");
            Console.WriteLine(@"                      J________LJ\______/F\_____/J\______/F    J  _____/LJ__LJ\____,__L )-____  L                       ");
            Console.WriteLine(@"                      |________| J______F J_____F J______F     |_J_____F |__| J____,__FJ\______/F                       ");
            Console.WriteLine("                                                               L_J                      J______F                        ");
            System.Threading.Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("       ,ggg,         gg            ,ggg, ,ggg,        gg ,ggggggggggggggg ,gggggggg,       ,ggggggg,   ,ggggggg,        ");
            Console.WriteLine(@"      dP""""Y8a        88           dP""""8IdP""""Y8b       88dP""""""""""""88""""""""""""""d8P""""""""""""Y8b,   , dP""""""""""""Y8b,dP""""""""""""Y8b     ");
            Console.WriteLine("      Yb, `88        88          dP   88Yb, `88       88Yb,_    88       88,_a     `8b   d8'    a  Y8d8'    a  Y8       ");
            Console.WriteLine(@"       `""  88        88         dP    88 `""  88       88 `""""    88       `Y8P""      88   88     ""Y8P'88     ""Y8P'       ");
            Console.WriteLine("           88        88        ,8'    88     88aaaaaaa88        88                  88   `8baaaa     `8baaaa            ");
            Console.WriteLine(@"           88        88        d88888888     88""""""""""""""88        88                 d8'  ,d8P""""""""    ,d8P""""""""            ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"           88       ,88  __   ,8""     88     88       88        88              _, d8'   d8""         d8""                ");
            Console.WriteLine(@"           Y8b,___,d888 dP""  ,8P      Y8     88       88  gg,   88            d8888ba,  Y8,         Y8,                 ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"            ""Y88888P""88,Yb,_,dP       `8b,   88       Y8,  ""Yb,,8P                ""Y88b,`Yba,,_____,`Yba,,_____,       ");
            Console.WriteLine(@"                 ,ad8888 ""Y8P""         `Y8   88       `Y8    ""Y8P'                ,d8888  `""Y8888888  `""Y8888888        ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"                d8P"" 88                                                         ,8P""  88                                ");
            Console.WriteLine("              ,d8'   88                                                        d8'    88                                ");
            Console.WriteLine("              d8'    88                                                       d8'    ,88                                ");
            Console.WriteLine("              88     88                                                       88     d8'                                ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("              Y8,_ _,88                                                       Y8,_ _,8P                                 ");
            Console.WriteLine(@"               ""Y888P""                                                         ""Y888P""                                  ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                                                        ");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("                                                                                                                        ");
            Console.WriteLine("                                              Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
        public static void DisplayScoreSheet()
        {
            GameManager game = new GameManager();

            int one = game.Get("one");
            int two = game.Get("two");
            int three = game.Get("three");
            int four = game.Get("four");
            int five = game.Get("five");
            int six = game.Get("six");
            int threeKind = game.Get("threeKind");
            int fullHouse = game.Get("fullHouse");
            int fourKind = game.Get("fourKind");
            int small = game.Get("small");
            int large = game.Get("large");
            int yahtzee = game.Get("yahtzee");
            int chance = game.Get("chance");
            int bonus = game.Get("bonus");
            int total = game.Get("total");
            int tophalf = game.Get("tophalf");
            int topbonus = game.Get("topbonus");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (one == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Ones: ");
            if (one > 0)
                ColorMeGreen(one);
            else if (one == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(one);
            }
            else
                ColorMeYellow("A");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (two == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Twos: ");
            if (two > 0)
                ColorMeGreen(two);
            else if (two == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(two);
            }
            else
                ColorMeYellow("B");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (three == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Threes: ");
            if (three > 0)
                ColorMeGreen(three);
            else if (three == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(three);
            }
            else
                ColorMeYellow("C");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (four == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Fours: ");
            if (four > 0)
                ColorMeGreen(four);
            else if (four == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(four);
            }
            else
                ColorMeYellow("D");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (five == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Fives: ");
            if (five > 0)
                ColorMeGreen(five);
            else if (five == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(five);
            }
            else
                ColorMeYellow("E");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (six == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   - Sixes: ");
            if (six > 0)
                ColorMeGreen(six);
            else if (six == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(six);
            }
            else
                ColorMeYellow("F");

            Console.ResetColor();
            Console.Write("\n\n   Top Half Total: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            if (tophalf < 63)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(tophalf);
            Console.ResetColor();

            Console.ResetColor();
            Console.Write("   Top Half Bonus ");
            Console.ForegroundColor = ConsoleColor.Blue;
            if (topbonus == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("+" + topbonus);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (threeKind == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 6);
            Console.Write("- Three of a Kind: ");
            if (threeKind > 0)
                ColorMeGreen(threeKind);
            else if (threeKind == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(threeKind);
            }
            else
                ColorMeYellow("G");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (fourKind == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 7);
            Console.Write("- Four of a Kind: ");
            if (fourKind > 0)
                ColorMeGreen(fourKind);
            else if (fourKind == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(fourKind);
            }
            else
                ColorMeYellow("H");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (fullHouse == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 8);
            Console.Write("- Full House: ");
            if (fullHouse > 0)
                ColorMeGreen(fullHouse);
            else if (fullHouse == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(fullHouse);
            }
            else
                ColorMeYellow("I");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (small == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 9);
            Console.Write("- Small Straight: ");
            if (small > 0)
                ColorMeGreen(small);
            else if (small == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(small);
            }
            else
                ColorMeYellow("J");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (large == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 10);
            Console.Write("- Large Straight: ");
            if (large > 0)
                ColorMeGreen(large);
            else if (large == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(large);
            }
            else
                ColorMeYellow("K");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (yahtzee == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 11);
            Console.Write("- Yahtzee: ");
            if (yahtzee > 0)
                ColorMeGreen(yahtzee);
            else if (yahtzee == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(yahtzee);
            }
            else
                ColorMeYellow("L");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            if (chance == -1)
                Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(25, 12);
            Console.Write("- Chance: ");
            if (chance > 0)
                ColorMeGreen(chance);
            else if (chance == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(chance);
            }
            else
                ColorMeYellow("M");

            Console.SetCursorPosition(25, 14);
            Console.ResetColor();
            Console.Write("Bonus Yahtzee(s) ");
            if (bonus == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.WriteLine("+" + bonus);
            Console.ResetColor();

            Console.SetCursorPosition(25, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Grand Total: ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (total == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(total);
            Console.ResetColor();
            Console.WriteLine("   ---------------------------------------------\n");
        }
        public static void ShowTurnsLeft(int input)
        {
            Console.SetCursorPosition(3, 18);
            Console.Write("Turns Left: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (input == 0)
                Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(input);
            Console.ResetColor();
        }

        public static void InvalidSelection()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   -That is not a valid selection. Hit any key to continue.");
            Console.ResetColor();
            Console.ReadKey();
            Console.SetCursorPosition(3, 25);
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");
            Console.WriteLine("                                                                      ");
        }

        public static void DisplayDice()
        {
            Console.SetCursorPosition(22, 17);
            Console.Write("   Dice: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 5; i++)
                Console.Write(GameManager.GetDice(i) + " ");
            Console.WriteLine("");
            Console.ResetColor();
        }

        public static void DisplayBetterDice()
        {
            for (int i = 0; i < 5; i++)
            {
                int currentDice = GameManager.GetDice(i);
                Console.SetCursorPosition(3 + (i) * 11, 19);
                Console.ForegroundColor = ConsoleColor.White;
                switch (currentDice)
                {
                    case 1:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│       │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│   o   │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│       │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                    case 2:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│     o │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│       │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│ o     │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                    case 3:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│     o │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│   o   │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│ o     │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                    case 4:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│       │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                    case 5:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│   o   │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                    case 6:
                        Console.WriteLine("┌───────┐");
                        Console.SetCursorPosition(3 + (i) * 11, 20);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 21);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 22);
                        Console.WriteLine("│ o   o │");
                        Console.SetCursorPosition(3 + (i) * 11, 23);
                        Console.WriteLine("└═══════┘");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.SetCursorPosition(0, 24);
                Console.Write("       1          2          3          4          5");
            }
        }

        public static void ColorMeYellow(string input)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(input + "\n");
            Console.ResetColor();
        }

        public static void ColorMeGreen(int input)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(input + "\n");
            Console.ResetColor();
        }

        public static void DisplayScoreText()
        {
            Console.Clear();
            Console.WriteLine("    __   __      _      _                   ");
            Console.WriteLine("    \\ \\ / /__ _ | |__  | |_  ____ ___   ___ ");
            Console.WriteLine("     \\ V // _` || '_ \\ | __||_  // _ \\ / _ \\");
            Console.WriteLine("      | || (_| || | | || |_  / /|  __/|  __/");
            Console.WriteLine("      |_| \\__,_||_| |_| \\__|/___|\\___| \\___|\n");
        }
        public static void ClearInputLine()
        {
            Console.SetCursorPosition(0, 26);
            Console.Write("                                                                                                                         ");
            Console.Write("                                                                                                                        ");
        }

        public static void FinalScore()
        {
            GameManager game = new GameManager();
            int total = game.Get("total");
            Console.SetCursorPosition(3, 18);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Your final score is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(total);
            Console.ResetColor();
        }
    }
}
