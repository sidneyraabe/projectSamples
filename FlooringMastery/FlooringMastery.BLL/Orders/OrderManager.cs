using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupDate(string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(orderDate);

            if (response.Order.Count == 0)
            {
                response.Success = false;

                DateTime dtobject = DateTime.ParseExact(orderDate, "MMddyyyy", null);
                string newdtstring = dtobject.ToString("MMM dd, yyyy");

                response.Message = $"No orders were placed on {newdtstring}.";
            }
            else
            {
                response.Success = true;
            }
            return response;
        }

        public OrderLookupResponse LookupOrder(string date, int ordernumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(date);

            DateTime dtobject = DateTime.ParseExact(date, "MMddyyyy", null);
            string newdtstring = dtobject.ToString("MMM dd, yyyy");

            if (response.Order == null)
            {
                response.Success = false;               
                response.Message = $"No orders were placed on {newdtstring}.";
            }
            else
            {
                response.Success = false; // will reassign true if ID matches, or else will stay false
                foreach (Order order in response.Order)
                {
                    if (order.OrderNumber == ordernumber)
                        response.Success = true;                  
                }

                if (response.Success == false)                
                    response.Message = $"No order ID of {ordernumber} was placed on {newdtstring}.";
                
            }
            return response;
        }
        public void SaveOrder(Order input)
        {
            _orderRepository.SaveOrder(input);
        }

        public void PathSelector(string date)
        {
            _orderRepository.PathSelector(date);
        }

        public void RemoveOrder(Order input)
        {
            _orderRepository.RemoveOrder(input);
        }
    }
}
