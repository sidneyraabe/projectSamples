using FlooringMastery.Models;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static string Prompt(string input)
        {
            Console.Write(input);
            return Console.ReadLine();

        }
        public static void DisplayOrders(Order order, string date)
        {
            DTHelpers dt = new DTHelpers();

            UIItems.Separator();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#" + order.OrderNumber + " | " + dt.MakeStringLookNice(date));
            Console.WriteLine(order.CustomerName.Replace('|', ','));
            Console.WriteLine(order.State);
            Console.WriteLine("Product: " + order.ProductType);
            Console.WriteLine("Materials: $" + order.MaterialCost);
            Console.WriteLine("Labor: $" + order.LaborCost);
            Console.WriteLine("Tax: $" + order.Tax);
            Console.WriteLine("Total: $" + order.Total);
            Console.ResetColor();
            UIItems.Separator();
        }

        //TODO: example method to reduce clutteryness of workflows
        public void DisplayPreviousEntries(string date, string name, string state, string product)
        {
            DTHelpers dt = new DTHelpers();

            if (date != "")           
                Console.WriteLine("Date: " + dt.MakeStringLookNice(date));
            
            if (name != "")            
                Console.WriteLine("Name: " + name);

            if (state != "")
                Console.WriteLine("State: " + state);

            if (product != "")
                Console.WriteLine("Product: " + product);
        }

        //another example method
        public void DisplayHeader(string workflowTitle)
        {
            Console.Clear();
            Console.WriteLine(workflowTitle); // crud flows
            UIItems.Separator();
        }

        //small decluttering method, instead of retyping each time
        public void PressKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
