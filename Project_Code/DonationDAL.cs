using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class DonationDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        
        public int DonationAmount(DonationBO objDonationBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into DonationTable1 values(@FamilyName,@Persons_ParishName,@OfficialName,@Gender,@ContactNo,@Diocese,@EventName,@ToParishid,@Memberid,@IsParishMember,@Amount,@AmountReceivedDate,@ispayed)", con);
           
                cmd.Parameters.AddWithValue("@FamilyName", objDonationBO.FamilyName1);
                cmd.Parameters.AddWithValue("@Persons_ParishName", objDonationBO.Persons_ParishName1);
                cmd.Parameters.AddWithValue("@OfficialName", objDonationBO.OfficialName1);
                cmd.Parameters.AddWithValue("@Gender", objDonationBO.Gender1);
                cmd.Parameters.AddWithValue("@ContactNo", objDonationBO.ContactNo1);
                cmd.Parameters.AddWithValue("@Diocese", objDonationBO.Diocese1);
                cmd.Parameters.AddWithValue("@EventName", objDonationBO.EventName1);
                cmd.Parameters.AddWithValue("@ToParishid", objDonationBO.ToParishid1);

                cmd.Parameters.AddWithValue("@Memberid", objDonationBO.Memberid1);
                cmd.Parameters.AddWithValue("@IsParishMember", objDonationBO.IsParishMember1);
                cmd.Parameters.AddWithValue("@Amount", objDonationBO.Amount1);
                cmd.Parameters.AddWithValue("@AmountReceivedDate", objDonationBO.AmountReceivedDate1);
            cmd.Parameters.AddWithValue("@ispayed",0);

            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return  Result;
            }

        public string DisplayTwoDatesBased_TotalAmount(int parishid, DateTime date1, DateTime date2) //date1+date2+parishid (3a)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and AmountReceivedDate between '"+date1 +"' and '"+ date2+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalAmount;
        }

        public string Search_Event(int parishid, int eventid)  //return total amount based on Event Name
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and EventName="+ eventid;
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalAmount;
        }

        public string Get_Search_TotalAmount(string searchstr, int parishid)
        {
            string TotalAmount = string.Empty;
           
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            if (searchstr == "Sunday Collection")
            {

                string query = "select sum(Amount) from SundayCollectionTable where Parishid=" + parishid;
                SqlCommand cmd = new SqlCommand(query, con);
                TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            }
            else
            {

            
            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and OfficialName like '%" + searchstr+ "%' or FamilyName like '%" + searchstr + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
             TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            }
            con.Close();
            return TotalAmount;
        }

        public DataTable Load_DonationIncome_Twodate_EventName(DateTime oDate, DateTime oDate1, int parishid, int eventid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            if (eventid == 6)
            {
                string query = "select Collection_SundayId,Amount,SundayCollectionDate from SundayCollectionTable where Parishid = " + parishid + " and SundayCollectionDate between '" + oDate + "' and '" + oDate1 + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            else
            {

          
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d  join EventTable e  on e.EventId = d.EventName  where  d.ToParishid = " + parishid + " and  d.EventName=" + eventid+ " and d.AmountReceivedDate between '" + oDate + "' and '" + oDate1 + "'";
            // string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+parishid+" 
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            }
            con.Close();
            return dt;
        }

        public string DisplayTwoDatesBasedEventName_TotalAmount(int parishid, DateTime oDate, DateTime oDate1, int eventid)
        {
            string TotalAmount = string.Empty;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            if(eventid!=6)
            { 
            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and AmountReceivedDate between '" + oDate + "' and '" + oDate1 + "' and EventName="+eventid;
            SqlCommand cmd = new SqlCommand(query, con);
            TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            }
            else if (eventid == 6)  //sunday collection
            {
                string query = "select sum(Amount) from SundayCollectionTable where Parishid = " + parishid + " and SundayCollectionDate between '" + oDate + "' and '" + oDate1 + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                TotalAmount = Convert.ToString(cmd.ExecuteScalar());

            }

            con.Close();
            return TotalAmount;
        }

        public DataTable LoadEvent_search(int parishid, int eventid)// display in gv based on event name
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d  join EventTable e  on e.EventId = d.EventName  where  d.ToParishid = " + parishid + " and  d.EventName=" + eventid;
            // string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+parishid+" and AmountReceivedDate between '"+date1+"' and '"+date2+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Load_DonationIncome_Two_date_string(DateTime date1, DateTime date2, int parishid, string searchstr) //string+date1+date2+parishid (1b)
        {
             SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
             string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d  join EventTable e  on e.EventId = d.EventName  where d.OfficialName like '%"+searchstr+ "%' and d.ToParishid = " + parishid + " and d.AmountReceivedDate like '%" + date1 + "%' or d.AmountReceivedDate like '%" + date2 + "%'";
            // string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+parishid+" and AmountReceivedDate between '"+date1+"' and '"+date2+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public string DisplayTwoDatesBasedString_TotalAmount(int parishid, DateTime date1, DateTime date2, string searchstr)  //string+date1+date2+parishid (1a)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and OfficialName like '%" + searchstr + "%'  and AmountReceivedDate between '" + date1 + "' and '" + date2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalAmount;
        }

        public string DisplaySearchedString_TotalAmount(int parishid, DateTime date1) //date1+parishid (2b)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid + " and AmountReceivedDate like '%" + date1 + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalAmount;
        }

        public string Display_TotalAmount(int parishid)  //displaytotal amount whereparidh id=parishid
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select sum(Amount) from DonationTable1 where ToParishid = " + parishid;
            SqlCommand cmd = new SqlCommand(query,con);
            string TotalAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalAmount;
        }

        public DataTable Load_DonationIncome_TwoDate(DateTime date1, DateTime date2, int parishid) //date1+date2+parishid (3a)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+ parishid + " and d.AmountReceivedDate between '" + date1 + "' and '" + date2 + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Load_DonationIncome_Onedate1(DateTime date1, int parishid)  //date1parishid (2a)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d join EventTable e on e.EventId = d.EventName where d.ToParishid =" + parishid + " and  d.AmountReceivedDate like '%" + date1 + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable Get_Search_IncomeDetails(string searchstr,int parishid)  //search based on string
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            if(searchstr== "Sunday Collection")
            {
                
                 string query = "select Collection_SundayId,Amount,SundayCollectionDate from SundayCollectionTable where Parishid=" + parishid;

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
               
                sda.Fill(dt);
            }
            else {
                string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d join EventTable e on e.EventId = d.EventName where d.ToParishid =" + parishid + " and d.FamilyName like '%" + searchstr + "%' or d.OfficialName like '%" + searchstr + "%' or d.EventName like '%" + searchstr + "%'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
               
                sda.Fill(dt);
            }
            con.Close();
            return dt;
        }

        public DataTable Load_DonationIncome(int parishid) //Load into Gridview first time
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable1 d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+ parishid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;

        }

        public void Update_ispayed_inDonation(int userid, int usertype)
        {
            int user=0;
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            if(usertype==3)
            {
                user = 1;
            }
            else
            {
                user = 0;
            }
            SqlCommand cmd = new SqlCommand("update DonationTable1 set ispayed="+1+" where IsParishMember="+user+ " and Memberid="+userid, con);
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable LoadEvent(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select EventId,EventName from EventTable where Parishid="+parishid, con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;


        }
    }
}