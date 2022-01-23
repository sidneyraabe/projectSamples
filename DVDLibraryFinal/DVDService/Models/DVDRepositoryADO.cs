using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDService.Models
{
    public class DVDRepositoryADO : IDVDRepository
    {
        public void Create(DVD newDVD)
        {
            string title = newDVD.Title;
            int releaseYear = newDVD.ReleaseYear;
            string director = newDVD.Director;
            string rating = newDVD.Rating;
            string notes = newDVD.Notes;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "CreateDVD";

                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            
        }

        public void Delete(int dvdId)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDVD";

                cmd.Parameters.AddWithValue("@Id", dvdId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DVD Get(int dvdId)
        { 
            DVD retrievedDVD = new DVD();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetDVDById";

                cmd.Parameters.AddWithValue("@Id", dvdId);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        retrievedDVD.Id = (int)dr["Id"];
                        retrievedDVD.Title = dr["Title"].ToString();
                        retrievedDVD.ReleaseYear = (int)dr["ReleaseYear"];
                        retrievedDVD.Director = dr["Director"].ToString();
                        retrievedDVD.Rating = dr["Rating"].ToString();
                        retrievedDVD.Notes = dr["Notes"].ToString();
                    }
                }

            }
            return retrievedDVD;
        }

        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "GetAllDVD";

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Id = (int)dr["Id"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetAllMatchingDirectorName(string searchString)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "GetDVDByDirectorName";
                cmd.Parameters.AddWithValue("@Director", searchString);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Id = (int)dr["Id"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetAllMatchingRating(string searchString)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "GetDVDByRating";
                cmd.Parameters.AddWithValue("@Rating", searchString);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Id = (int)dr["Id"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetAllMatchingReleaseYear(int searchString)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "GetDVDByReleaseYear";
                cmd.Parameters.AddWithValue("@ReleaseYear", searchString);
                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Id = (int)dr["Id"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetAllMatchingTitle(string searchString)
        {
            List<DVD> dvds = new List<DVD>();
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = "GetDVDByTitle";
                cmd.Parameters.AddWithValue("@Title", searchString);

                conn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.Id = (int)dr["Id"];
                        currentRow.Title = dr["Title"].ToString();
                        currentRow.ReleaseYear = (int)dr["ReleaseYear"];
                        currentRow.Director = dr["Director"].ToString();
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.Notes = dr["Notes"].ToString();

                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public void Update(DVD updatedDVD)
        {
            int id = updatedDVD.Id;
            string title = updatedDVD.Title;
            int releaseYear = updatedDVD.ReleaseYear;
            string director = updatedDVD.Director;
            string rating = updatedDVD.Rating;
            string notes = updatedDVD.Notes;

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DvdLibraryApp"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateDVD";

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@Rating", rating);
                cmd.Parameters.AddWithValue("@Notes", notes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}