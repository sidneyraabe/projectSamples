using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries.Reports
{
    public class ReportsInventoryItem
    {
        public bool IsNew { get; set; }
        public int ModelDate { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int VehicleCount { get; set; }
        public decimal TotalMsrpStockValue { get; set; }
    }
}