using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class DeathDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        public int addDeathREcord(DeathBO objDeathBO)
        {

            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();

                string query = "insert into DeathTable values(@Member_id,@Parish_id,@OfficialName,@DO_Death,@Do_Funeral,@FuneralTime,@Gender)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Member_id", objDeathBO.Member_id1);
                cmd.Parameters.AddWithValue("@Parish_id", objDeathBO.Parish_id1);
                cmd.Parameters.AddWithValue("@OfficialName", objDeathBO.OfficialName1);
                cmd.Parameters.AddWithValue("@DO_Death", objDeathBO.DO_Death1);
                cmd.Parameters.AddWithValue("@Do_Funeral", objDeathBO.Do_Funeral1);
                cmd.Parameters.AddWithValue("@FuneralTime", objDeathBO.FuneralTime1);
                cmd.Parameters.AddWithValue("@Gender", objDeathBO.Gender1);
                int a = cmd.ExecuteNonQuery();
                return a;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Get_Search_DeathDetails(int parishid, string searchstr)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select f.FamilyName,m.OfficialName ,d.DO_Death,d.Do_Funeral,d.FuneralTime,d.Death_ID from MemberDetailsTable m,DeathTable d,Sub_Create_FamilyLoginTable f where f.Family_ID=m.Family_id and d.Member_id=m.Member_ID  and (d.Parish_id="+parishid+" and d.OfficialName like '%"+ searchstr + "%' or f.FamilyName like '%" + searchstr + "%') order by (d.DO_Death) desc";
            SqlCommand cmd = new SqlCommand(query, con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable GetDeathDetails(int parishid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            String query = "select f.FamilyName,m.OfficialName ,d.DO_Death,d.Do_Funeral,d.FuneralTime,d.Death_ID from MemberDetailsTable m,DeathTable d,Sub_Create_FamilyLoginTable f where f.Family_ID=m.Family_id and d.Member_id=m.Member_ID  and d.Parish_id=" + parishid + "order by (d.DO_Death) desc";
            SqlCommand cmd = new SqlCommand(query, con);
            
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            
        }
    }
}