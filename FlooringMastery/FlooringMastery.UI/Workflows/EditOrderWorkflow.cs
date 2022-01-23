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
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            List<Order> neworder = new List<Order>();
            Order tempOrder = new Order();

            OrderManager manager = OrderManagerFactory.Create();
            TaxManager tmanager = TaxManagerFactory.Create();
            ProductManager pmanager = ProductManagerFactory.Create();
            DTHelpers dt = new DTHelpers();
            CNameHelpers cn = new CNameHelpers();
            string prettyDate, date, customerName, state, productType;
            int id, idIndex = 0;
            decimal area;

            DateTime validDate;
            DateTime start = new DateTime(0001, 01, 02);

            while (true)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Edit an order:");
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
                Console.WriteLine("Edit an order:");
                UIItems.Separator();
                Console.Write($"Enter ID of order placed on {prettyDate}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out id))
                {
                    OrderLookupResponse response = manager.LookupOrder(date, id);
                    if (response.Success)
                    {
                        neworder = response.Order;
                        break;
                    }
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }

            for (int i = 0; i < neworder.Count; i++)
            {
                if (neworder[i].OrderNumber == id)
                    idIndex = i;
            }
            //find index

            tempOrder = neworder[idIndex];
            string name = tempOrder.CustomerName.Replace('|', ',');

            while (true)
            {
                Console.Clear();
                
                Console.WriteLine("Edit an order:");
                ConsoleIO.DisplayOrders(tempOrder, date);
                customerName = ConsoleIO.Prompt($"Edit a customer name, or leave empty to leave as \"{name}\": ");
                if (customerName == "")                
                    break;
                
                if (cn.CheckIfValidName(customerName))
                {
                    tempOrder.CustomerName = customerName;
                    break;
                }

                Console.WriteLine("Error: Customer name not valid. \n" +
                    "Name must be comprised of letters or numbers, and may contain commas, periods, or spaces." +
                    "\nHit any key to continue...");
                Console.ReadKey();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Edit an order:");
                ConsoleIO.DisplayOrders(tempOrder, date);

                state = ConsoleIO.Prompt($"Enter a state, or leave empty to leave as \"{tempOrder.State}\": ");
                if (state == "")               
                    break;
                
                state = state.ToUpper();
                TaxLookupResponse response = tmanager.LookupTax(state);

                if (response.Success)
                {
                    tempOrder.State = state;
                    break;
                }

                Console.WriteLine("Error: " + response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Edit an order:");
                ConsoleIO.DisplayOrders(tempOrder, date);
                Console.WriteLine("Available products: ");

                List<Product> products = pmanager.ListProducts();
                foreach (Product p in products)
                    Console.WriteLine(p.ProductType);

                productType = ConsoleIO.Prompt($"\nEnter a product type, or leave empty to leave as \"{tempOrder.ProductType}\": ");
                if (productType == "")                
                    break;
                

                productType = productType.ToLower();
                productType = char.ToUpper(productType.First()) + productType.Substring(1).ToLower();

                ProductLookupResponse response = pmanager.LookupProduct(productType);

                if (response.Success)
                {
                    tempOrder.ProductType = productType;
                    break;
                }

                Console.WriteLine("Error: " + response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Edit an order:");
                ConsoleIO.DisplayOrders(tempOrder, date);

                string input = ConsoleIO.Prompt($"Enter an area, or leave empty to leave as \"{tempOrder.Area}\" : ");
                if (input == "")                
                    break;
                

                if (decimal.TryParse(input, out area))
                    if (area >= 100)
                    {
                        tempOrder.Area = area;
                        break;
                    }

                Console.WriteLine("Error: Not a valid input. Must be a decimal larger than 100");
                Console.WriteLine("Press any key to coninue...");
                Console.ReadKey();
            }

            TaxLookupResponse tmathresponse = tmanager.LookupTax(tempOrder.State);
            decimal taxrate = tmathresponse.Tax.TaxRate;

            ProductLookupResponse pmathresponse = pmanager.LookupProduct(tempOrder.ProductType);
            decimal costPerSquareFoot = pmathresponse.Product.CostPerSquareFoot;
            decimal laborCostPerSquareFoot = pmathresponse.Product.LaborCostPerSquareFoot;

            decimal materialCost = (tempOrder.Area * costPerSquareFoot);
            decimal laborCost = (tempOrder.Area * laborCostPerSquareFoot);
            decimal tax = ((materialCost + laborCost) * (taxrate / 100));
            decimal total = (materialCost + laborCost + tax);

            while (true)
            {
                Console.Clear();

                UIItems.Separator();
                Console.WriteLine(tempOrder.CustomerName.Replace('|', ','));
                Console.WriteLine(tempOrder.State);
                Console.WriteLine("Product: " + tempOrder.ProductType);
                Console.WriteLine("Materials: $" + Decimal.Round(materialCost, 2));
                Console.WriteLine("Labor: $" + Decimal.Round(laborCost, 2));
                Console.WriteLine("Tax: $" + Decimal.Round(tax, 2));
                Console.WriteLine("Total: $" + Decimal.Round(total, 2));
                UIItems.Separator();

                Console.Write("This is the updated receipt, reflecting any recalculated costs. Does everything look correct? (Y/N): ");
                string input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    tempOrder.CustomerName = tempOrder.CustomerName.Replace(',', '|');

                    tempOrder.TaxRate = taxrate;


                    tempOrder.CostPerSquareFoot = costPerSquareFoot;
                    tempOrder.MaterialCost = materialCost;
                    tempOrder.LaborCost = laborCost;
                    tempOrder.LaborCostPerSquareFoot = laborCostPerSquareFoot;
                    tempOrder.Tax = tax;
                    tempOrder.Total = total;
                    tempOrder.OrderNumber = id;

                    neworder.Clear(); // fix dupe bug; w/o this line, path selector would readall() and dupe the orders already read
                    manager.PathSelector(date);
                    manager.SaveOrder(tempOrder);

                    Console.Clear();
                    Console.WriteLine("Order overwritten. :)");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else if (input == "N")
                {
                    manager.RemoveOrder(null); // clear static list in order repository
                    Console.WriteLine("Order changes reverted. Exiting.");
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
