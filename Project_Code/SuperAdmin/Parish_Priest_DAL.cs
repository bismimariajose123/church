using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Parish_Priest_DAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int Insert_Priest_Information(Parish_Priest_BO objPriestDetails_BO)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Sup_PriestTable values(@PriestName,@Image,@Contact,@OrdinationDate,@Native_Place,@Designation,@Current_Parish_id)", con);
            try
            {
                cmd.Parameters.AddWithValue("@PriestName", objPriestDetails_BO.PPName);
                cmd.Parameters.AddWithValue("@Image", objPriestDetails_BO.PPImage);
                cmd.Parameters.AddWithValue("@Contact", objPriestDetails_BO.Contact);
                cmd.Parameters.AddWithValue("@OrdinationDate", objPriestDetails_BO.Ordination_Date);

                cmd.Parameters.AddWithValue("@Native_Place", objPriestDetails_BO.NativePlace);

                cmd.Parameters.AddWithValue("@Designation", objPriestDetails_BO.P_Designation);
                cmd.Parameters.AddWithValue("@Current_Parish_id",0);

                int Result = cmd.ExecuteNonQuery();
                con.Close();
                return Result;
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

        public DataTable Get_Search_Priest_NOT_Transfer_Details(string searchstr)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
           
            string query="select p.Parish_Priest_ID,p.Parish_Priest_Name,p.Parish_Priest_Image,p.Phone_No,p.OrdinationDate,p.Native_Place,p.Designation,pa.Parish_Name from Sup_PriestTable p left join Sup_ParishTable pa on p.Current_Parish_id = pa.Parish_ID where(p.Native_Place like '%"+searchstr+"%'  or p.Parish_Priest_Name like '%"+searchstr+"%') and p.Parish_Priest_ID not in (select Priest_Id from Sup_Priest_TransferTable) or pa.Parish_Name = p.Native_Place";
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable Get_Search_PriestInformation(string searchstr)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            //string query ="select p.Parish_Priest_ID,p.Parish_Priest_Name,p.Parish_Priest_Image,p.Phone_No," +
            //    "p.OrdinationDate,p.Native_Place,p.Designation,pa.Parish_Name from Sup_PriestTable p, Sup_ParishTable pa" +
            //    " where p.Current_Parish_id = pa.Parish_ID and p.Parish_Priest_Name like '%" + searchstr + "%' or p.Designation like '%" + searchstr + "%' or p.Native_Place like '%" + searchstr + "%'";

            //string query = "select * from Sup_PriestTable where Parish_Priest_Name like '%" +searchstr + "%'or Designation like '%" + searchstr + "%' or Native_Place like '%" + searchstr +"%'";

            string query = "select p.Parish_Priest_ID,p.Parish_Priest_Name,p.Native_Place,p.Designation," +
            "p.Phone_No,p.Parish_Priest_Image,p.OrdinationDate,pa.Parish_Name from Sup_PriestTable" +
            " p left join Sup_ParishTable pa on p.Current_Parish_id=pa.Parish_ID where p.Native_Place like '%"+searchstr+"%'" +
            " or p.Parish_Priest_Name like '%"+searchstr+"%'";


            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

      
        public int UpdatePriest(Parish_Priest_BO objPriestDetails_BO, int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            try { 
            SqlCommand Priestcmd = new SqlCommand("update Sup_PriestTable set Parish_Priest_Name=@PriestName,Phone_No=@Contact,OrdinationDate=@OrdinationDate," +
                "Native_Place=@Native_Place,Designation=@Designation where Parish_Priest_ID = @id", con);
            Priestcmd.Parameters.AddWithValue("@PriestName", objPriestDetails_BO.PPName);
            Priestcmd.Parameters.AddWithValue("@Contact", objPriestDetails_BO.Contact);
            Priestcmd.Parameters.AddWithValue("@OrdinationDate", objPriestDetails_BO.Ordination_Date);
            Priestcmd.Parameters.AddWithValue("@Native_Place", objPriestDetails_BO.NativePlace);
            Priestcmd.Parameters.AddWithValue("@Designation", objPriestDetails_BO.P_Designation);
            Priestcmd.Parameters.AddWithValue("@id", id);
            int priestResult = Priestcmd.ExecuteNonQuery();
            con.Close();
            return priestResult;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public int Delete_Priest_Information(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Sup_PriestTable  where Parish_Priest_ID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public DataTable Get_Priest_Information()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select p.Parish_Priest_ID,p.Parish_Priest_Name,p.OrdinationDate,p.Native_Place," +
                "p.Designation,p.Phone_No,p.Parish_Priest_Image,pa.Parish_Name from Sup_PriestTable p left join Sup_ParishTable pa" +
                " on p.Current_Parish_id = pa.Parish_ID; ", con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public DataTable GetPriest_NOT_Transfer_Details()
        {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
            
        SqlCommand cmd = new SqlCommand("select p.Parish_Priest_ID,p.Parish_Priest_Name,p.Parish_Priest_Image,p.Phone_No,p.OrdinationDate,p.Native_Place,p.Designation,pa.Parish_Name from Sup_PriestTable p left join Sup_ParishTable pa on p.Current_Parish_id = pa.Parish_ID where p.Parish_Priest_ID not in (select Priest_Id from Sup_Priest_TransferTable) or pa.Parish_Name = p.Native_Place", con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        return dt;    

        }
    }
}