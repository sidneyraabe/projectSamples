using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Models.Queries.Reports
{
    public class ReportsSalesSearchParameters
    {
        public string UserId { get; set; }
        public string FirstLast { get; set; }
        public string DateMin { get; set; }
        public string DateMax { get; set; }

    }
}
