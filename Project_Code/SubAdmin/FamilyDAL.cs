using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class FamilyDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public  int AddFamily(FamilyBO objFamilyBO)
        {

            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sub_Create_FamilyLoginTable values(@FamilyName,@Ward_id,@Parish_id,@Username,@Password,@FamilyNo,@Contact_No,@HeadName)", con);
            
            try
            {
                cmd.Parameters.AddWithValue("@FamilyName", objFamilyBO.familyname);
                cmd.Parameters.AddWithValue("@Ward_id", objFamilyBO.ward_id);
                cmd.Parameters.AddWithValue("@Parish_id", objFamilyBO.parish_id);
                cmd.Parameters.AddWithValue("@Username", objFamilyBO.username);
                cmd.Parameters.AddWithValue("@Password", objFamilyBO.password);
                cmd.Parameters.AddWithValue("@FamilyNo", objFamilyBO.Familyno); 
                cmd.Parameters.AddWithValue("@Contact_No", objFamilyBO.ContactNo);
                cmd.Parameters.AddWithValue("@HeadName", objFamilyBO.Headname);
                result = cmd.ExecuteNonQuery();

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

        public DataTable GetFamilyDetails(FamilyBO objFamilyBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "select c.Family_ID,w.WardName,c.FamilyNo,c.FamilyName,c.HeadName,c.Username,c.Password," +
                "c.Contact_No from Sub_Create_FamilyLoginTable c,Sub_WardTable w where w.Ward_ID=c.Ward_id  and c.Parish_id=" + objFamilyBO.parish_id;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable GetWardName(FamilyBO objFamilyBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd_get_warddetails = new SqlCommand("select * from Sub_WardTable where Parishid="+ objFamilyBO.parish_id, con);
            SqlDataAdapter sda =new SqlDataAdapter(cmd_get_warddetails);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public FamilyBO GetFamilyNo(FamilyBO objFamilyBO)
        {

            int result=0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmdcheck= new SqlCommand("select * from Sub_Create_FamilyLoginTable where Parish_id=" + objFamilyBO.parish_id, con);
            SqlDataReader dr1 = cmdcheck.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                result = 1;
            }
          
            dr1.Close();

            if(result==1)
            {
                SqlCommand cmdSelect = new SqlCommand("select max(FamilyNo) from Sub_Create_FamilyLoginTable where Parish_id=" + objFamilyBO.parish_id, con);
                int familyno= Convert.ToInt32(cmdSelect.ExecuteScalar());
                objFamilyBO.Familyno = familyno + 1;
            }
            else
            {
                objFamilyBO.Familyno = 1;
            }
            
            return objFamilyBO;
        }
    }
}