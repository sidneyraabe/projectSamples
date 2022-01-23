using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNumber { get; set; } // generated w LINQ
        public string CustomerName { get; set; } // (prompt)
        public string State { get; set; } // (prompt)
        public decimal TaxRate { get; set; } // (get, from LoadTaxRate(State))
        public string ProductType { get; set; } // (prompt)
        public decimal Area { get; set; } // (prompt)
        public decimal CostPerSquareFoot { get; set; } // (get, from LoadProductRate(ProductName))
        public decimal LaborCostPerSquareFoot { get; set; } // (get, from LoadProductRate(ProductName))
        public decimal MaterialCost { get; set; } // Calculate: (Area * CostPerSquareFoot)
        public decimal LaborCost { get; set; } // Calculate: (Area * LaborCostPerSquareFoot)
        public decimal Tax { get; set; } // Calculate: ((MaterialCost + LaborCost) * (TaxRate / 100))
        public decimal Total { get; set; } // Calculate: (MaterialCost + LaborCost + Tax)
    }
}
