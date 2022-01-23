using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Products
{
    public class ProductManager
    {
        private IProduct _product;

        public ProductManager(IProduct product)
        {
            _product = product;
        }

        public ProductLookupResponse LookupProduct(string productType)
        {
            ProductLookupResponse response = new ProductLookupResponse();

            response.Product = _product.LoadProductRate(productType);
            if (response.Product == null)
            {
                response.Success = false;

                response.Message = $"{productType} is not currently in the product directory.";
            }
            else
                response.Success = true;
            return response;
        }
       
        public List<Product> ListProducts()
        {
            return _product.GetProducts();
        }

    }
}
