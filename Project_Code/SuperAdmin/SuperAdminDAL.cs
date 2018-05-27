using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class SuperAdminDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddSuperAdmin(SuperAdminBO objSuperAdminBO)
        {

            int Superadmin_Id = 0;
            int Priestid = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Superadmin_Id,Priestid from SuperAdminLoginTable where IsActive=1";   //get superadmin id and priestid
            SqlCommand cmd_check = new SqlCommand(query, con);
            SqlDataReader dr = cmd_check.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
                Superadmin_Id = Convert.ToInt32(dr["Superadmin_Id"].ToString());
                Priestid= Convert.ToInt32(dr["Priestid"].ToString());
            }
            dr.Close();

            string query3 = "update SuperAdminLoginTable set IsActive=0 where Superadmin_Id="+ Superadmin_Id;
            SqlCommand cmd_update_isActive = new SqlCommand(query3,con);
            int result=cmd_update_isActive.ExecuteNonQuery();

            string query1 = "insert into SuperAdminLoginTable values(@Username,@Password,@Priestid,@Date_created,@IsActive)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@Username", objSuperAdminBO.Username1);
            cmd.Parameters.AddWithValue("@Password", objSuperAdminBO.Password1);
            cmd.Parameters.AddWithValue("@Priestid", objSuperAdminBO.Priestid1);
            cmd.Parameters.AddWithValue("@Date_created", objSuperAdminBO.Date_created1);
            cmd.Parameters.AddWithValue("@IsActive", objSuperAdminBO.IsActive1);

            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }
    }
}