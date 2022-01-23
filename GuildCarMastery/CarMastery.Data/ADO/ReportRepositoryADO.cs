using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class ReportRepositoryADO : IReportRepository
    {
        public IEnumerable<ReportsInventoryItem> GetAllNew()
        {
            List<ReportsInventoryItem> reportInventory = new List<ReportsInventoryItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventorySelectNew", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReportsInventoryItem currentRow = new ReportsInventoryItem();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.VehicleCount = (int)dr["VehicleCount"];
                        currentRow.TotalMsrpStockValue = (decimal)dr["TotalMsrpStockValue"];


                        reportInventory.Add(currentRow);
                    }
                }
            }
            return reportInventory;
        }

        public IEnumerable<ReportsInventoryItem> GetAllUsed()
        {
            List<ReportsInventoryItem> reportInventory = new List<ReportsInventoryItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InventorySelectUsed", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReportsInventoryItem currentRow = new ReportsInventoryItem();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.VehicleCount = (int)dr["VehicleCount"];
                        currentRow.TotalMsrpStockValue = (decimal)dr["TotalMsrpStockValue"];

                        reportInventory.Add(currentRow);
                    }
                }
            }
            return reportInventory;
        }

        public IEnumerable<ReportsSalesItem> SearchSalesAll(ReportsSalesSearchParameters input)
        {
            List<ReportsSalesItem> reportSales = new List<ReportsSalesItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSearchAllUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (input.DateMin == null)
                {
                    DateTime dateMin = new DateTime(1800, 01, 01);
                    input.DateMin = dateMin.ToShortDateString();
                }
                cmd.Parameters.AddWithValue("@DateMin", input.DateMin);

                if (input.DateMax == null)
                {
                    DateTime dateMax = new DateTime(9999, 12, 31);
                    input.DateMax = dateMax.ToShortDateString();
                }
                cmd.Parameters.AddWithValue("@DateMax", input.DateMax);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReportsSalesItem currentRow = new ReportsSalesItem();

                        currentRow.FirstLast = dr["FirstLast"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];


                        reportSales.Add(currentRow);
                    }
                }

            }
            return reportSales;
        }

        public IEnumerable<ReportsSalesItem> SearchSalesByUser(ReportsSalesSearchParameters input)
        {
            List<ReportsSalesItem> reportSales = new List<ReportsSalesItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SalesSearchByUser", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (input.FirstLast == null)
                    input.FirstLast = "";
                cmd.Parameters.AddWithValue("@FirstLast", input.FirstLast);

                if (input.DateMin == null)
                {
                    DateTime dateMin = new DateTime(1800, 01, 01);
                    input.DateMin = dateMin.ToShortDateString();
                }
                cmd.Parameters.AddWithValue("@DateMin", input.DateMin);

                if (input.DateMax == null)
                {
                    DateTime dateMax = new DateTime(9999, 12, 31);
                    input.DateMax = dateMax.ToShortDateString();
                }
                cmd.Parameters.AddWithValue("@DateMax", input.DateMax);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ReportsSalesItem currentRow = new ReportsSalesItem();

                        currentRow.FirstLast = dr["FirstLast"].ToString();
                        currentRow.TotalSales = (decimal)dr["TotalSales"];
                        currentRow.TotalVehicles = (int)dr["TotalVehicles"];
                     
                        reportSales.Add(currentRow);
                    }
                }

            }
            return reportSales;
        }
    }
}
