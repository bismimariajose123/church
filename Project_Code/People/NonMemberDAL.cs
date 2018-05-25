using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class NonMemberDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int RegisterNonMemberDetails(NonMemberBO objNonMemberBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "insert into NonMemberLoginTable values(@Uname,@Pwd,@ContactNo,@Email,@To_Parishid,@Family_Name,@OfficialName,@Po,@Dob,@Landmark,@FName,@MName,@IsParishMember)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@Uname", objNonMemberBO.Uname1);
            cmd.Parameters.AddWithValue("@Pwd", objNonMemberBO.Pwd1);
            cmd.Parameters.AddWithValue("@ContactNo", objNonMemberBO.ContactNo1);
            cmd.Parameters.AddWithValue("@Email", objNonMemberBO.Email1);
            cmd.Parameters.AddWithValue("@To_Parishid", objNonMemberBO.To_Parishid1);
            cmd.Parameters.AddWithValue("@Family_Name", objNonMemberBO.Family_Name1);
            cmd.Parameters.AddWithValue("@OfficialName", objNonMemberBO.OfficialName1);
            cmd.Parameters.AddWithValue("@Po", objNonMemberBO.Po1);
            cmd.Parameters.AddWithValue("@Dob", objNonMemberBO.Dob1);
            cmd.Parameters.AddWithValue("@Landmark", objNonMemberBO.Landmark1);
            cmd.Parameters.AddWithValue("@FName", objNonMemberBO.FName1);
            cmd.Parameters.AddWithValue("@MName", objNonMemberBO.MName1);
            cmd.Parameters.AddWithValue("@IsParishMember", objNonMemberBO.IsParishMember1);
     
            int a = cmd.ExecuteNonQuery();
            return a;
        }
    }
}