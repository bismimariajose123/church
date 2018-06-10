using Diocese.Project_Code.SubAdmin;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
           // objExpenseBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());

            if (!IsPostBack)
            {
               
                Load_DDl_EventName();
            }
        }

        public void Load_DDl_EventName()  //LOAD DDL EVENT NAME  (2)
        {
            objExpenseBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());

            DataTable dt = new DataTable();
            dt = objExpenseBLL.DDl_EventName(objExpenseBO);
            if(dt.Rows.Count>0)
            {
            DDlExpenseEvent.DataSource = dt;                  //DDLExpenseEvent [AMOUNT TAKEN FROM]
                DDlExpenseEvent.DataTextField = "EventName";
            DDlExpenseEvent.DataValueField = "EventId";
            DDlExpenseEvent.DataBind();

            DDlExpReason.DataSource = dt;                     //DDLExpenseEvent [AMOUNT TAKEN FOR]
                DDlExpReason.DataTextField = "EventName";
            DDlExpReason.DataValueField = "EventId";
            DDlExpReason.DataBind();
            }

           
        }
        protected void BtnAddExpense_Click(object sender, EventArgs e)   //ADD EXPENSE TO TABLE (1)
        {

            objExpenseBO.Eventid1 = Convert.ToInt32(DDlExpReason.SelectedValue); //from event        
            objExpenseBO.Expense_Amount1 = Convert.ToInt64(TBExpAmount.Text);
            DateTime currdate= DateTime.Now;
            string h = currdate.ToString();
            DateTime i = Convert.ToDateTime(h.Substring(0, 9));
            objExpenseBO.Exp_date1 = i;
            objExpenseBO.Reason1 = TBReason.Text;
            objExpenseBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());


            int result = objExpenseBLL.AddExpense(objExpenseBO);
            if(result==0)
            {
                Response.Write("<script>alert('No sufficient amount')</script>");
            }
            else
            {
            Response.Redirect("SubAdminExpense.aspx");
            }
        }

        protected void BtnExpenseEventvalue_Click(object sender, EventArgs e)
        {

        }

        protected void Datesearch_Click(object sender, EventArgs e)
        {

        }

       

        protected void GVIncomeTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string date1 = Dobhidden.Value;
            string date2 = Dobhidden1.Value;
            int eventid = Convert.ToInt32(DDlExpenseEvent.SelectedValue);
            string eventname = DDlExpenseEvent.SelectedItem.ToString();
            Session["EventName"] = eventname;
            DataTable dt = new DataTable();
            if(eventid!=0)
            {
                if (date1 != "" && date2 != "")//all not null
                {
                    DateTime oDate = DateTime.Parse(date1);
                    DateTime oDate1 = DateTime.Parse(date2);
                    dt = objExpenseBLL.LoadExpense(oDate, oDate1, parishid, eventid);
                    LblTotalIncome.Text = objExpenseBLL.TotalExpense_Amount(oDate, oDate1, parishid, eventid);//total amount
                    LblTotalIncome.Visible = true;
                    LblTotalLabel.Visible = true;
                   
                }
                else if (date1 == "" && date2 == "") //only event search
                {
                    dt = objExpenseBLL.LoadExpense(parishid, eventid);
                    LblTotalIncome.Text = objExpenseBLL.TotalExpense_Amount(parishid, eventid);//total amount
                    LblTotalIncome.Visible = true;
                    LblTotalLabel.Visible = true;
                }
                if (dt.Rows.Count > 0)
                {


                    GVIncomeTable.Visible = true;
                    GVIncomeTable.DataSource = dt;
                    Session["Gv"] = dt;
                    GVIncomeTable.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");
                }

               
            }
           

        }

        protected void BtnConvertPdf_Click(object sender, EventArgs e)
        {

            PdfPTable pdfPTable1 = new PdfPTable(1);
            PdfPCell cell1 = new PdfPCell(new Phrase("Report for "+ Session["EventName"].ToString()));
            pdfPTable1.AddCell(cell1);

            PdfPTable pdfPTable = new PdfPTable(GVIncomeTable.HeaderRow.Cells.Count);
            foreach (TableCell headercell in GVIncomeTable.HeaderRow.Cells)
            {
                Font font = new Font();
                font.Color = new BaseColor(GVIncomeTable.HeaderStyle.ForeColor);

                PdfPCell pdfPCell = new PdfPCell(new Phrase(headercell.Text, font));
                pdfPCell.BackgroundColor= new BaseColor(GVIncomeTable.HeaderStyle.BackColor);
                pdfPTable.AddCell(pdfPCell);
            }

            foreach (GridViewRow gridViewRow in GVIncomeTable.Rows)
            {
                foreach (TableCell tableCell in gridViewRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GVIncomeTable.RowStyle.ForeColor);


                    PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                    pdfPTable.AddCell(pdfPCell);
                }
            }
            Document pdfDocument = new Document(PageSize.A4, 50f, 20f, 50f, 20f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
            pdfDocument.Open();
            pdfDocument.Add(pdfPTable1);
            pdfDocument.Add(pdfPTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Report.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();

            
        }
    }
}