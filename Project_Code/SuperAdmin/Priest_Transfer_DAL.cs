using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Priest_Transfer_DAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public DataTable Priest_Parish_Ddlist()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select Parish_ID,Parish_Name from Sup_ParishTable";
            //string query = "select Parish_ID,[Parish_Name] + ', ' + [Place] as Creator from Sup_ParishTable";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public int Save_PreistTransfer_Details(Priest_TransferBO objPriestTransfer_BO, string designation)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand selectcmd = new SqlCommand("select Priest_Id from Sup_Priest_TransferTable where Priest_Id=@id", con);
            selectcmd.Parameters.AddWithValue("@id",objPriestTransfer_BO.PriestID);

            //SqlCommand selectcmd = new SqlCommand("select Priest_Id from Sup_Priest_TransferTable where Priest_Id="+ Convert.ToInt32(objPriestTransfer_BO.PriestID)+")", con);
            SqlDataReader dr1 = selectcmd.ExecuteReader();
            string i = string.Empty;

            if (dr1.HasRows)
            {
                dr1.Read();
                i = "1";
            }
            dr1.Close();
            SqlCommand insertcmd = new SqlCommand("insert into Sup_Priest_TransferTable values(@Priest_Id,@Parish_Id)", con);

            SqlCommand updateDesignationcmd = new SqlCommand("update Sup_PriestTable set Designation=@Designation,Current_Parish_id=@Current_Parish_id where Parish_Priest_ID = @id", con);

            //SqlCommand update_priestid_in_Sub_login = new SqlCommand("update Sup_SubAdminTable set Priest_Id=@priestid where Sub_Ad_Parish_id = @id", con);
            try
            {
               
                if(i == "1")//if priest id is in transfer table update Parish_Id in  "Sup_Priest_TransferTable" and update priest id in Sup_SubAdminTable
                {
                    SqlCommand updateTransfercmd = new SqlCommand("update Sup_Priest_TransferTable set Parish_Id=@Parish_Id where Priest_Id ="+ objPriestTransfer_BO.PriestID, con);
                    updateTransfercmd.Parameters.AddWithValue("@Parish_Id", objPriestTransfer_BO.ParishID);
                    int updateTransfer_result = updateTransfercmd.ExecuteNonQuery();

                    updateDesignationcmd.Parameters.AddWithValue("@Designation", designation);
                    updateDesignationcmd.Parameters.AddWithValue("@Current_Parish_id", objPriestTransfer_BO.ParishID);

                    updateDesignationcmd.Parameters.AddWithValue("@id", objPriestTransfer_BO.PriestID);
                    int update_result = updateDesignationcmd.ExecuteNonQuery();

                    //update_priestid_in_Sub_login.Parameters.AddWithValue("@priestid",objPriestTransfer_BO.PriestID);
                    //update_priestid_in_Sub_login.Parameters.AddWithValue("@id", objPriestTransfer_BO.ParishID);
                   // int update_result_login = update_priestid_in_Sub_login.ExecuteNonQuery();



                    con.Close();
                    return updateTransfer_result;
                }

                else { 
                    insertcmd.Parameters.AddWithValue("@Priest_Id", Convert.ToInt32(objPriestTransfer_BO.PriestID));
                    insertcmd.Parameters.AddWithValue("@Parish_Id", Convert.ToInt32(objPriestTransfer_BO.ParishID));
                    int Result = insertcmd.ExecuteNonQuery();

                    updateDesignationcmd.Parameters.AddWithValue("@Designation",designation);
                    updateDesignationcmd.Parameters.AddWithValue("@Current_Parish_id", objPriestTransfer_BO.ParishID);

                    updateDesignationcmd.Parameters.AddWithValue("@id", objPriestTransfer_BO.PriestID);
                    int update_result= updateDesignationcmd.ExecuteNonQuery();

                    //update_priestid_in_Sub_login.Parameters.AddWithValue("@priestid", objPriestTransfer_BO.PriestID);
                    //update_priestid_in_Sub_login.Parameters.AddWithValue("@id", objPriestTransfer_BO.ParishID);
                    //int update_result_login = update_priestid_in_Sub_login.ExecuteNonQuery();

                    con.Close();
                    return Result;
                }
               

            }

            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                insertcmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        
    }
}