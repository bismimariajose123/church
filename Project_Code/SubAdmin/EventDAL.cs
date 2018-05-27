using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class EventDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddEvent(EventBO objEventBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "insert into EventTable values(@Parishid,@EventName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Parishid", objEventBO.Parishid1);
            cmd.Parameters.AddWithValue("@EventName", objEventBO.EventName1);
            int a = cmd.ExecuteNonQuery();
            return a;
        }
    }
}