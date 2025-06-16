using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;
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
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("dbo.Clan_Login", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@username", username);
                    comm.Parameters.AddWithValue("@pasvord", pasvord);
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
        public static int ClanIgricaDelete(string clan, int igrica)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("Clan_Igrica_Delete", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@user", clan);
                    comm.Parameters.AddWithValue("@id", igrica);
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
        public static DataSet IgriceKojeClanNema(string username)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("IgriceKojeClanNema", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@username", username);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static int InsertClanIgrica(string username, int igrica)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("ClanIgrica_Insert", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@clan", username);
                    comm.Parameters.AddWithValue("@igrica_id", igrica);
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
        public static DataSet DeveloperSelect()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("Developer_Select", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static DataSet SistemSelect()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("Sistem_Select", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static DataSet ZanrSelect()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(web_config))
            using (SqlCommand comm = new SqlCommand("Zanr_Select", conn))
            {
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            return ds;
        }
        public static int ZanrInsert(string naziv)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("Zanr_Insert", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@naziv", naziv);
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
        public static int SystemInsert(string naziv)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("System_Insert", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@naziv", naziv);
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
        public static int DeveloperInsert(string naziv, string sajt)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("Developer_Insert", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@naziv", naziv);
                    comm.Parameters.AddWithValue("@site", sajt);
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
        public static int IgricaInsert(string naziv, DateTime datum, string developer, string sistem, string zanr)
        {
            int rezultat;
            using (SqlConnection conn = new SqlConnection(web_config))
            {
                using (SqlCommand comm = new SqlCommand("Igrica_Insert", conn))
                {
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@naziv", naziv);
                    comm.Parameters.AddWithValue("@datum", datum);
                    comm.Parameters.AddWithValue("@developer", developer);
                    comm.Parameters.AddWithValue("@system", sistem);
                    comm.Parameters.AddWithValue("@zanr", zanr);
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