using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        public static string filePath;
        public static List<Order> orders = new List<Order>();
        private bool isNewOrder = true;
        public List<Order> LoadOrder(string OrderNumber)
        {
            filePath = @".\Orders_" + OrderNumber + ".txt";
            if (File.Exists(filePath))
                ReadAllFromFile();
            return orders;

        }
        public void RemoveOrder(Order order)
        {
            orders.Clear();
            ReadAllFromFile();

            if (order != null)
            {
                orders.RemoveAll(o => o.OrderNumber == order.OrderNumber);

                WriteOrder();
            }
            orders.Clear();
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderNumber != 0) //to work for edit or add new order
            {
                foreach (Order o in orders)
                {
                    if (order.OrderNumber == o.OrderNumber)
                    {
                        o.CustomerName = order.CustomerName;
                        o.State = order.State;
                        o.TaxRate = order.TaxRate;
                        o.ProductType = order.ProductType;
                        o.Area = order.Area;
                        o.CostPerSquareFoot = order.CostPerSquareFoot;
                        o.LaborCostPerSquareFoot = order.LaborCostPerSquareFoot;
                        o.MaterialCost = order.MaterialCost;
                        o.LaborCost = order.LaborCost;
                        o.Tax = order.Tax;
                        o.Total = order.Total;

                        isNewOrder = false;
                    }
                }
            }
            if (isNewOrder == true)
            {
                if (orders.Count > 0)
                {
                    int maxid = orders.Max(x => x.OrderNumber);
                    order.OrderNumber = (maxid + 1);
                }
                else
                    order.OrderNumber = 1;
                orders.Add(order);
            }
            WriteOrder();
            orders.Clear();
        }

        private void WriteOrder()
        {
            StreamWriter sw = new StreamWriter(filePath);
            sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
            foreach (Order s in orders)
            {
                sw.WriteLine(s.OrderNumber + "," + s.CustomerName + "," + s.State + "," + s.TaxRate + "," +
                    s.ProductType + "," + Decimal.Round(s.Area, 2) + "," + Decimal.Round(s.CostPerSquareFoot, 2) + "," + Decimal.Round(s.LaborCostPerSquareFoot) + "," +
                    Decimal.Round(s.MaterialCost, 2) + "," + Decimal.Round(s.LaborCost, 2) + "," + Decimal.Round(s.Tax, 2) + "," + Decimal.Round(s.Total, 2));
            }
            sw.Close();
        }
        private void ReadAllFromFile()
        {
            string[] entries = File.ReadAllLines(filePath);
            entries = entries.Skip(1).ToArray();

            foreach (var entry in entries)
            {
                Order item = ConvertLineToOrder(entry);
                orders.Add(item);
            }
        }

        private Order ConvertLineToOrder(string line)
        {
            string[] columns = line.Split(',');

            Order orderInstance = new Order();

            orderInstance.OrderNumber = int.Parse(columns[0]);
            orderInstance.CustomerName = columns[1];
            orderInstance.State = columns[2];
            orderInstance.TaxRate = decimal.Parse(columns[3]);
            orderInstance.ProductType = columns[4];
            orderInstance.Area = decimal.Parse(columns[5]);
            orderInstance.CostPerSquareFoot = decimal.Parse(columns[6]);
            orderInstance.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
            orderInstance.MaterialCost = decimal.Parse(columns[8]);
            orderInstance.LaborCost = decimal.Parse(columns[9]);
            orderInstance.Tax = decimal.Parse(columns[10]);
            orderInstance.Total = decimal.Parse(columns[11]);

            return orderInstance;

        }

        public void PathSelector(string date)
        {
            filePath = @".\Orders_" + date + ".txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            ReadAllFromFile();
        }
    }
}

