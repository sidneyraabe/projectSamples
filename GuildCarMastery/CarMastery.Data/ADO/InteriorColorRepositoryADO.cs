using CarMastery.Data.Interfaces;
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
    public class InteriorColorRepositoryADO : IInteriorColorRepository
    {
        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> interiorColor = new List<InteriorColor>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColor currentRow = new InteriorColor();
                        currentRow.InteriorColorId = (int)dr["InteriorColorId"];
                        currentRow.InteriorColorName = dr["InteriorColorName"].ToString();

                        interiorColor.Add(currentRow);
                    }

                }

            }
            return interiorColor;
        }
    }
}
