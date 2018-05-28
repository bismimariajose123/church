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
            SqlCommand cmd = new SqlCommand("insert into DonationTable values(@FamilyName,@Persons_ParishName,@OfficialName,@Gender,@ContactNo,@Diocese,@EventName,@ToParishid,@Memberid,@IsParishMember,@Amount,@AmountReceivedDate,@ispayed)", con);
           
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

        public DataTable Get_Search_IncomeDetails(string searchstr,int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+ parishid + " and d.FamilyName like '%" + searchstr + "%' or d.OfficialName like '%" + searchstr + "%' or d.EventName like '%" + searchstr + "%' or d.AmountReceivedDate like '%" + searchstr + "%'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Load_DonationIncome(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select d.DonationId,d.FamilyName,d.Persons_ParishName,d.OfficialName,d.ContactNo,d.Diocese,e.EventName,d.ToParishid,d.Memberid,d.IsParishMember,d.Amount,d.AmountReceivedDate from DonationTable d join EventTable e on e.EventId = d.EventName where d.ToParishid ="+ parishid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
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
            SqlCommand cmd = new SqlCommand("update DonationTable set ispayed="+1+" where IsParishMember="+user+ " and Memberid="+userid, con);
            int result = cmd.ExecuteNonQuery();
        }

        public DataTable LoadEvent(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select EventId,EventName from EventTable where Parishid="+parishid, con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;


        }
    }
}