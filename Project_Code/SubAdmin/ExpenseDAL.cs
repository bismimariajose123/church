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
            int Result = 0;
            int hsrow = 0;
            if (objExpenseBO.Eventid1 != 6)  //other than sunday collection
            {

                SqlCommand balch_cmd = new SqlCommand("select * from  BalanceTable where Eventid=" + objExpenseBO.Eventid1 + "and Parishid=" + objExpenseBO.Parishid1, con);
                SqlDataReader dr = balch_cmd.ExecuteReader();
                if (dr.HasRows) //sum(amount) from Balance table
                {
                    hsrow = 1;
                }
                else
                {
                    hsrow = 0;
                }
                dr.Close();
                if(hsrow == 1)//sum(amount) from Balance table
                { 
                    SqlCommand chechcmd = new SqlCommand("select sum(BalanceAmount) from BalanceTable where Eventid=" + objExpenseBO.Eventid1 + "and Parishid=" + objExpenseBO.Parishid1, con);
                    long T_amount = Convert.ToInt64(chechcmd.ExecuteScalar());

                    if (T_amount >= objExpenseBO.Expense_Amount1) //CHECK EXPENSE IS AFFORDABLE
                    {
                        SqlCommand cmd = new SqlCommand("insert into ExpenseTable values(@Expense_Amount,@Parishid,@Exp_date,@From_Eventid,@Reason)", con);

                        cmd.Parameters.AddWithValue("@Expense_Amount", objExpenseBO.Expense_Amount1);
                        cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        cmd.Parameters.AddWithValue("@Exp_date", objExpenseBO.Exp_date1);
                        cmd.Parameters.AddWithValue("@From_Eventid", objExpenseBO.Eventid1);
                        cmd.Parameters.AddWithValue("@Reason", objExpenseBO.Reason1);
                        Result = cmd.ExecuteNonQuery();

                        long Balance_Amount = T_amount - objExpenseBO.Expense_Amount1; //CHECH FIRST INSERT INTO BALANCE TABLE


                        //UPDATE BALANCE TABLE
                        SqlCommand update_balTable_cmd = new SqlCommand("update BalanceTable set BalanceAmount=@BalanceAmount where Eventid=@Eventid and Parishid=@Parishid", con);
                        update_balTable_cmd.Parameters.AddWithValue("@BalanceAmount", Balance_Amount);
                        update_balTable_cmd.Parameters.AddWithValue("@Eventid", objExpenseBO.Eventid1);
                        update_balTable_cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        int result = update_balTable_cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Result = 0;   //PRINT BALANCE IS LESS
                    }


                }

                else    //sum(amount) from Donation table
                {
                    SqlCommand chechcmd = new SqlCommand("select sum(Amount) from DonationTable1 where ToParishid=" + objExpenseBO.Parishid1 + " and EventName=" + objExpenseBO.Eventid1, con);

                    long T_amount = Convert.ToInt64(chechcmd.ExecuteScalar());
                    if (T_amount >= objExpenseBO.Expense_Amount1) //CHECK EXPENSE IS AFFORDABLE
                    {
                        SqlCommand cmd = new SqlCommand("insert into ExpenseTable values(@Expense_Amount,@Parishid,@Exp_date,@From_Eventid,@Reason)", con);

                        cmd.Parameters.AddWithValue("@Expense_Amount", objExpenseBO.Expense_Amount1);
                        cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        cmd.Parameters.AddWithValue("@Exp_date", objExpenseBO.Exp_date1);
                        cmd.Parameters.AddWithValue("@From_Eventid", objExpenseBO.Eventid1);
                        cmd.Parameters.AddWithValue("@Reason", objExpenseBO.Reason1);
                        Result = cmd.ExecuteNonQuery();

                        long Balance_Amount = T_amount - objExpenseBO.Expense_Amount1; //CHECH FIRST INSERT INTO BALANCE TABLE

                        //INSERT INTO BALANCE TABLE
                        SqlCommand cmd_insert_Bal_Table = new SqlCommand("insert into BalanceTable values(@BalanceAmount,@Eventid,@Parishid)", con);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@BalanceAmount", Balance_Amount);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@Eventid", objExpenseBO.Eventid1);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        int result = cmd_insert_Bal_Table.ExecuteNonQuery();
                    }


                    else
                    {
                        Result = 0;   //PRINT BALANCE IS LESS
                    }

                }
            }

            else   // if sunday collection
            {
                SqlCommand balch_cmd = new SqlCommand("select * from  BalanceTable where Eventid=" + objExpenseBO.Eventid1 + "and Parishid=" + objExpenseBO.Parishid1, con);
                SqlDataReader dr = balch_cmd.ExecuteReader();
                if (dr.HasRows) //sum(amount) from Balance table
                {
                    hsrow = 1;
                }
                else
                {
                    hsrow = 0;
                }

                dr.Close();
                if (hsrow == 1)//sum(amount) from Balance table
                {
                    SqlCommand chechcmd = new SqlCommand("select sum(BalanceAmount) from BalanceTable where Eventid=" + objExpenseBO.Eventid1 + "and Parishid=" + objExpenseBO.Parishid1, con);
                    long T_amount = Convert.ToInt64(chechcmd.ExecuteScalar());

                    if (T_amount >= objExpenseBO.Expense_Amount1) //CHECK EXPENSE IS AFFORDABLE
                    {
                        SqlCommand cmd = new SqlCommand("insert into ExpenseTable values(@Expense_Amount,@Parishid,@Exp_date,@From_Eventid,@Reason)", con);

                        cmd.Parameters.AddWithValue("@Expense_Amount", objExpenseBO.Expense_Amount1);
                        cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        cmd.Parameters.AddWithValue("@Exp_date", objExpenseBO.Exp_date1);
                        cmd.Parameters.AddWithValue("@From_Eventid", objExpenseBO.Eventid1);
                        cmd.Parameters.AddWithValue("@Reason", objExpenseBO.Reason1);
                        Result = cmd.ExecuteNonQuery();

                        long Balance_Amount = T_amount - objExpenseBO.Expense_Amount1; //CHECH FIRST INSERT INTO BALANCE TABLE


                        //UPDATE BALANCE TABLE
                        SqlCommand update_balTable_cmd = new SqlCommand("update BalanceTable set BalanceAmount=@BalanceAmount where Eventid=@Eventid and Parishid=@Parishid", con);
                        update_balTable_cmd.Parameters.AddWithValue("@BalanceAmount", Balance_Amount);
                        update_balTable_cmd.Parameters.AddWithValue("@Eventid", objExpenseBO.Eventid1);
                        update_balTable_cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        int result = update_balTable_cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        Result = 0;   //PRINT BALANCE IS LESS
                    }


                }
                else //sum(amount) from SundayCollection Table
                {
                    SqlCommand chechcmd = new SqlCommand("select sum(Amount) from SundayCollectionTable where Parishid=" + objExpenseBO.Parishid1, con);
                    long T_amount = Convert.ToInt64(chechcmd.ExecuteScalar());
                    if (T_amount >= objExpenseBO.Expense_Amount1) //CHECK EXPENSE IS AFFORDABLE
                    {
                        SqlCommand cmd = new SqlCommand("insert into ExpenseTable values(@Expense_Amount,@Parishid,@Exp_date,@From_Eventid,@Reason)", con);

                        cmd.Parameters.AddWithValue("@Expense_Amount", objExpenseBO.Expense_Amount1);
                        cmd.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        cmd.Parameters.AddWithValue("@Exp_date", objExpenseBO.Exp_date1);
                        cmd.Parameters.AddWithValue("@From_Eventid", objExpenseBO.Eventid1);
                        cmd.Parameters.AddWithValue("@Reason", objExpenseBO.Reason1);
                        Result = cmd.ExecuteNonQuery();

                        long Balance_Amount = T_amount - objExpenseBO.Expense_Amount1;

                        //INSERT INTO BALANCE TABLE
                        SqlCommand cmd_insert_Bal_Table = new SqlCommand("insert into BalanceTable values(@BalanceAmount,@Eventid,@Parishid)", con);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@BalanceAmount", Balance_Amount);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@Eventid", objExpenseBO.Eventid1);
                        cmd_insert_Bal_Table.Parameters.AddWithValue("@Parishid", objExpenseBO.Parishid1);
                        int result = cmd_insert_Bal_Table.ExecuteNonQuery();
                    }

                    else
                    {
                        Result = 0;   //PRINT BALANCE IS LESS
                    }

                }
               
            }
            con.Close();
            return Result;
        }

        public string TotalExpense_Amount(int parishid, int eventid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "select sum(Expense_Amount) from ExpenseTable where Parishid = " + parishid + "and From_Eventid=" + eventid;
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalExpenseAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalExpenseAmount;
        }

        public string TotalExpense_Amount(DateTime oDate, DateTime oDate1, int parishid, int eventid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string query = "select sum(Expense_Amount) from ExpenseTable where Parishid = " + parishid + "and From_Eventid=" + eventid + " and Exp_date between '"+ oDate +"' and '"+ oDate1 +"'"; 
            SqlCommand cmd = new SqlCommand(query, con);
            string TotalExpenseAmount = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return TotalExpenseAmount;
        }

        public DataTable LoadExpense(int parishid, int eventid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select ex.ExpenseId,ev.EventName,ex.Expense_Amount,ex.Reason,ex.Exp_date from EventTable ev join ExpenseTable ex on ev.EventId = ex.From_Eventid where ex.Parishid =" + parishid + " and ev.EventId=" + eventid;
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable LoadExpense(DateTime oDate, DateTime oDate1, int parishid, int eventid)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select ex.ExpenseId,ev.EventName,ex.Expense_Amount,ex.Reason,ex.Exp_date from EventTable ev join ExpenseTable ex on ev.EventId = ex.From_Eventid where ex.Parishid =" + parishid + " and ev.EventId=" + eventid + "and ex.Exp_date between '"+oDate+"' and '"+ oDate1+ "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            return dt;

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