using FlooringMastery.Data.Products;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Products
{
    public static class ProductManagerFactory
    {
        public static ProductManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new ProductManager(new TestProductRepository());
                case "Prod":
                    return new ProductManager(new FileProductRepository());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
