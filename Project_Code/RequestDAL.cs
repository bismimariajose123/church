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
            string query = "select r.Event_Name,b.FamilyName,b.OfficialName,r.ProposedDateOfBap,r.ProposedTimeOfBap,r.Memberid,r.RequestStatus_Description,r.RequestStatus from Sub_RequestTable r left join BaptismTable b on r.Memberid = b.Memberid where r.Parishid=" + objRequestBO.Parishid1;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int UpdateMember_Request(RequestBO objRequestBO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sub_RequestTable set ProposedDateOfBap=@proposeddate,ProposedTimeOfBap=@proposedTime where Memberid = @id", con);
            cmd.Parameters.AddWithValue("@proposeddate", objRequestBO.ProposedDateOfBap1);
            cmd.Parameters.AddWithValue("@proposedTime", objRequestBO.ProposedTimeOfBap1);
            cmd.Parameters.AddWithValue("@id", id);
            int Result = cmd.ExecuteNonQuery();
            SqlCommand cmd_update_sts_desc = new SqlCommand("update Sub_RequestTable set RequestStatus_Description=@requestdesc,RequestStatus=@Status where Memberid = @id", con);
            cmd_update_sts_desc.Parameters.AddWithValue("@requestdesc", "");
            cmd_update_sts_desc.Parameters.AddWithValue("@Status",0);
            cmd_update_sts_desc.Parameters.AddWithValue("@id",id);
            int result = cmd_update_sts_desc.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public DataTable GeneratePdfBaptism(int memberid)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select BaptismName,OfficialName,FatherName,MotherName,DoBaptism,GFName,GMName,Vicar,Celebrant from BaptismTable where Memberid="+memberid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;

        }

        public int DownloadBaptismForm(int memberid)//Add function
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd_baptism_date = new SqlCommand("select ProposedDateOfBap from  Sub_RequestTable  where Memberid = @id", con);

            cmd_baptism_date.Parameters.AddWithValue("@id", memberid);
            string dobaptism = Convert.ToString(cmd_baptism_date.ExecuteScalar());


            SqlCommand cmd = new SqlCommand("update BaptismTable set BaptismStatus=@bapstatus,DoBaptism=@DoBap where Memberid = @id", con);
            cmd.Parameters.AddWithValue("@bapstatus",1);
            cmd.Parameters.AddWithValue("@DoBap",dobaptism);//in case updated........

            cmd.Parameters.AddWithValue("@id", memberid);
            int Result = cmd.ExecuteNonQuery();

            SqlCommand cmdbapid = new SqlCommand("select Baptism_id from BaptismTable where Memberid ="+memberid,con);//get bapid of member
            int bapid = Convert.ToInt32(cmdbapid.ExecuteScalar());

            SqlCommand cmd2 = new SqlCommand("update MemberDetailsTable set BaptismId=@bapid where Member_ID = @id", con);
            cmd2.Parameters.AddWithValue("@bapid",bapid);

            cmd2.Parameters.AddWithValue("@id", memberid);
            int result = cmd2.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand("update Sub_RequestTable set RequestStatus=@Status where Memberid = @id", con);
            cmd3.Parameters.AddWithValue("@Status",4);
           
            cmd3.Parameters.AddWithValue("@id", memberid);
            int res = cmd3.ExecuteNonQuery();

            con.Close();
            return Result;

        }

        //public int Delete_MemberRequest(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public DataTable GetMemberNotificationDetails(RequestBO objRequestBO)
        {

            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select r.Event_Name,b.FamilyName,b.OfficialName,r.ProposedDateOfBap,r.ProposedTimeOfBap,r.Memberid,r.RequestStatus_Description,r.RequestStatus from Sub_RequestTable r left join BaptismTable b on r.Memberid = b.Memberid where r.Parishid=" + objRequestBO.Parishid1;
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