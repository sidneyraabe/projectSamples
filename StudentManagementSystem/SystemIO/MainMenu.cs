using System;
using System.Collections.Generic;
using System.Text;
using SystemIO.Helpers;
using SystemIO.Models.Workflows;
using SystemIO.Workflows;

namespace SystemIO
{
    public class MainMenu
    {
        

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListStudentWorkflow listworkflow = new ListStudentWorkflow();
                    listworkflow.Execute();
                    break;
                case "2":
                    AddStudentWorkflow addworkflow = new AddStudentWorkflow();
                    addworkflow.Execute();
                    break;
                case "3":
                    RemoveStudentWorkflow removeworkflow = new RemoveStudentWorkflow();
                    removeworkflow.Execute();
                    break;
                case "4":
                    EditStudentWorkflow editworkflow = new EditStudentWorkflow();
                    editworkflow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }
        public static void Show()
        {
            bool continueRunning = true;
            while (continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();               
            }

        }
    }
}
