using CarMastery.Models.Queries.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Interfaces
{
    public interface IReportRepository
    {
        IEnumerable<ReportsSalesItem> SearchSalesAll(ReportsSalesSearchParameters input);
        IEnumerable<ReportsSalesItem> SearchSalesByUser(ReportsSalesSearchParameters input);
        IEnumerable<ReportsInventoryItem> GetAllNew();
        IEnumerable<ReportsInventoryItem> GetAllUsed();
    }
}
