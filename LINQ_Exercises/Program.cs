using System.Linq;
using LINQ.Models;
using System;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13(); //functional, but what if I didn't know that the OrderDates were in order?
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20(); // need help, the LINQ for the categories is confusing me by all the variables
            //Exercise21();
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25(); //seems a bit lengthy
            //Exercise26();
            //Exercise27();

            //incomplete:

            //Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var outOfStockProducts = from product in DataLoader.LoadProducts()
                                     where product.UnitsInStock == 0
                                     select product;

            foreach (Product product in outOfStockProducts)
                Console.WriteLine("* " + product.ProductName);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var inStockAndOverThreeDollars = from product in DataLoader.LoadProducts()
                                             where product.UnitsInStock > 0 && product.UnitPrice > 3M
                                             select product;

            foreach (Product product in inStockAndOverThreeDollars)
                Console.WriteLine("* " + product.ProductName);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customersFromWashington = from customer in DataLoader.LoadCustomers()
                                          where customer.Region == "WA"
                                          select customer;

            foreach (Customer customer in customersFromWashington)
            {
                Console.WriteLine(customer.CompanyName);

                foreach (Order order in customer.Orders)
                    Console.WriteLine("* ID: {0}, Date: {1}, Total: {2}", order.OrderID, order.OrderDate, order.Total);

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var productslist = from product in DataLoader.LoadProducts()

                               select new
                               {
                                   product.ProductName
                               };

            foreach (var ProductName in productslist)
                Console.WriteLine(ProductName);

        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var productslist = from product in DataLoader.LoadProducts()

                               select new
                               {
                                   product.ProductID,
                                   product.ProductName,
                                   product.Category,
                                   UnitPrice = (product.UnitPrice * 1.25M),
                                   product.UnitsInStock
                               };

            foreach (var product in productslist)
            {
                Console.WriteLine("* ID: {0}, {1}: {2}", product.ProductID, product.Category, product.ProductName);
                Console.WriteLine("   $/Unit: {0}, Stock: {1}\n", product.UnitPrice, product.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var productslist = from product in DataLoader.LoadProducts()

                               select new
                               {
                                   ProductName = product.ProductName.ToUpper(),
                                   Category = product.Category.ToUpper()
                               };

            foreach (var product in productslist)
                Console.WriteLine("{0}: {1}", product.Category, product.ProductName);

        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var productslist = from product in DataLoader.LoadProducts()
                               select new
                               {
                                   product.ProductID,
                                   product.ProductName,
                                   product.Category,
                                   product.UnitPrice,
                                   product.UnitsInStock,
                                   ReOrder = true && product.UnitsInStock < 3
                               };
            foreach (var product in productslist)
            {
                Console.WriteLine("* ID: {0}, {1}: {2}", product.ProductID, product.Category, product.ProductName);
                Console.WriteLine("   $/Unit: {0}, Stock: {1}", product.UnitPrice, product.UnitsInStock);
                Console.WriteLine("   Reorder: " + product.ReOrder + "\n");
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var productslist = from product in DataLoader.LoadProducts()
                               select new
                               {
                                   product.ProductID,
                                   product.ProductName,
                                   product.Category,
                                   product.UnitPrice,
                                   product.UnitsInStock,
                                   StockValue = product.UnitPrice * product.UnitsInStock
                               };

            foreach (var product in productslist)
            {
                Console.WriteLine("* ID: {0}, {1}: {2}", product.ProductID, product.Category, product.ProductName);
                Console.WriteLine("   $/Unit: {0}, Stock: {1}", product.UnitPrice, product.UnitsInStock);
                Console.WriteLine("   Stock value: " + product.StockValue + "\n");
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        /// 
        static void Exercise9()
        {
            var evens = DataLoader.NumbersA.Where(number => number % 2 == 0);

            foreach (int number in evens)
                Console.Write(number + ", ");

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// 
        /// </summary> 
        /// 
        static void Exercise10()
        {
            var DistinctCustomerWithOrderLessThan500 = (from customer in DataLoader.LoadCustomers()
                                                        from order in customer.Orders
                                                        where order.Total < 500
                                                        select customer).Distinct();

            foreach (Customer customer in DistinctCustomerWithOrderLessThan500)
                Console.WriteLine("* ID: {0}, Name: {1}", customer.CustomerID, customer.CompanyName);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var odds = (from number in DataLoader.NumbersC
                        where number % 2 == 1
                        orderby number
                        select number).Take(3);


            foreach (int number in odds)
                Console.Write(number + ", ");

            Console.WriteLine();
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var lastthree = (from number in DataLoader.NumbersB
                             select number).Skip(3);

            foreach (int number in lastthree)
                Console.Write(number + ", ");

            Console.WriteLine();


        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customersFromWashington = from customer in DataLoader.LoadCustomers()
                                          where customer.Region == "WA"
                                          select customer;

            //var ordersInOrderFromWashington = customersFromWashington.OrderByDescending(c => c.Orders[?????].OrderDate);
            //without knowing the last index in customer.Orders is the most recent, how to order c.Orders by OrderDate?

            foreach (Customer customer in customersFromWashington)
            {
                int latestOrderIndex = customer.Orders.Count() - 1;
                Console.WriteLine("{0}\n* ID: {1}, Date: {2}, Total: {3}",
                    customer.CompanyName, customer.Orders[latestOrderIndex].OrderID, customer.Orders[latestOrderIndex].OrderDate, customer.Orders[latestOrderIndex].Total);
            }


        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            var numbersUntilLessThanOrEqualTo6 = DataLoader.NumbersC.TakeWhile(n => n < 6);

            foreach (int number in numbersUntilLessThanOrEqualTo6)
            {
                Console.Write(number + ", ");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            var firstNumDiv3 = DataLoader.NumbersC.SkipWhile(n => n % 3 != 0);
            foreach (int num in firstNumDiv3)
                Console.Write(num + ", ");

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            var alphabeticalProducts = DataLoader.LoadProducts().OrderBy(p => p.ProductName);
            foreach (Product product in alphabeticalProducts)
                Console.WriteLine(product.ProductName);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            var descendingProductByStock = DataLoader.LoadProducts().OrderByDescending(p => p.UnitsInStock);
            foreach (Product product in descendingProductByStock)
                Console.WriteLine(product.ProductName + ", stock: " + product.UnitsInStock);

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            var descendingUnitPriceAndCategorizedProduct = (from product in DataLoader.LoadProducts()
                                                            orderby product.Category
                                                            select product).ThenByDescending(p => p.UnitPrice);

            foreach (Product product in descendingUnitPriceAndCategorizedProduct)
                Console.WriteLine("{0}: {1} ${2}/u", product.Category, product.ProductName, String.Format("{0:0.00}", product.UnitPrice));



        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            var reversedNumbersB = DataLoader.NumbersB.Reverse();
            foreach (var number in reversedNumbersB)
                Console.Write(number + ", ");
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            var categorizedProduct = DataLoader.LoadProducts().GroupBy(x => x.Category);

            foreach (var cat in categorizedProduct)
            {
                Console.WriteLine(cat.Key);
                foreach (var prod in cat)
                    Console.WriteLine("* " + prod.ProductName);
            }


        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            {
                List<Customer> customers = DataLoader.LoadCustomers();
                var query = from c in customers
                            select new
                            {
                                Name = c.CompanyName,
                                YearOrders = from o in c.Orders
                                             group o by o.OrderDate.Year into gyo
                                             select new
                                             {
                                                 Year = gyo.Key,
                                                 MonthOrders = from yo in gyo
                                                               group yo by yo.OrderDate.Month into gmo
                                                               select new
                                                               {
                                                                   Month = gmo.Key,
                                                                   Orders = gmo
                                                               }
                                             }
                            };

                foreach (var c in query)
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine($"{ c.Name}");
                    Console.WriteLine("======================================");
                    foreach (var Year in c.YearOrders)
                    {
                        Console.WriteLine($"{Year.Year}");
                        foreach (var Month in Year.MonthOrders)
                        {
                            Console.WriteLine($"    {Month.Month} - ");
                            foreach (var order in Month.Orders)
                            {
                                Console.WriteLine($"            {order.Total}");
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            var categories = from p in DataLoader.LoadProducts()
                             group p by p.Category into c
                             select new
                             {
                                 Category = c.Key
                             };

            foreach (var key in categories)
            {
                Console.WriteLine(key.Category);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            bool Has789 = false;

            foreach (var p in DataLoader.LoadProducts())
                if (p.ProductID == 789)
                {
                    Has789 = false;
                    break;
                }

            Console.WriteLine("Product 789's existance is {0}.", Has789);


        }
        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

            var outOfStockProducts = from p in DataLoader.LoadProducts()
                                     where p.UnitsInStock == 0
                                     group p by p.Category into c
                                     select new
                                     {
                                         Category = c.Key
                                     };



            foreach (var key in outOfStockProducts)
            {
                Console.WriteLine(key.Category);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            var Catagories = DataLoader.LoadProducts().GroupBy(
                p => p.Category).Where(group => group.All(p => p.UnitsInStock > 0));
            foreach (var catagory in Catagories)
            {
                Console.WriteLine(catagory.Key);
            }


            var AllCategories = from p in DataLoader.LoadProducts()
                                group p by p.Category into c
                                select new
                                {
                                    Category = c.Key
                                };

            var outOfStockProducts = from p in DataLoader.LoadProducts()
                                     where p.UnitsInStock == 0
                                     select p;

            var anyOutOfStockCategories = from p in outOfStockProducts
                                          group p by p.Category into c
                                          select new
                                          {
                                              Category = c.Key
                                          };

            Console.WriteLine("Out of stock categories:\n");
            foreach (var key in AllCategories.Except(anyOutOfStockCategories))
                Console.WriteLine("* " + key.Category);

            Console.WriteLine();
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            Console.WriteLine("Number of odds: " + DataLoader.NumbersA.Where(number => number % 2 == 1).Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customerOrders = from c in DataLoader.LoadCustomers()
                                 select new
                                 {
                                     c.CompanyName,
                                     Count = c.Orders.Count()
                                 };

            foreach (var c in customerOrders)
                Console.WriteLine("-{0}\n  Orders: {1}\n", c.CompanyName, c.Count);

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            var categories = DataLoader.LoadProducts().GroupBy(x => x.Category);

            foreach (var cat in categories)
            {
                Console.WriteLine(cat.Key);
                Console.WriteLine("No of products: " + cat.Count());               
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
