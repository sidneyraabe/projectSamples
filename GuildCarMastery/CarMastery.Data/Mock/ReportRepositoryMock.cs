using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.Mock
{
    public class ReportRepositoryMock : IReportRepository
    {
        public IEnumerable<ReportsInventoryItem> GetAllNew()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportsInventoryItem> GetAllUsed()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportsSalesItem> SearchSalesAll(ReportsSalesSearchParameters input)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportsSalesItem> SearchSalesByUser(ReportsSalesSearchParameters input)
        {
            throw new NotImplementedException();
        }
    }
}
