using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class SubAdminExpense : System.Web.UI.Page
    {
        ExpenseBO objExpenseBO = new ExpenseBO();
        ExpenseBLL objExpenseBLL = new ExpenseBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objExpenseBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
            if(!IsPostBack)
            {
                Load_DDl_EventName();
            }
        }

        public void Load_DDl_EventName()  //LOAD DDL EVENT NAME (2)
        {

            DataTable dt = new DataTable();
            dt = objExpenseBLL.DDl_EventName(objExpenseBO);
            if(dt.Rows.Count>0)
            {
            DDlExpenseEvent.DataSource = dt;                  //DDLExpenseEvent
            DDlExpenseEvent.DataTextField = "EventName";
            DDlExpenseEvent.DataValueField = "EventId";
            DDlExpenseEvent.DataBind();

            DDlExpReason.DataSource = dt;                     //DDLExpenseEvent
            DDlExpReason.DataTextField = "EventName";
            DDlExpReason.DataValueField = "EventId";
            DDlExpReason.DataBind();
            }

            //else
            //{
            //    Response.Write("<script> alert('No event')</script>");
            //}
        }
        protected void BtnAddExpense_Click(object sender, EventArgs e)   //ADD EXPENSE TO TABLE (1)
        {

            objExpenseBO.Eventid1 = Convert.ToInt32(DDlExpReason.SelectedValue); //from event        
            objExpenseBO.Expense_Amount1 = Convert.ToInt32(TBExpAmount.Text);
            objExpenseBO.Exp_date1 = DateTime.Now;
            objExpenseBO.Reason1 = TBReason.Text;
            int result = objExpenseBLL.AddExpense(objExpenseBO);
            

        }

        protected void BtnExpenseEventvalue_Click(object sender, EventArgs e)
        {

        }

        protected void Datesearch_Click(object sender, EventArgs e)
        {

        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GVIncomeTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

       
    }
}