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
    public class BodyStyleRepositoryADO : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodyStyle = new List<BodyStyle>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyle currentRow = new BodyStyle();
                        currentRow.BodyStyleId = (int)dr["BodyStyleId"];
                        currentRow.BodyStyleName = dr["BodyStyleName"].ToString();

                        bodyStyle.Add(currentRow);
                    }

                }

            }
            return bodyStyle;
        }
    }
}
