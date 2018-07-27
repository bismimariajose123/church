using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class WardDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddWard(WardBO objAddWardBO)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sub_WardTable values(@WardName,@Parishid)", con);
            try
            {
                cmd.Parameters.AddWithValue("@WardName", objAddWardBO.Wardname);
                cmd.Parameters.AddWithValue("@Parishid", objAddWardBO.Parish_id);
                result=cmd.ExecuteNonQuery();
                con.Close();
               
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
            return result;
        }

      

        public DataTable Get_Search_WardDetails(WardBO objWardBO,string searchstr)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select w.Ward_ID, w.WardName,f.Family_ID,count(m.Member_ID) as peoplecount from Sub_WardTable w ,Sub_Create_FamilyLoginTable f,MemberDetailsTable m  where f.Ward_id=w.Ward_ID and m.Family_id=f.Family_ID and m.Parish_id=@id and WardName like '%" + searchstr + "%' group by  w.Ward_ID, w.WardName,f.Family_ID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", objWardBO.Parish_id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
          
        }

        public int UpdateWard(WardBO objWardBO, int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sub_WardTable set WardName=@wardname where Ward_ID=@id", con);
            cmd.Parameters.AddWithValue("@wardname", objWardBO.Wardname);
            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            return result;
        }

        public int Delete_Ward(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Sub_WardTable where Ward_ID=@id", con);
            cmd.Parameters.AddWithValue("@id",id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable GetWardDetail(WardBO objAddWardBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select w.Ward_ID, w.WardName,f.Family_ID,count(m.Member_ID) as peoplecount from Sub_WardTable w ,Sub_Create_FamilyLoginTable f,MemberDetailsTable m  where f.Ward_id=w.Ward_ID and m.Family_id=f.Family_ID and m.Parish_id=@id group by  w.Ward_ID, w.WardName,f.Family_ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",objAddWardBO.Parish_id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }
    }
}