using CarMastery.Data.Interfaces;
using CarMastery.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CarMastery.Data.ADO
{
    public class StateRepositoryADO : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> states = new List<State>();
            using(var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateId = (int) dr["StateId"];
                        currentRow.StateName = dr["StateName"].ToString();

                        states.Add(currentRow);
                    }
                    
                }

            }
            return states;
        }
    }
}
