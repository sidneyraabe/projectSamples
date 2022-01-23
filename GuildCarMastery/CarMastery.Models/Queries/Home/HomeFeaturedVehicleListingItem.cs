using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries.Home
{
    public class HomeFeaturedVehicleListingItem
    {
        public int VehicleId { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int ModelDate { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageLocation { get; set; }
    }
}
