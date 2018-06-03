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
    }
}