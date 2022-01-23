using NounManager.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NounManager.Views
{
    public class NounView
    {
        public void DisplaySelectScreen()
        {
            Console.Clear();
            Console.WriteLine("The following are the available commands:");
            Console.WriteLine("(1) Create a new Book entry");
            Console.WriteLine("(2) Display all Book entries");
            Console.WriteLine("(3) Search for a Book");
            Console.WriteLine("(4) Edit a Book entry");
            Console.WriteLine("(5) Remove a Book entry\n");
        }
        public int GetMenuchoice()
        {
            while (true)
            {
                int choice = GetIntFromUser("Enter a number to confirm your selection: ");
                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Integer Out Of Bounds - Please Try Again");
                    continue;
                }
                return choice;
            }

        }

        public Noun GetNewNounInfo() // I thought assigning is to be done in the repo, did it that way for my edit flow
        {
            Noun currentNoun = new Noun();
            currentNoun.Title = GetStringFromUser("Enter title: ");
            currentNoun.Author = GetStringFromUser("Enter author (Lastname, F.): ");
            currentNoun.DatePublished = GetIntFromUser("Enter publishing date (year): ");
            currentNoun.IsAwardWinner = GetBoolFromUser("Enter award status: (T)rue or (F)alse: ");
            return currentNoun;
        }

        public void DisplayNoun(Noun noun)
        {
            string format = " {0,-3}│ {1,-31} │ {2,-22} │ {3,4} │   {4,-8}";
            if (noun != null)
                Console.WriteLine(format, noun.Id, noun.Title, noun.Author, noun.DatePublished, noun.IsAwardWinner);
            else
                NotFound();
        }

        public void DisplayCategories()
        {
            Console.WriteLine(" ID │              TITLE              │         AUTHOR         │ DATE │  AWARDED  ");
            Console.WriteLine("────┼─────────────────────────────────┼────────────────────────┼──────┼───────────");
        }

        public string EditNounTitle(Noun noun)
        {
            if (ShouldEditAttribute("title"))
                return GetStringFromUser("Enter new title: ");
            else
                return noun.Title;
        }
        public string EditNounAuthor(Noun noun)
        {
            if (ShouldEditAttribute("author"))
                return GetStringFromUser("Enter new author (Lastname, F.): ");
            else
                return noun.Author;
        }
        public int EditNounDatePublished(Noun noun)
        {
            if (ShouldEditAttribute("date published"))
                return GetIntFromUser("Enter new publishing date (year): ");
            else
                return noun.DatePublished;
        }

        public bool EditNounAwardWinner(Noun noun)
        {
            if (ShouldEditAttribute("award status"))
                return GetBoolFromUser("Enter award status: (T)rue or (F)alse: ");
            else
                return noun.IsAwardWinner;
        }

        public int SearchNoun()
        {
            return GetIntFromUser("Enter the book's ID to retrieve info: ");
        }

        public bool ConfirmRemoveNoun(Noun noun)
        {
            DisplayNoun(noun);
            return GetBoolFromUser("Are you SURE you wish to remove this entry? \nEnter \"(y)es\" or \"(n)o\": ");
        }

        private bool ShouldEditAttribute(string attribute)
        {
            return GetBoolFromUser("Do you wish to change " + attribute + "? \nEnter \"(y)es\" or \"(n)o\": ");
        }
        private string GetStringFromUser(string prompt)
        {
            string input;

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (input == string.Empty)
                {
                    WriteError();
                    continue;
                }
                return input.ToUpper();
            }
        }

        private bool GetBoolFromUser(string prompt)
        {
            while (true)
            {
                string input = GetStringFromUser(prompt);
                if (input != "YES" && input != "Y" && input != "TRUE" && input != "T" && input != "NO" && input != "N" && input != "F" && input != "FALSE")
                {
                    WriteError();
                    continue;
                }

                if (input == "YES" || input == "Y" || input == "TRUE" || input == "T")
                    return true;
                return false;
            }
        }

        private int GetIntFromUser(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (!int.TryParse(input, out int result) || input == string.Empty)
                {
                    WriteError();
                    continue;
                }
                return result;
            }
        }

        private void WriteError()
        {
            Console.WriteLine("Invalid Input - Please Try Again.");
        }

        public void Wait()
        {
            Console.Write("\nPress Any Key to Continue... ");
            Console.ReadKey();
        }
        public void Clear()
        {
            Console.Clear();
        }

        public void NothingHappened()
        {
            Console.WriteLine("Nothing was deleted.");
        }

        public void SomethingHappened(int id)
        {
            Console.WriteLine("Entry of id " + id + " was deleted.");
        }
        public void NotFound()
        {
            Console.WriteLine("No book exists at that id. ");
        }

        public void DisplayMessageToUser(string message)
        {
            Console.WriteLine(message);
        }
    }
}
