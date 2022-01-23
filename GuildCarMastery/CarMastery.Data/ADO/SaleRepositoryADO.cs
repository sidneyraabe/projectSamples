using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class SaleRepositoryADO : ISaleRepository
    {
        public bool Add(Sale sale)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            VehicleRepositoryADO vrepo = new VehicleRepositoryADO();

            vehicles = vrepo.GetAll();

            Vehicle selectedVehicle = vehicles.First(v => v.VehicleId == sale.VehicleId);

            if (selectedVehicle.IsAvailable)
            {
                using (var conn = new SqlConnection(Settings.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("SaleAdd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", sale.UserId);
                    cmd.Parameters.AddWithValue("@VehicleId", sale.VehicleId);
                    cmd.Parameters.AddWithValue("@StateId", sale.StateId);
                    cmd.Parameters.AddWithValue("@PurchaseTypeId", sale.PurchaseTypeId);
                    cmd.Parameters.AddWithValue("@Price", sale.Price);
                    cmd.Parameters.AddWithValue("@DateSold", sale.DateSold);
                    cmd.Parameters.AddWithValue("@CustomerName", sale.CustomerName);
                    cmd.Parameters.AddWithValue("@Street1", sale.Street1);

                    if (sale.Street2 != null)
                        cmd.Parameters.AddWithValue("@Street2", sale.Street2);
                    else
                        cmd.Parameters.AddWithValue("@Street2", DBNull.Value);

                    if (sale.Email != null)
                        cmd.Parameters.AddWithValue("@Email", sale.Email);
                    else
                        cmd.Parameters.AddWithValue("@Email", DBNull.Value);

                    if (sale.Phone != null)
                        cmd.Parameters.AddWithValue("@Phone", sale.Phone);
                    else
                        cmd.Parameters.AddWithValue("@Phone", DBNull.Value);



                    cmd.Parameters.AddWithValue("@City", sale.City);
                    cmd.Parameters.AddWithValue("@Zip", sale.Zip);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    selectedVehicle.IsAvailable = false;
                    vrepo.Update(selectedVehicle);
                }

                // comment out if image stays in system
                var savepath = @"C:\Users\sraab\Documents\online-net-sidneyraabe\Summatives\GuildCarMastery\CarMastery\Images\";
                string[] extensionArray = new string[3] { ".png", ".jpeg", ".jpg" };
                string fileName = "inventory-" + sale.VehicleId;
                foreach (string extension in extensionArray)
                {
                    if (File.Exists(savepath + fileName + extension))
                        File.Delete(savepath + fileName + extension);
                }

                return true;
            }
            return false;
        }

        public List<Sale> GetAll()
        {
            List<Sale> sale = new List<Sale>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Sale currentRow = new Sale();
                        currentRow.SaleId = (int)dr["SaleId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.StateId = (int)dr["StateId"];
                        currentRow.PurchaseTypeId = (int)dr["PurchaseTypeId"];
                        currentRow.Price = dr["Price"].ToString();
                        currentRow.DateSold = (DateTime)dr["DateSold"];
                        currentRow.CustomerName = dr["CustomerName"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Phone = dr["Phone"].ToString();
                        currentRow.Street1 = dr["Street1"].ToString();
                        currentRow.Street2 = dr["Street2"].ToString();
                        currentRow.City = dr["City"].ToString();
                        currentRow.Zip = dr["Zip"].ToString();

                        sale.Add(currentRow);
                    }
                }
            }
            return sale;
        }

    }
}
