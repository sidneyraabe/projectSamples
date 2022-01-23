using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class VehicleListingItem
    {
        public int VehicleId { get; set; }
        public string UserId { get; set; }
        public int ModelDate { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }

        public string BodyStyleName { get; set; }
        public bool IsAutoTransmission { get; set; }
        public string InteriorColorName { get; set; }
        public string ExteriorColorName { get; set; }
        public bool IsNew { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public decimal Msrp { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageLocation { get; set; }
    }
}
