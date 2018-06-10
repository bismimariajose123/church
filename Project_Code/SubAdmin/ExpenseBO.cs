using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ExpenseBO
    {
        private int ExpenseId;
        private long Expense_Amount;
        private int Parishid;
        private DateTime Exp_date;
        private int From_Eventid;
        private string Reason;

        public int ExpenseId1 { get => ExpenseId; set => ExpenseId = value; }
        public long Expense_Amount1 { get => Expense_Amount; set => Expense_Amount = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public DateTime Exp_date1 { get => Exp_date; set => Exp_date = value; }
        public int Eventid1 { get => From_Eventid; set => From_Eventid = value; }
        public string Reason1 { get => Reason; set => Reason = value; }
    }
}