using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayAllOrdersWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DTHelpers dt = new DTHelpers();
            string date;
            DateTime validDate;
            DateTime start = new DateTime(0001, 01, 02);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Lookup an order:");
                UIItems.Separator();

                Console.Write("Enter a date (MM/DD/YYYY): ");
                date = Console.ReadLine();
                DateTime.TryParse(date, out validDate);
                if (validDate > start)
                    break;
                Console.WriteLine("Error: Date not valid.\nHit any key to continue...");
                Console.ReadKey();
            }

            date = dt.DTObjectToString(validDate);
            OrderLookupResponse response = manager.LookupDate(date);
            if (response.Success)
            {
                Console.Clear();
                foreach (Order o in response.Order)
                    ConsoleIO.DisplayOrders(o, date);
            }
            else
            {
                Console.WriteLine(response.Message);
            }
            response.Order.Clear(); // bug fix, multiple display orders in row would not clear order repository in-between searches
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
