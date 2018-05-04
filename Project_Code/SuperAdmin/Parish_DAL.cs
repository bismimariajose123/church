using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Parish_DAL
    {
        //SQL Connection string
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public int InsertParishInformation(Parish_BO objParishDetails_BO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sup_ParishTable values(@ParishName,@Place,@Username,@Password)", con);
            try
            {
                cmd.Parameters.AddWithValue("@ParishName", objParishDetails_BO.ParishName);
                cmd.Parameters.AddWithValue("@Place", objParishDetails_BO.ParishPlace);
                cmd.Parameters.AddWithValue("@Username", objParishDetails_BO.UName);
                cmd.Parameters.AddWithValue("@Password", objParishDetails_BO.Passwd);
                int Result = cmd.ExecuteNonQuery();
                con.Close();
                return Result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public int DeleteParish(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Sup_ParishTable where Parish_ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);         
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public  DataTable Get_Search_ParishInformation(string searchstr)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from Sup_ParishTable where Parish_Name like '%"+searchstr+"%'or Place like '%"+searchstr+"%'";
            
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int UpdateParish(Parish_BO objParishDetails_BO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sup_ParishTable set Parish_Name=@ParishName,Place=@Place,Username=@Username,Password=@Password where Parish_ID = @id", con);
            cmd.Parameters.AddWithValue("@ParishName", objParishDetails_BO.ParishName);
            cmd.Parameters.AddWithValue("@Place", objParishDetails_BO.ParishPlace);
            cmd.Parameters.AddWithValue("@Username", objParishDetails_BO.UName);
            cmd.Parameters.AddWithValue("@Password", objParishDetails_BO.Passwd);
            cmd.Parameters.AddWithValue("@id",id);
            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public DataTable GetParishInformation()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sup_ParishTable", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt); 
            return dt;

        }
    }
}