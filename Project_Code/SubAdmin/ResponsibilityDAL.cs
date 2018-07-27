using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ResponsibilityDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddResponsibility(ResponsibilityBO objResponsibilityBO)   //ADD RESPONSIBILITY(1)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ResponsibilityTable values(@uname,@pwd,@Parishid,@DutyName)", con);

            cmd.Parameters.AddWithValue("@uname", objResponsibilityBO.Uname);
            cmd.Parameters.AddWithValue("@pwd", objResponsibilityBO.Pwd);
            cmd.Parameters.AddWithValue("@Parishid", objResponsibilityBO.Parishid1);
            cmd.Parameters.AddWithValue("@DutyName", objResponsibilityBO.DutyName1);
           
            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public int chk_duplicate_responsibility(ResponsibilityBO objResponsibilityBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select count(*) from ResponsibilityTable where Parishid="+ objResponsibilityBO.Parishid1+ "and DutyName='" + objResponsibilityBO.DutyName1+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            int Result = Convert.ToInt16(cmd.ExecuteScalar());
            con.Close();
            return Result;



        }
    }
}