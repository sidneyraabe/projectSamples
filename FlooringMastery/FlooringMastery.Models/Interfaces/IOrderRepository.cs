using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrder(string OrderNumber);
        void SaveOrder(Order order);

        void PathSelector(string date);

        void RemoveOrder(Order order);
    }
}
