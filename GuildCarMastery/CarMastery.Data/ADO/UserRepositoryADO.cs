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
    public class UserRepositoryADO : IUserRepository
    {
        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UserSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        User currentRow = new User();
                        currentRow.Id = dr["Id"].ToString();
                        currentRow.RoleId = (int)dr["RoleId"];

                        currentRow.RoleName = "Disabled";
                        if (currentRow.RoleId == 1)
                            currentRow.RoleName = "Admin";
                        else if (currentRow.RoleId == 2)
                            currentRow.RoleName = "Sales";

                        currentRow.LastName = dr["LastName"].ToString();
                        currentRow.FirstName = dr["FirstName"].ToString();
                        currentRow.Email = dr["Email"].ToString();

                        users.Add(currentRow);
                    }

                }

            }
            return users;
        }
    }
}
