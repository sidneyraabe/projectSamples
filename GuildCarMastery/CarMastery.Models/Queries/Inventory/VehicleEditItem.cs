using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries.Inventory
{
    public class VehicleEditItem
    {
        public int VehicleId { get; set; }
        public string UserId { get; set; }
        public int ModelId { get; set; }
        public int MakeId { get; set; }
        public int InteriorColorId { get; set; }
        public int ExteriorColorId { get; set; }
        public int BodyStyleId { get; set; }
        public bool IsNew { get; set; }
        public bool IsAutoTransmission { get; set; }
        public int Mileage { get; set; }
        public string Vin { get; set; }
        public decimal Msrp { get; set; }
        public decimal VehicleSalePrice { get; set; }
        public string VehicleDescription { get; set; }
        public int ModelDate { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsAvailable { get; set; }
        public string ImageLocation { get; set; }
    }
}
