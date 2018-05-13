using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class MemberDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int InsertMemberDetails(MemberBO objMemberRegisterBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into MemberDetailsTable values(@Parish_id,@Family_id,@Relation_id,@OfficialName," +
                "@BaptismName,@ContactNo,@Occupation,@Email,@DOB,@Landmark,@FatherName,@MotherName,@MarriesStatus,@ParishMember,@PO,@ImagePath," +
                "@WifesOfficialName,@WifesBapName,@BaptismId,@Marriageid,@RegisteredStatus,@NativeParishName,@NativeFamilyName)", con);
            try
            {
                cmd.Parameters.AddWithValue("@Parish_id", objMemberRegisterBO.Parishid);
                cmd.Parameters.AddWithValue("@Family_id", objMemberRegisterBO.Familyid);
                cmd.Parameters.AddWithValue("@Relation_id", objMemberRegisterBO.Relationid);
                cmd.Parameters.AddWithValue("@OfficialName", objMemberRegisterBO.Officialname);

                cmd.Parameters.AddWithValue("@BaptismName", objMemberRegisterBO.Baptismname);
                cmd.Parameters.AddWithValue("@ContactNo", objMemberRegisterBO.Contactno);
                cmd.Parameters.AddWithValue("@Occupation", objMemberRegisterBO.occupation);
                cmd.Parameters.AddWithValue("@Email", objMemberRegisterBO.email);


                cmd.Parameters.AddWithValue("@DOB", objMemberRegisterBO.dob);
                cmd.Parameters.AddWithValue("@Landmark", objMemberRegisterBO.landmark);
                cmd.Parameters.AddWithValue("@FatherName", objMemberRegisterBO.Fathername);
                cmd.Parameters.AddWithValue("@MotherName", objMemberRegisterBO.Mothername);

                cmd.Parameters.AddWithValue("@MarriesStatus", objMemberRegisterBO.Marriedstatus);
                cmd.Parameters.AddWithValue("@ParishMember", objMemberRegisterBO.Parishmember);
                cmd.Parameters.AddWithValue("@PO", objMemberRegisterBO.po);
                cmd.Parameters.AddWithValue("@ImagePath", objMemberRegisterBO.Imagepath);


                cmd.Parameters.AddWithValue("@WifesOfficialName", objMemberRegisterBO.WifesOfficialname);

                cmd.Parameters.AddWithValue("@WifesBapName", objMemberRegisterBO.WifesBapname);
                cmd.Parameters.AddWithValue("@BaptismId", objMemberRegisterBO.Baptism_id);
                cmd.Parameters.AddWithValue("@Marriageid", objMemberRegisterBO.Marriage_id);
                cmd.Parameters.AddWithValue("@RegisteredStatus", objMemberRegisterBO.Registered_Status);
                cmd.Parameters.AddWithValue("@NativeParishName", objMemberRegisterBO.NativeParishName);
                cmd.Parameters.AddWithValue("@NativeFamilyName", objMemberRegisterBO.FamilyName);

                int a = cmd.ExecuteNonQuery();
                con.Close();
                return a;
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
        }

        //public MemberBO GetStatus(MemberBO objMemberRegisterBO)
        //{
        //    SqlConnection con = new SqlConnection(ConnectionString);
        //    con.Open();
        //   string query = "select MarriesStatus,BaptismId,Marriageid,RegisteredStatus from MemberDetailsTable where Parish_id=" + objMemberRegisterBO.Parishid + " and Family_id=" + objMemberRegisterBO.Familyid;

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if(dr.HasRows)
        //    {
        //        dr.Read();
        //        objMemberRegisterBO.Marriedstatus= Convert.ToInt32(dr["MarriesStatus"].ToString());
        //        objMemberRegisterBO.Baptism_id = Convert.ToInt32(dr["BaptismId"].ToString());
        //        objMemberRegisterBO.Marriage_id= Convert.ToInt32(dr["Marriageid"].ToString());
        //        objMemberRegisterBO.Registered_Status= Convert.ToInt32(dr["RegisteredStatus"].ToString());
            
        //    }
        //    dr.Close();

        //    return objMemberRegisterBO;
        //}

        public DataTable Get_Search_MemberDetails(string searchstr,MemberBO objMemberRegisterBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from MemberDetailsTable where OfficialName like '%" + searchstr + "%'or BaptismName like '%" + searchstr + "%' and Parish_id="+ objMemberRegisterBO.Parishid +" and Family_id="+ objMemberRegisterBO.Familyid;

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Get_Member_Details(MemberBO objMemberRegisterBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from MemberDetailsTable where Parish_id="+ objMemberRegisterBO.Parishid+" and Family_id="+objMemberRegisterBO.Familyid, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public MemberBO Load_MemberData(MemberBO objMemberRegisterBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from Sub_Create_FamilyLoginTable where Family_ID=@familyid and Parish_id=@parishid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@familyid", objMemberRegisterBO.Familyid);
            cmd.Parameters.AddWithValue("@parishid", objMemberRegisterBO.Parishid);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objMemberRegisterBO.FamilyName = dr["FamilyName"].ToString();


            }
            return objMemberRegisterBO;
        }
    }
}