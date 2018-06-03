using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.Accountant
{
   
    public class AccountantDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddSundayCollection(AccountantBO objAccountantBO)   //ADD SUNDAY COLLECTION TO COLLECTION_SUNDAY_TABLE

        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
           
            SqlCommand cmd = new SqlCommand("insert into SundayCollectionTable values(@Amount,@Parishid,@SundayCollectionDate)", con);

            cmd.Parameters.AddWithValue("@Amount", objAccountantBO.Amount1);
            cmd.Parameters.AddWithValue("@Parishid", objAccountantBO.Parishid1);
            cmd.Parameters.AddWithValue("@SundayCollectionDate", objAccountantBO.SundayCollectionDate1);
            
            int Result = cmd.ExecuteNonQuery();
            con.Close();
            return Result;
        }
    }
}