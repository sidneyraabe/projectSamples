using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Data
{
    public class TestOrderRepository : IOrderRepository
    {
        private static List<Order> _orders = new List<Order>();
        private static Order _order = new Order
        {
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            MaterialCost = 515.00M,
            LaborCost = 475.00M,
            Tax = 61.88M,
            Total = 1051.88M
        };

        public List<Order> LoadOrder(string OrderDate)
        {
            if (OrderDate != "06012013")
                return null; // bs'd... foreach o in _orders, match orderdate... how to match order date?
            _orders.Add(_order);
            return _orders;
        }

        public void SaveOrder(Order order)
        {
            _order = order;
        }

        public void PathSelector(string date)
        {
            // write
        }
        public void RemoveOrder(Order order)
        {
            // write
        }

    }
}
