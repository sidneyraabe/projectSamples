using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data.Products
{
    public class TestProductRepository : IProduct
    {
        private static Product _product = new Product
        {
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M
        };
        public Product LoadProductRate(string ProductType)
        {
            if (ProductType != "Carpet")
                return null;
            return _product;
        }

        public List<Product> GetProducts()
        {
            List<Product> all = new List<Product>();
            all.Add(_product);
            return all;
        }
    }
}
