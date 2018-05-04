using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Sub_admin_LoginDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public  int Add_sub_admin_login(Sub_admin_LoginBO obj_Sub_admin_LoginBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sup_SubAdminTable values(@Sub_Ad_uname,@Sub_Ad_password,@Sub_Ad_Parish_id,@Priest_Id)", con);
            try
            {
                cmd.Parameters.AddWithValue("@Sub_Ad_uname", obj_Sub_admin_LoginBO.Sub_admin_UName);
                cmd.Parameters.AddWithValue("@Sub_Ad_password", obj_Sub_admin_LoginBO.Sub_Ad_PWD);
                cmd.Parameters.AddWithValue("@Sub_Ad_Parish_id", obj_Sub_admin_LoginBO.Sub_Ad_ParishID);
                cmd.Parameters.AddWithValue("@Priest_Id",0);
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
    }
}