using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Prodavanje_igrica
{
    public static class Klasa
    {
        static SqlConnection conn = new SqlConnection();
        static string web_config = ConfigurationManager.ConnectionStrings["ProdavanjeIgrica"].ConnectionString;
        static SqlCommand comm = new SqlCommand();
        static SqlDataAdapter da = new SqlDataAdapter();
        static DataSet ds = new DataSet();
        public static int ProveraClana(string username, string pasvord)
        {
            conn.ConnectionString = web_config;
            int rezultat;
            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "dbo.Clan_Login";
            comm.Parameters.AddWithValue("@username", username);
            comm.Parameters.AddWithValue("@pasvord", pasvord);
            SqlParameter returnParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            returnParam.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(returnParam);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            rezultat = (int)comm.Parameters["@RETURN_VALUE"].Value;
            return rezultat;
        }
        public static DataSet ClanSelect(string username)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("Clan_Select", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static DataSet IgriceClana(string username)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("IgriceClana", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static int DodajNovac(string username, int novac)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("Clan_Dodaj_Novac", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@novac", novac);
                    SqlParameter returnParam = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
                    returnParam.Direction = ParameterDirection.ReturnValue;
                    comm.Parameters.Add(returnParam);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    rezultat = (int)comm.Parameters["@RETURN_VALUE"].Value;
                }
            }
            return rezultat;
        }
    }
}