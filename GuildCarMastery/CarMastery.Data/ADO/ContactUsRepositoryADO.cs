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
    public class ContactUsRepositoryADO : IContactUsRepository
    {
        public void Add(ContactUs contactUs)
        {
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactUsAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (contactUs.Phone != null)
                    cmd.Parameters.AddWithValue("Phone", contactUs.Phone);
                else
                    cmd.Parameters.AddWithValue("@Phone", DBNull.Value);

                cmd.Parameters.AddWithValue("@Name", contactUs.Name);
                if (contactUs.Email != null)
                    cmd.Parameters.AddWithValue("@Email", contactUs.Email);
                else
                    cmd.Parameters.AddWithValue("@Email", DBNull.Value);

                cmd.Parameters.AddWithValue("@Message", contactUs.Message);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<ContactUs> GetAll()
        {
            List<ContactUs> contactUs = new List<ContactUs>();
            using (var conn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactUsSelectAll", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ContactUs currentRow = new ContactUs();
                        currentRow.VehicleInquiryId = (int)dr["VehicleInquiryId"];
                        currentRow.Phone = dr["Phone"].ToString();                        
                        currentRow.Name = dr["Name"].ToString();
                        currentRow.Email = dr["Email"].ToString();
                        currentRow.Message = dr["Message"].ToString();

                        contactUs.Add(currentRow);
                    }

                }

            }
            return contactUs;
        }
    }
}
