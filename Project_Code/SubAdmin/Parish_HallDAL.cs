using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class Parish_HallDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public Parish_HallBO GetHallNo(Parish_HallBO objParish_HallBO)
        {
            int result = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmdcheck = new SqlCommand("select * from Sub_ParishHallTable where ParishId=" + objParish_HallBO.parishid, con);
            SqlDataReader dr1 = cmdcheck.ExecuteReader();
            if (dr1.HasRows)
            {
                dr1.Read();
                result = 1;
            }

            dr1.Close();

            if (result == 1)
            {
                SqlCommand cmdSelect = new SqlCommand("select max(HallNo) from Sub_ParishHallTable where ParishId=" + objParish_HallBO.parishid, con);
                int hallno = Convert.ToInt32(cmdSelect.ExecuteScalar());
                objParish_HallBO.hallno = hallno + 1;
            }
            else
            {
                objParish_HallBO.hallno = 1;
            }

            return objParish_HallBO;

        }

        public DataTable LoadEventName(Parish_HallBO objParish_HallBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select EventName,EventId from EventTable where Parishid=" + objParish_HallBO.parishid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public int UpdateIsPaid(Parish_HallBO objParish_HallBO)
        {
            int Result = 0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            try
            {

            
            SqlCommand cmd = new SqlCommand("update UserHallRequestTable set IsPaid=@IsPaid where UserType=@UserType and Userid=@Userid and Eventid=@Eventid and HallId=@HallId and Parishid=@Parishid", con);
            cmd.Parameters.AddWithValue("@IsPaid", objParish_HallBO.IsPaid1);
            cmd.Parameters.AddWithValue("@UserType", objParish_HallBO.Usertype);
            cmd.Parameters.AddWithValue("@Userid", objParish_HallBO.Userid);
            cmd.Parameters.AddWithValue("@Eventid", objParish_HallBO.Eventid1);
            cmd.Parameters.AddWithValue("@HallId", objParish_HallBO.Hallid1);
                cmd.Parameters.AddWithValue("@Parishid", objParish_HallBO.parishid);
                Result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            con.Close();
            return Result;
        }

        public DataTable LoadMemberNotification(int parishid, int userid,int usertype)
        {
            DataTable dt=new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select u.HallRequestId,u.Userid,u.UserType,e.EventName,h.HallName,h.No_of_people,h.Rate,u.RequestDate,u.Status,u.Description from EventTable e,Sub_ParishHallTable h,UserHallRequestTable u where e.EventId=u.Eventid and h.Hall_ID=u.HallId and u.Userid=" + userid+" and u.Parishid="+parishid+" and u.UserType="+usertype;
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            sda.Fill(dt);
            con.Close();
            return dt;


        }

        public int Delete_HallRequest(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from UserHallRequestTable where HallRequestId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public List<String> FillMemberDetails(int familyid, int usertype)
        {
            List<String> list = new List<String>();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query;
            if(usertype==3)
            {
                query = "select f.FamilyName,p.Parish_Name from Sub_Create_FamilyLoginTable f,Sup_ParishTable p where f.Family_ID=" + familyid + " and f.Parish_id=p.Parish_ID";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    list.Add(dr["FamilyName"].ToString());

                    list.Add(dr["Parish_Name"].ToString());
                   
                }
                dr.Close();
            }
         
            return list;
        }

        public DataTable SearchEvent(int parishid, int eventid, int userid, int usertype)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                String query = "select u.HallRequestId,u.Userid,u.UserType,e.EventName,h.HallName,h.No_of_people,h.Rate,u.RequestDate,u.Status,u.Description from EventTable e, Sub_ParishHallTable h,UserHallRequestTable u where e.EventId ="+eventid+" and h.Hall_ID = u.HallId and u.Userid =" + userid + " and u.Parishid =" + parishid + " and u.UserType =" + usertype;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Search(DateTime oDate, int parishid, int eventid,int userid,int usertype)
        {
            try { 
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select u.HallRequestId,u.Userid,u.UserType,e.EventName,h.HallName,h.No_of_people,h.Rate,u.RequestDate,u.Status,u.Description from EventTable e, Sub_ParishHallTable h,UserHallRequestTable u where e.EventId ="+eventid+" and h.Hall_ID = u.HallId and u.Userid =" + userid + " and u.Parishid =" + parishid + " and u.UserType =" + usertype + " and  u.RequestDate='" + oDate + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.Fill(dt);
            con.Close();
            return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateMember_Request(Parish_HallBO objParish_HallBO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update UserHallRequestTable set RequestDate=@RequestDate where HallRequestId = @id", con);
             cmd.Parameters.AddWithValue("@RequestDate", objParish_HallBO.RequestDate1);
             cmd.Parameters.AddWithValue("@id", id);

            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public int UpdateRequest(Parish_HallBO objParish_HallBO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update UserHallRequestTable set Status=@Status,Description=@requestdesc where HallRequestId = @id", con);
            cmd.Parameters.AddWithValue("@Status", objParish_HallBO.Status);
            cmd.Parameters.AddWithValue("@requestdesc", objParish_HallBO.Description);
            cmd.Parameters.AddWithValue("@id", id);
           
            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }

        public DataTable LoadGVRequest(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select r.HallRequestId,r.Userid,h.HallName,e.EventName,r.UserType,r.OfficialName,r.RequestDate,r.Status,r.Description,r.IsPaid from Sub_ParishHallTable h,EventTable e,UserHallRequestTable r where r.Eventid=e.EventId and r.HallId=h.Hall_ID and r.Parishid=" + parishid;
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public int AddHallRequest(Parish_HallBO objParish_HallBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "insert into UserHallRequestTable values(@UserType,@Userid,@Eventid,@HallId,@OfficialName,@RequestDate,@Parishid,@Status,@Description,@IsPaid)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@UserType", objParish_HallBO.Usertype);
            cmd.Parameters.AddWithValue("@Userid", objParish_HallBO.Userid);
            cmd.Parameters.AddWithValue("@Eventid", objParish_HallBO.Eventid1);
            cmd.Parameters.AddWithValue("@HallId", objParish_HallBO.Hallid1);
            cmd.Parameters.AddWithValue("@OfficialName", objParish_HallBO.OfficialName1);
            cmd.Parameters.AddWithValue("@RequestDate", objParish_HallBO.RequestDate1);
            cmd.Parameters.AddWithValue("@Parishid", objParish_HallBO.parishid);
            cmd.Parameters.AddWithValue("@Status", objParish_HallBO.Status);
            cmd.Parameters.AddWithValue("@Description", objParish_HallBO.Description);
            cmd.Parameters.AddWithValue("@IsPaid", objParish_HallBO.IsPaid1);


            int a = cmd.ExecuteNonQuery();
            con.Close();
            return a;
        }

        public Parish_HallBO GetParishHallDetails(int hallid)
        {
            Parish_HallBO objParish_HallBO = new Parish_HallBO();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sub_ParishHallTable where Hall_ID=" + hallid, con);

            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                dr.Read();
               
                objParish_HallBO.hallno = Convert.ToInt32(dr["HallNo"]);
                objParish_HallBO.rate = dr["Rate"].ToString();
                objParish_HallBO.People_count= Convert.ToInt32(dr["No_of_people"]);
            }
            dr.Close();
            con.Close();
            return objParish_HallBO;
        }

        public int UpdateParishHall(Parish_HallBO objParish_HallBO, int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("update Sub_ParishHallTable set HallName=@HallName,No_of_people=@No_of_people,Rate=@Rate where Hall_ID=@id", con);
            cmd.Parameters.AddWithValue("@HallName", objParish_HallBO.Hallname);
            cmd.Parameters.AddWithValue("@No_of_people", objParish_HallBO.People_count);
            cmd.Parameters.AddWithValue("@Rate", objParish_HallBO.rate);

            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public int Delete_ParishHall(int id)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Sub_ParishHallTable where Hall_ID=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

        public DataTable GetParishHallDetails(Parish_HallBO objParish_HallBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Sub_ParishHallTable where ParishId=@id", con);
            cmd.Parameters.AddWithValue("@id", objParish_HallBO.parishid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public int AddHall(Parish_HallBO objParish_HallBO)
        {
            int result;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sub_ParishHallTable values(@HallName,@ParishId,@HallNo,@No_of_people,@Booked_status,@Rate)", con);

            try
            {
                cmd.Parameters.AddWithValue("@HallName", objParish_HallBO.Hallname);
                cmd.Parameters.AddWithValue("@ParishId", objParish_HallBO.parishid);
                cmd.Parameters.AddWithValue("@HallNo", objParish_HallBO.hallno);
                cmd.Parameters.AddWithValue("@No_of_people", objParish_HallBO.People_count);
                cmd.Parameters.AddWithValue("@Booked_status", objParish_HallBO.BookesStatus);
                cmd.Parameters.AddWithValue("@Rate", objParish_HallBO.rate);
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
    }
}