using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ExpenseDAL
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

        public int AddExpense(ExpenseBO objExpenseBO)  //ADD EXPENSE TO TABLE(1)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into ExpenseTable values(@Expense_Amount,@Parishid,@Exp_date,@From_Eventid,Reason)", con);

            cmd.Parameters.AddWithValue("@Expense_Amount", objExpenseBO.Expense_Amount1);
            cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
            cmd.Parameters.AddWithValue("@Exp_date", objExpenseBO.Exp_date1);
            cmd.Parameters.AddWithValue("@From_Eventid", objExpenseBO.Eventid1);
            cmd.Parameters.AddWithValue("@Reason", objExpenseBO.Reason1);
            int Result = cmd.ExecuteNonQuery();



            //ONCE AMOUNT IS ADDED ,   AMOUNT MUST BE DEDUCTED FROM THAT EVENT
            con.Close();
            return Result;
        }

        public DataTable DDl_EventName(ExpenseBO objExpenseBO) //LOAD DDL EVENT NAME (2)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select EventName,EventId from EventTable where Parishid=" + objExpenseBO.Parishid1;
              SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }
    }
}