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
    public class ExteriorColorRepositoryADO : IExteriorColorRepository
    {
        public List<ExteriorColor> GetAll()
        {
            List<ExteriorColor> exteriorColor = new List<ExteriorColor>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColor currentRow = new ExteriorColor();
                        currentRow.ExteriorColorId = (int)dr["ExteriorColorId"];
                        currentRow.ExteriorColorName = dr["ExteriorColorName"].ToString();

                        exteriorColor.Add(currentRow);
                    }

                }

            }
            return exteriorColor;
        }
    }
}
