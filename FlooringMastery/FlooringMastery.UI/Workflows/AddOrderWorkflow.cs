using FlooringMastery.BLL;
using FlooringMastery.BLL.Products;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            Order neworder = new Order();

            OrderManager manager = OrderManagerFactory.Create();
            TaxManager tmanager = TaxManagerFactory.Create();
            ProductManager pmanager = ProductManagerFactory.Create();
            

            DTHelpers dt = new DTHelpers();
            CNameHelpers cn = new CNameHelpers();
            string date, cName, state, product, input;
            decimal area;
            DateTime validDate;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add an order:");
                UIItems.Separator();
                date = ConsoleIO.Prompt("Enter a future date (MM/DD/YYYY): ");
                DateTime.TryParse(date, out validDate);
                if (validDate > DateTime.Now)
                    break;
                Console.WriteLine("Error: Date not valid.\nHit any key to continue...");
                Console.ReadKey();
            }
            date = dt.DTObjectToString(validDate);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add an order:");
                UIItems.Separator();
                Console.WriteLine("Date: " + dt.MakeStringLookNice(date) + "\n");

                cName = ConsoleIO.Prompt("Enter a customer name: ");
                if (cn.CheckIfValidName(cName))                            
                    break;
                
                Console.WriteLine("Error: Customer name not valid. \n" +
                    "Name must be comprised of letters or numbers, and may contain commas, periods, or spaces." +
                    "\nHit any key to continue...");
                Console.ReadKey();
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add an order:");
                UIItems.Separator();
                Console.WriteLine("Date: " + dt.MakeStringLookNice(date));
                Console.WriteLine("Customer name: " + cName + "\n");

                state = ConsoleIO.Prompt("Enter a state: ");

                // oh/OH accepted
                state = state.ToUpper();

                TaxLookupResponse response = tmanager.LookupTax(state);

                if (response.Success)
                    break;

                Console.WriteLine("Error: " + response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            List<Product> products = pmanager.ListProducts();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add an order:");
                UIItems.Separator();
                Console.WriteLine("Date: " + dt.MakeStringLookNice(date));
                Console.WriteLine("Customer name: " + cName);
                Console.WriteLine("State: " + state + "\n");

                Console.WriteLine("Available products: ");                
                foreach (Product p in products)
                    Console.WriteLine(p.ProductType);

                product = ConsoleIO.Prompt("\nEnter a product type: ");

                // (capitalize first, lowercase all else)
                if (product != "")
                {
                    product = product.ToLower();
                    product = char.ToUpper(product.First()) + product.Substring(1).ToLower();
                }
                ProductLookupResponse response = pmanager.LookupProduct(product);

                if (response.Success)
                    break;

                Console.WriteLine("Error: " + response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Add an order:");
                UIItems.Separator();
                Console.WriteLine("Date: " + dt.MakeStringLookNice(date));
                Console.WriteLine("Customer name: " + cName);
                Console.WriteLine("State: " + state);
                Console.WriteLine("Product: " + product + "\n");


                Console.Write("Enter an area: ");
                input = Console.ReadLine();

                if (decimal.TryParse(input, out area))
                    if (area >= 100)
                        break;

                Console.WriteLine("Error: Not a valid input. Must be a decimal larger than 100");
                Console.WriteLine("Press any key to coninue...");
                Console.ReadKey();
            }

            TaxLookupResponse tmathresponse = tmanager.LookupTax(state);
            decimal taxrate = tmathresponse.Tax.TaxRate;

            ProductLookupResponse pmathresponse = pmanager.LookupProduct(product);
            decimal costPerSquareFoot = pmathresponse.Product.CostPerSquareFoot;
            decimal laborCostPerSquareFoot = pmathresponse.Product.LaborCostPerSquareFoot;

            decimal materialCost = (area * costPerSquareFoot);
            decimal laborCost = (area * laborCostPerSquareFoot);
            decimal tax = ((materialCost + laborCost) * (taxrate / 100));
            decimal total = (materialCost + laborCost + tax);

            while (true)
            {
                Console.Clear();

                UIItems.Separator();
                Console.WriteLine(cName);
                Console.WriteLine(state);
                Console.WriteLine("Product: " + product);
                Console.WriteLine("Materials: $" + Decimal.Round(materialCost, 2));
                Console.WriteLine("Labor: $" + Decimal.Round(laborCost, 2));
                Console.WriteLine("Tax: $" + Decimal.Round(tax, 2));
                Console.WriteLine("Total: $" + Decimal.Round(total, 2));
                UIItems.Separator();

                Console.Write("Does everything look correct? (Y/N): ");
                input = Console.ReadLine().ToUpper();

                if (input == "Y")
                {
                    neworder.CustomerName = cName.Replace(',','|');
                    neworder.State = state;
                    neworder.TaxRate = taxrate;
                    neworder.ProductType = product;
                    neworder.Area = area;
                    neworder.CostPerSquareFoot = costPerSquareFoot;
                    neworder.MaterialCost = materialCost;
                    neworder.LaborCost = laborCost;
                    neworder.LaborCostPerSquareFoot = laborCostPerSquareFoot;
                    neworder.Tax = tax;
                    neworder.Total = total;
                    neworder.OrderNumber = 0; // id of 0 prompts the repository to generate the ID 

                    manager.PathSelector(date);                   
                    manager.SaveOrder(neworder);

                    Console.Clear();
                    Console.WriteLine("Order saved. :)");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                }
                else if (input == "N")
                {
                    Console.WriteLine("Order deleted. Exiting.");
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
