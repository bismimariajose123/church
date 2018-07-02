using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class CommunionDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddCommunionRequest(CommunionBO objCommunionBO, int usertype, int parishid, int familyid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "insert into CommunionTable values(@FamilyName,@Memberid,@Parish_id,@ParishofCommumion,@OfficialName,@BaptismName,@Gender,@FName,@MName,@BlessedBy,@Parish_PriestName,@DO_communion,@Commu_status,@ParishMember,@PersonsParishName)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@FamilyName", objCommunionBO.FamilyName1);
           
            cmd.Parameters.AddWithValue("@Memberid", familyid);
           
           
            cmd.Parameters.AddWithValue("@Parish_id", parishid);
            cmd.Parameters.AddWithValue("@ParishofCommumion", objCommunionBO.ParishofCommumion1);
            cmd.Parameters.AddWithValue("@OfficialName", objCommunionBO.OfficialName1);
            cmd.Parameters.AddWithValue("@BaptismName", objCommunionBO.BaptismName1);
            cmd.Parameters.AddWithValue("@Gender", objCommunionBO.Gender1);
            cmd.Parameters.AddWithValue("@FName", objCommunionBO.FName1);
            cmd.Parameters.AddWithValue("@MName", objCommunionBO.MName1);
            cmd.Parameters.AddWithValue("@BlessedBy", objCommunionBO.BlessedBy1);
            cmd.Parameters.AddWithValue("@Parish_PriestName", objCommunionBO.Parish_PriestName1);

            cmd.Parameters.AddWithValue("@DO_communion", objCommunionBO.DO_communion1);
            cmd.Parameters.AddWithValue("@Commu_status", objCommunionBO.Commu_status1);
            cmd.Parameters.AddWithValue("@ParishMember", objCommunionBO.ParishMember1);
            cmd.Parameters.AddWithValue("@PersonsParishName", objCommunionBO.PersonsParishName1); 
            int a = cmd.ExecuteNonQuery();
            return a;
        }
    }
}