using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Queries.Home;
using CarMastery.Models.Queries.Inventory;
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
    public class VehicleRepositoryADO : IVehicleRepository
    {
        public void Add(Vehicle vehicle)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@VehicleId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@UserId", vehicle.UserId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicle.ExteriorColorId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsAutoTransmission", vehicle.IsAutoTransmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@VehicleSalePrice", vehicle.VehicleSalePrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@ModelDate", vehicle.ModelDate);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsAvailable", 1);

                if (vehicle.ImageLocation != null)
                    cmd.Parameters.AddWithValue("@ImageLocation", vehicle.ImageLocation);
                else
                    cmd.Parameters.AddWithValue("@ImageLocation", DBNull.Value);

                conn.Open();

                cmd.ExecuteNonQuery();

                vehicle.VehicleId = (int)param.Value;
            }
        }

        public List<Vehicle> GetAll()
        {
            List<Vehicle> vehicle = new List<Vehicle>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Vehicle currentRow = new Vehicle();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.ExteriorColorId = (int)dr["ExteriorColorId"];
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.IsAutoTransmission = (bool)dr["IsAutoTransmission"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.Msrp = (decimal)dr["Msrp"];
                        currentRow.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        currentRow.VehicleDescription = dr["VehicleDescription"].ToString();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.IsFeatured = (bool)dr["IsFeatured"];
                        currentRow.IsAvailable = (bool)dr["IsAvailable"];
                        currentRow.ImageLocation = dr["ImageLocation"].ToString();

                        vehicle.Add(currentRow);
                    }
                }
            }
            return vehicle;
        }

        public void Update(Vehicle vehicle)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleEdit", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Parameters.AddWithValue("@UserId", vehicle.UserId);
                cmd.Parameters.AddWithValue("@ModelId", vehicle.ModelId);
                cmd.Parameters.AddWithValue("@InteriorColorId", vehicle.InteriorColorId);
                cmd.Parameters.AddWithValue("@ExteriorColorId", vehicle.ExteriorColorId);
                cmd.Parameters.AddWithValue("@BodyStyleId", vehicle.BodyStyleId);
                cmd.Parameters.AddWithValue("@IsNew", vehicle.IsNew);
                cmd.Parameters.AddWithValue("@IsAutoTransmission", vehicle.IsAutoTransmission);
                cmd.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                cmd.Parameters.AddWithValue("@Vin", vehicle.Vin);
                cmd.Parameters.AddWithValue("@Msrp", vehicle.Msrp);
                cmd.Parameters.AddWithValue("@VehicleSalePrice", vehicle.VehicleSalePrice);
                cmd.Parameters.AddWithValue("@VehicleDescription", vehicle.VehicleDescription);
                cmd.Parameters.AddWithValue("@ModelDate", vehicle.ModelDate);
                cmd.Parameters.AddWithValue("@IsFeatured", vehicle.IsFeatured);
                cmd.Parameters.AddWithValue("@IsAvailable", vehicle.IsAvailable);

                if (vehicle.ImageLocation != null)
                    cmd.Parameters.AddWithValue("@ImageLocation", vehicle.ImageLocation);
                else
                    cmd.Parameters.AddWithValue("@ImageLocation", DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<VehicleListingItem> SearchNew(VehicleSearchParameters input)
        {
            List<VehicleListingItem> vehicles = new List<VehicleListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("NewVehicleListingSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (input.UserInput == null)
                    input.UserInput = "";

                cmd.Parameters.AddWithValue("@Input", input.UserInput);

                if (input.PriceMin == null)
                    input.PriceMin = 0;
                cmd.Parameters.AddWithValue("@PriceMin", input.PriceMin);

                if (input.PriceMax == null)
                    input.PriceMax = 99999999;
                cmd.Parameters.AddWithValue("@PriceMax", input.PriceMax);

                if (input.YearMin == null)
                    input.YearMin = 0;
                cmd.Parameters.AddWithValue("@YearMin", input.YearMin);

                if (input.YearMax == null)
                    input.YearMax = 9999;
                cmd.Parameters.AddWithValue("@YearMax", input.YearMax);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleListingItem currentRow = new VehicleListingItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.IsAutoTransmission = (bool)dr["IsAutoTransmission"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        currentRow.Msrp = (decimal)dr["Msrp"];
                        currentRow.IsAvailable = (bool)dr["IsAvailable"];
                        currentRow.ImageLocation = dr["ImageLocation"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

            }
            return vehicles;
        }

        public IEnumerable<VehicleListingItem> SearchUsed(VehicleSearchParameters input)
        {
            List<VehicleListingItem> vehicles = new List<VehicleListingItem>();

            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UsedVehicleListingSelect";
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                if (input.UserInput == null)
                    input.UserInput = "";
                cmd.Parameters.AddWithValue("@Input", input.UserInput);

                if (input.PriceMin == null)
                    input.PriceMin = 0;
                cmd.Parameters.AddWithValue("@PriceMin", input.PriceMin);

                if (input.PriceMax == null)
                    input.PriceMax = 99999999;
                cmd.Parameters.AddWithValue("@PriceMax", input.PriceMax);

                if (input.YearMin == null)
                    input.YearMin = 0;
                cmd.Parameters.AddWithValue("@YearMin", input.YearMin);

                if (input.YearMax == null)
                    input.YearMax = 9999;
                cmd.Parameters.AddWithValue("@YearMax", input.YearMax);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleListingItem currentRow = new VehicleListingItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.IsAutoTransmission = (bool)dr["IsAutoTransmission"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        currentRow.Msrp = (decimal)dr["Msrp"];
                        currentRow.IsAvailable = (bool)dr["IsAvailable"];
                        currentRow.ImageLocation = dr["ImageLocation"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

            }
            return vehicles;
        }

        public IEnumerable<VehicleListingItem> SearchAll(VehicleSearchParameters input)
        {
            List<VehicleListingItem> vehicles = new List<VehicleListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleListingSelect", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (input.UserInput == null)
                    input.UserInput = "";
                cmd.Parameters.AddWithValue("@Input", input.UserInput);

                if (input.PriceMin == null)
                    input.PriceMin = 0;
                cmd.Parameters.AddWithValue("@PriceMin", input.PriceMin);

                if (input.PriceMax == null)
                    input.PriceMax = 99999999;
                cmd.Parameters.AddWithValue("@PriceMax", input.PriceMax);

                if (input.YearMin == null)
                    input.YearMin = 0;
                cmd.Parameters.AddWithValue("@YearMin", input.YearMin);

                if (input.YearMax == null)
                    input.YearMax = 9999;
                cmd.Parameters.AddWithValue("@YearMax", input.YearMax);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        VehicleListingItem currentRow = new VehicleListingItem();

                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();
                        currentRow.IsAutoTransmission = (bool)dr["IsAutoTransmission"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        currentRow.IsNew = (bool)dr["IsNew"];
                        currentRow.Mileage = (int)dr["Mileage"];
                        currentRow.Vin = dr["Vin"].ToString();
                        currentRow.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        currentRow.Msrp = (decimal)dr["Msrp"];
                        currentRow.IsAvailable = (bool)dr["IsAvailable"];
                        currentRow.ImageLocation = dr["ImageLocation"].ToString();

                        vehicles.Add(currentRow);
                    }
                }

            }
            return vehicles;
        }

        public IEnumerable<HomeFeaturedVehicleListingItem> GetAllFeatured()
        {
            List<HomeFeaturedVehicleListingItem> fvehicle = new List<HomeFeaturedVehicleListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("FeaturedVehicleSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        HomeFeaturedVehicleListingItem currentRow = new HomeFeaturedVehicleListingItem();
                        currentRow.VehicleId = (int)dr["VehicleId"];
                        currentRow.ModelDate = (int)dr["ModelDate"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        currentRow.IsAvailable = (bool)dr["IsAvailable"];
                        currentRow.ImageLocation = dr["ImageLocation"].ToString();

                        fvehicle.Add(currentRow);
                    }
                }
            }
            return fvehicle;
        }

        public VehicleDetailsItem GetById(int vehicleId)
        {
            VehicleDetailsItem vehicle = new VehicleDetailsItem();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);


                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.ModelDate = (int)dr["ModelDate"];
                        vehicle.MakeName = dr["MakeName"].ToString();
                        vehicle.ModelName = dr["ModelName"].ToString();
                        vehicle.BodyStyleName = dr["BodyStyleName"].ToString();
                        bool transmissionData = (bool)dr["IsAutoTransmission"];
                        vehicle.TransmissionType = "Manual";
                        if (transmissionData)
                            vehicle.TransmissionType = "Automatic";
                        vehicle.InteriorColorName = dr["InteriorColorName"].ToString();
                        vehicle.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        vehicle.IsNew = (bool)dr["IsNew"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.IsAvailable = (bool)dr["IsAvailable"];
                        vehicle.ImageLocation = dr["ImageLocation"].ToString();
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                    }
                }

            }
            return vehicle;
        }

        public VehicleEditItem GetEditById(int vehicleId)
        {
            VehicleEditItem vehicle = new VehicleEditItem();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("VehicleEditItemGetById", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);


                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle.VehicleId = (int)dr["VehicleId"];
                        vehicle.ModelDate = (int)dr["ModelDate"];
                        vehicle.ModelId = (int)dr["ModelId"];
                        vehicle.MakeId = (int)dr["MakeId"];
                        vehicle.InteriorColorId = (int)dr["InteriorColorId"];
                        vehicle.ExteriorColorId = (int)dr["ExteriorColorId"];
                        vehicle.BodyStyleId = (int)dr["BodyStyleId"];
                        vehicle.IsNew = (bool)dr["IsNew"];
                        vehicle.IsAutoTransmission = (bool)dr["IsAutoTransmission"];
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.Vin = dr["Vin"].ToString();
                        vehicle.VehicleSalePrice = (decimal)dr["VehicleSalePrice"];
                        vehicle.Msrp = (decimal)dr["Msrp"];
                        vehicle.IsAvailable = (bool)dr["IsAvailable"];
                        vehicle.ImageLocation = dr["ImageLocation"].ToString();
                        vehicle.VehicleDescription = dr["VehicleDescription"].ToString();
                        vehicle.IsFeatured = (bool)dr["IsFeatured"];
                    }
                }

            }
            return vehicle;
        }

        public void Delete(int vehicleId)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteVehicle", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                conn.Open();

                cmd.ExecuteNonQuery();
            }


            var savepath = @"C:\Users\sraab\Documents\online-net-sidneyraabe\Summatives\GuildCarMastery\CarMastery\Images\";
            string[] extensionArray = new string[3] { ".png", ".jpeg", ".jpg" };
            string fileName = "inventory-" + vehicleId;
            foreach (string extension in extensionArray)
            {
                if (File.Exists(savepath + fileName + extension))
                   File.Delete(savepath + fileName + extension);

            }
        }
    }
}


