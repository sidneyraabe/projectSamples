using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Tables
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string UserId { get; set; }
        public int VehicleId { get; set; }
        public int StateId { get; set; }
        public int PurchaseTypeId { get; set; }
        public string Price { get; set; }
        public DateTime DateSold { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
    }
}
