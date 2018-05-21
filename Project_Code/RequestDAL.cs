using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class RequestDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public  DataTable GetNotificationDetails(RequestBO objRequestBO) //notifications details
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select r.Event_Name,b.FamilyName,b.OfficialName,r.ProposedDateOfBap,r.ProposedTimeOfBap,r.Memberid,r.RequestStatus_Description,r.RequestStatus from Sub_RequestTable r left join BaptismTable b on r.Memberid = b.Memberid where r.Parishid="+ objRequestBO.Parishid1;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int UpdateRequest(RequestBO objRequestBO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sub_RequestTable set RequestStatus_Description=@requestdesc,RequestStatus=@Status where Memberid = @id", con);
            cmd.Parameters.AddWithValue("@requestdesc", objRequestBO.RequestStatus_Description1);
            cmd.Parameters.AddWithValue("@Status", objRequestBO.RequestStatus);
            cmd.Parameters.AddWithValue("@id", id);
            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public int Delete_Request(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select from Sub_RequestTable where Memberid="+id;
            SqlCommand cmd = new SqlCommand(query, con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
}