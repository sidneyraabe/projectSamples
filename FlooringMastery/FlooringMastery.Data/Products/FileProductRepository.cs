using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Products
{
    public class FileProductRepository : IProduct
    {
        public const string filePath = @".\Products.txt";
        public List<Product> products = new List<Product>();
        public Product LoadProductRate(string ProductType)
        {
            ReadAllFromFile();
            return products.Where(x => x.ProductType == ProductType).FirstOrDefault();
        }
        private void ReadAllFromFile()
        {
            string[] entries = File.ReadAllLines(filePath);
            entries = entries.Skip(1).ToArray();

            foreach (var entry in entries)
            {
                Product item = ConvertLineToAccount(entry);
                products.Add(item);
            }
        }
        private Product ConvertLineToAccount(string line)
        {
            string[] columns = line.Split(',');

            Product productInstance = new Product();

            productInstance.ProductType = columns[0];
            productInstance.CostPerSquareFoot = decimal.Parse(columns[1]);
            productInstance.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

            return productInstance;
        }

        public List<Product> GetProducts()
        {
            ReadAllFromFile();
            List<Product> all = new List<Product>();
            foreach (Product p in products)
            {
                all.Add(p);
            }
            return all;
            
        }
    }
}
