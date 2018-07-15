using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Diocese.Project_Code
{
    public class CommunionDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddCommunionRequest(CommunionBO objCommunionBO, int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "insert into CommunionTable values(@FamilyName,@Parish_id,@OfficialName,@BaptismName,@Gender,@FName,@MName,@DO_communion,@dobirth)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@FamilyName", objCommunionBO.FamilyName1);
            cmd.Parameters.AddWithValue("@Parish_id", parishid);
            cmd.Parameters.AddWithValue("@OfficialName", objCommunionBO.OfficialName1);
            cmd.Parameters.AddWithValue("@BaptismName", objCommunionBO.BaptismName1);
            cmd.Parameters.AddWithValue("@Gender", objCommunionBO.Gender1);
            cmd.Parameters.AddWithValue("@FName", objCommunionBO.FName1);
            cmd.Parameters.AddWithValue("@MName", objCommunionBO.MName1);
            cmd.Parameters.AddWithValue("@DO_communion", objCommunionBO.DO_communion1);
            cmd.Parameters.AddWithValue("@dobirth", objCommunionBO.DO_Birth1);
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }

        public string getPriestname(int parishid)
        {
            String priestname = string.Empty;
           
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query2 = "select Parish_Priest_Name from Sup_PriestTable where Current_Parish_id=" + parishid;
            SqlCommand cmd_priestname = new SqlCommand(query2, con);
            SqlDataReader dr = cmd_priestname.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
               
                priestname=dr["Parish_Priest_Name"].ToString();
            }

           
            dr.Close();
            return priestname;
        }

        public int count_of_Female(int parishid)
        {
            int countFemale = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select count(Gender) from CommunionTable where Parish_id=" + parishid + " and Gender='Female'";
            SqlCommand cmd = new SqlCommand(query, con);
            countFemale = (int)cmd.ExecuteScalar();
            con.Close();
            return countFemale;
            
        }

        public int count_of_Male(int parishid)
        {
            int countMale = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select count(Gender) from CommunionTable where Parish_id=" + parishid + " and Gender='Male'";
            SqlCommand cmd = new SqlCommand(query, con);
            countMale = (int)cmd.ExecuteScalar();
            con.Close();
            return countMale;
        }

        public int Delete_CommunionDetails(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from CommunionTable where Communion_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable Load_data(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Communion_ID,FamilyName,Parish_id,OfficialName,BaptismName,Gender,CONVERT (date,[DO_communion]) as [DO_communion] from CommunionTable where Parish_id=" + parishid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Get_SearchCommunionDetails(CommunionBO objCommunionBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Communion_ID,FamilyName,Parish_id,OfficialName,BaptismName,Gender,CONVERT (date,[DO_communion]) as [DO_communion] from CommunionTable where Parish_id=" + objCommunionBO.Parish_id1 + " and DO_communion='"+ objCommunionBO.DO_communion1+ "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;

        }

        
    }
}