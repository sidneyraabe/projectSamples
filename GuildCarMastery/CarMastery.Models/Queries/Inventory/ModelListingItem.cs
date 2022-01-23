using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries
{
    public class ModelListingItem
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string MakeName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; } 
        public int MakeId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
