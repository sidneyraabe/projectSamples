using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.BLL.Products;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI.Helpers;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            List<Order> ordersOnDay = new List<Order>();

            OrderManager manager = OrderManagerFactory.Create();
            DTHelpers dt = new DTHelpers();

            string prettyDate, date, input;
            int id, idIndex = 0;

            DateTime validDate;
            DateTime start = new DateTime(0001, 01, 02);

            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Remove an order:");
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
                    response.Order.Clear();
                    break;
                }
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            prettyDate = dt.MakeStringLookNice(date);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Remove an order:");
                UIItems.Separator();
                Console.Write($"Enter ID of order placed on {prettyDate}: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out id))
                {
                    OrderLookupResponse response = manager.LookupOrder(date, id);
                    if (response.Success)
                    {
                        ordersOnDay = response.Order;
                        break;
                    }
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < ordersOnDay.Count; i++)
            {
                if (ordersOnDay[i].OrderNumber == id)
                    idIndex = i;
            }
            // idIndex isn't id-1, must cycle through to find in case an id was removed
            while (true)
            {
                Console.Clear();
                UIItems.Separator();

                Console.WriteLine("#" + ordersOnDay[idIndex].OrderNumber + " | " + prettyDate);
                Console.WriteLine(ordersOnDay[idIndex].CustomerName.Replace('|', ','));
                Console.WriteLine(ordersOnDay[idIndex].State);
                Console.WriteLine("Product: " + ordersOnDay[idIndex].ProductType);
                Console.WriteLine("Materials: $" + ordersOnDay[idIndex].MaterialCost);
                Console.WriteLine("Labor: $" + ordersOnDay[idIndex].LaborCost);
                Console.WriteLine("Tax: $" + ordersOnDay[idIndex].Tax);
                Console.WriteLine("Total: $" + ordersOnDay[idIndex].Total);
                UIItems.Separator();

                Console.WriteLine("Do you wish to delete this order? (Y/N): ");
                input = Console.ReadLine().ToUpper();

                
                if (input == "Y")
                {
                    manager.RemoveOrder(ordersOnDay[idIndex]);
                    Console.Clear();
                    Console.WriteLine("Order removed. :)");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else if (input == "N")
                {
                    manager.RemoveOrder(null); // bug fix, need to clear static orders list in repository
                    Console.WriteLine("No changes made. Exiting.");
                    Console.WriteLine("(Press any key to continue...)");
                    Console.ReadKey();
                    break;
                }
                Console.WriteLine("Error: Enter 'Y' or 'N'. ");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
