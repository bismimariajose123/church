using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ExpenseBLL
    {
        ExpenseDAL objExpenseDAL = new ExpenseDAL();
        public int AddExpense(ExpenseBO objExpenseBO) //ADD EXPENSE TO TABLE(1)
        {
            return objExpenseDAL.AddExpense(objExpenseBO);
        }

        public DataTable DDl_EventName(ExpenseBO objExpenseBO) //LOAD DDL EVENT NAME (2)
        {
            return objExpenseDAL.DDl_EventName(objExpenseBO);
        }

        public DataTable LoadExpense(DateTime oDate, DateTime oDate1, int parishid, int eventid)
        {
            return objExpenseDAL.LoadExpense(oDate, oDate1, parishid, eventid);
        }

        public DataTable LoadExpense(int parishid, int eventid)
        {
            return objExpenseDAL.LoadExpense(parishid, eventid);
        }

        public string TotalExpense_Amount(DateTime oDate, DateTime oDate1, int parishid, int eventid)
        {
            return objExpenseDAL.TotalExpense_Amount(oDate, oDate1,parishid, eventid);
        
         }

        public string TotalExpense_Amount(int parishid, int eventid)
        {
            return objExpenseDAL.TotalExpense_Amount(parishid, eventid);
        }
    }
}