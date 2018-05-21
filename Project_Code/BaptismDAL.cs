using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class BaptismDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public BaptismBO Load_MemberData(BaptismBO objBaptismBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from MemberDetailsTable where Parish_id=@parishid and Member_ID=@memberid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@parishid", objBaptismBO.To_Parish_id);
            cmd.Parameters.AddWithValue("@memberid", objBaptismBO.Member_id);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                objBaptismBO.Familyname = dr["NativeFamilyName"].ToString();
                objBaptismBO.PersonParishname = dr["NativeParishName"].ToString();
                objBaptismBO.Officialname= dr["OfficialName"].ToString();
                objBaptismBO.Baptismname = dr["BaptismName"].ToString();
                objBaptismBO.Fathername = dr["FatherName"].ToString();
                objBaptismBO.Mothername = dr["MotherName"].ToString();
                objBaptismBO.isParishMember = Convert.ToInt32(dr["ParishMember"].ToString());
              

            }
            return objBaptismBO;
        }

        public DataTable GEt_BapDetails(int id)
        {
           
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from BaptismTable where Memberid=@memberid";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@memberid",id);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.HasRows)
            //{
            //    dr.Read();
            //    objBaptismBO.Familyname = dr["NativeFamilyName"].ToString();
            //    objBaptismBO.PersonParishname = dr["NativeParishName"].ToString();
            //    objBaptismBO.Officialname = dr["OfficialName"].ToString();
            //    objBaptismBO.Baptismname = dr["BaptismName"].ToString();
            //    objBaptismBO.Fathername = dr["FatherName"].ToString();
            //    objBaptismBO.Mothername = dr["MotherName"].ToString();
            //    objBaptismBO.Do_Baptism = dr["DoBaptism"].ToString();
            //    objBaptismBO.GodFatherName = dr["GFName"].ToString();
            //    objBaptismBO.GodMotherName = dr["GMName"].ToString();
            //    objBaptismBO.vicar = dr["Vicar"].ToString();
            //    objBaptismBO.celebrant = dr["Celebrant"].ToString();

            //    objBaptismBO.GFatherProof = dr["GFProof"].ToString();
            //    objBaptismBO.GMotherProof = dr["GMProof"].ToString();
            //    objBaptismBO.FatherProof = dr["FProof"].ToString();
            //    objBaptismBO.MotherProof = dr["MProof"].ToString();
            //    objBaptismBO.Ur_BapProof = dr["UrBapProof"].ToString();



            //}
            //dt = objBaptismBO;
            

        }

        public int BaptismRequest(RequestBO objRequestBO)
        {
            
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "insert into Sub_RequestTable values(@Event_Name,@Memberid,@RequestStatus,@RequestDate,@RequestTime,@RequestStatus_Description,@Parishid,@ProposedDateOfBap,@ProposedTimeOfBap)";
            SqlCommand cmd = new SqlCommand(query1, con);
            cmd.Parameters.AddWithValue("@Event_Name", objRequestBO.Event_Name1);
            cmd.Parameters.AddWithValue("@Memberid", objRequestBO.Memberid1);
            cmd.Parameters.AddWithValue("@RequestStatus", objRequestBO.RequestStatus);
            cmd.Parameters.AddWithValue("@RequestDate", objRequestBO.RequestDate1);
            cmd.Parameters.AddWithValue("@RequestTime", objRequestBO.RequestTime1);
            cmd.Parameters.AddWithValue("@RequestStatus_Description", objRequestBO.RequestStatus_Description1);
            cmd.Parameters.AddWithValue("@Parishid", objRequestBO.Parishid1);
            cmd.Parameters.AddWithValue("@ProposedDateOfBap",objRequestBO.ProposedDateOfBap1);
            cmd.Parameters.AddWithValue("@ProposedTimeOfBap", objRequestBO.ProposedTimeOfBap1);
             int a = cmd.ExecuteNonQuery();
            return a;
        }

        public int Update_bapid_MemberDetails(BaptismBO objBaptismBO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query1 = "select Baptism_id from BaptismTable where Memberid=@membid";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.AddWithValue("@membid", objBaptismBO.Member_id);
            objBaptismBO.Baptismid = Convert.ToInt32(cmd1.ExecuteScalar());

            string query2 = "update MemberDetailsTable set BaptismId=@bapid where Parish_id=@parishid and Member_ID=@memberid";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd2.Parameters.AddWithValue("@bapid",objBaptismBO.Baptismid);
            cmd2.Parameters.AddWithValue("@parishid", objBaptismBO.To_Parish_id);
            cmd2.Parameters.AddWithValue("@memberid", objBaptismBO.Member_id);
            int a = cmd2.ExecuteNonQuery();
            con.Close();
            return a;
        }

        public int InsertBaptism_details(BaptismBO objBaptismBO) //member and married
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into BaptismTable values(@BaptismName,@OfficialName,@PersonParishName,@FamilyName," +
                "@FatherName,@MotherName,@Father_Bap_Name,@Mother_Bap_Name,@DoBaptism,@GFName,@GMName,@GFProof,@GMProof,@FProof,@MProof,@ToParish_id," +
                "@Gender,@Vicar,@Celebrant,@ParishMember,@Memberid,@BaptismStatus,@UrBapProof)", con);
            try
            {
                cmd.Parameters.AddWithValue("@BaptismName", objBaptismBO.Baptismname);
                cmd.Parameters.AddWithValue("@OfficialName", objBaptismBO.Officialname);
                cmd.Parameters.AddWithValue("@PersonParishName", objBaptismBO.PersonParishname);
                cmd.Parameters.AddWithValue("@FamilyName", objBaptismBO.Familyname);

                cmd.Parameters.AddWithValue("@FatherName", objBaptismBO.Fathername);
                cmd.Parameters.AddWithValue("@MotherName", objBaptismBO.Mothername);
                cmd.Parameters.AddWithValue("@Father_Bap_Name", objBaptismBO.Father_BapName);
                cmd.Parameters.AddWithValue("@Mother_Bap_Name", objBaptismBO.Mothername);


                cmd.Parameters.AddWithValue("@DoBaptism", objBaptismBO.Do_Baptism);
                cmd.Parameters.AddWithValue("@GFName", objBaptismBO.GodFatherName);
                cmd.Parameters.AddWithValue("@GMName", objBaptismBO.GodMotherName);
                cmd.Parameters.AddWithValue("@GFProof", objBaptismBO.GFatherProof);

                cmd.Parameters.AddWithValue("@GMProof", objBaptismBO.GMotherProof);
                cmd.Parameters.AddWithValue("@FProof", objBaptismBO.FatherProof);
                cmd.Parameters.AddWithValue("@MProof", objBaptismBO.MotherProof);
                cmd.Parameters.AddWithValue("@ToParish_id", objBaptismBO.To_Parish_id);


                cmd.Parameters.AddWithValue("@Gender", objBaptismBO.gender);

                cmd.Parameters.AddWithValue("@Vicar", objBaptismBO.vicar);
                cmd.Parameters.AddWithValue("@Celebrant", objBaptismBO.celebrant);
                cmd.Parameters.AddWithValue("@ParishMember", objBaptismBO.isParishMember);
                cmd.Parameters.AddWithValue("@Memberid", objBaptismBO.Member_id);
                cmd.Parameters.AddWithValue("@BaptismStatus", objBaptismBO.Baptism_Status);
                cmd.Parameters.AddWithValue("@UrBapProof", objBaptismBO.Ur_BapProof);

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
    }
}