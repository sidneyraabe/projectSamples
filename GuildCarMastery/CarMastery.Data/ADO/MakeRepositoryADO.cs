using CarMastery.Data.Interfaces;
using CarMastery.Models.Queries;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMastery.Data.ADO
{
    public class MakeRepositoryADO : IMakeRepository
    {
        public void Add(string makeName, string userId)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeName", makeName);
                cmd.Parameters.AddWithValue("@UserId", userId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<MakeListingItem> GetAll()
        {
            List<MakeListingItem> make = new List<MakeListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeListingItem currentRow = new MakeListingItem();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.MakeId = (int)dr["MakeId"];
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        make.Add(currentRow);
                    }
                }
            }
            return make;
        }

        public IEnumerable<ModelListingItem> GetModels(int makeId)
        {
            List<ModelListingItem> models = new List<ModelListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectModelsFromMake", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeId", makeId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelListingItem currentRow = new ModelListingItem();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.ModelId = (int)dr["ModelId"];

                        models.Add(currentRow);

                    }
                }
            }
            return models;
        }
    }
}
