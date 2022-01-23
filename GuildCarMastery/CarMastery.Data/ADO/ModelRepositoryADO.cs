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
    public class ModelRepositoryADO : IModelRepository
    {
        public void Add(Model model)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@MakeId", model.MakeId);
                cmd.Parameters.AddWithValue("@UserId", model.UserId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<ModelListingItem> GetAll()
        {
            List<ModelListingItem> model = new List<ModelListingItem>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelListingItem currentRow = new ModelListingItem();
                        currentRow.ModelId = (int)dr["ModelId"];
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.ModelName = dr["ModelName"].ToString();
                        currentRow.MakeName = dr["MakeName"].ToString();
                        currentRow.UserId = dr["UserId"].ToString();
                        currentRow.DateAdded = (DateTime)dr["DateAdded"];

                        model.Add(currentRow);
                    }
                }
            }
            return model;
        }
    }
}
