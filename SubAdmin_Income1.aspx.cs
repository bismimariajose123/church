using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Diocese.Project_Code;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class SubAdmin_Income1 : System.Web.UI.Page
    {
        DonationBLL objDonationBLL = new DonationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            if (!IsPostBack)
            {

                if (Session["AdminName"] == null)
                {
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    LBLsubadminname.Text = Session["AdminName"].ToString();
                }
                LoadEventDDl();
            }

        }

        public void LoadEventDDl()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());

            DataTable dt = objDonationBLL.LoadEventDDl(parishid);
            if(dt.Rows.Count>0)
            {
                DDleventid.DataSource = dt;
                DDleventid.DataTextField = "EventName";
                DDleventid.DataValueField = "EventId";
                DDleventid.DataBind();
            }
            else
            {
                Response.Write("<script>alert('event not yet added');</script>");
            }
           
        }

        public void Load_DonationIncome() //Load donation details to gv first
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objDonationBLL.Load_DonationIncome(parishid);
            Session["Datatable"] = dt;
            if(dt.Rows.Count>0)
            {
                LblTotalIncome.Text = objDonationBLL.Display_TotalAmount(parishid);  //display total amount

                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
            }
            else
            {
                Response.Write("<script>alert('event not yet added');</script>");
            }
           

        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)  //IMAGEBTN SEARCH
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text.Trim().ToLower().Replace("'", "''");
            if (!searchstr.Equals(""))
            {
                string date1 = Dobhidden.Value;
                string date2 = Dobhidden1.Value;

                LblTotalAmt.Visible = true;
                DataTable dt = new DataTable();

                dt = objDonationBLL.Get_Search_Str(searchstr, parishid);


                if (dt.Rows.Count > 0)
                {
                    LblTotalAmt.Visible = false;
                    LblTotalIncome.Visible = false;
                    GVIncomeTable.Visible = true;
                    GVIncomeTable.DataSource = dt;
                    GVIncomeTable.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search does not exists');</script>");
                    Response.Redirect("SubAdimn_Income.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('enter family name or official name in textbox for search');</script>");
                Response.Redirect("SubAdimn_Income.aspx");
            }

        }



        


        protected void BTN_Search_Click(object sender, EventArgs e)   //BTN SEARCH(A)
        {
            DataTable dt = new DataTable();

            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            string date1 = Dobhidden.Value;
            string date2 = Dobhidden1.Value;
            int eventid = Convert.ToInt32(DDleventid.SelectedValue);
            string eventName = Convert.ToString(DDleventid.SelectedItem);
            Session["EventName"] = eventName;
            Session["Eventid"] = eventid;
            if (!eventName.Equals("Sunday Collection"))   //not sunday collection
            {
                GVSundayCollection.Visible = false;
                LblSunday.Visible = false;
                LabelTotal.Visible = false;
                EventNameSundaycollection.Visible = false;

                if (searchstr == "" && date1 != "" && date2 != "")    //event+date1+date2
                {
                    DateTime oDate = DateTime.Parse(date1);
                    //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                    DateTime oDate1 = DateTime.Parse(date2);
                    //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011

                    String totalamount = objDonationBLL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid, eventName);
                    if (totalamount.Equals(""))
                    {
                        Dobhidden.Value = "";
                        Dobhidden1.Value = "";
                        LblSunday.Visible = false;
                        LabelTotal.Visible = false;
                    }
                    else
                    {
                        LblTotalAmt.Visible = true;
                        LblTotalIncome.Visible = true;
                        LblTotalIncome.Text = totalamount;
                        dt = objDonationBLL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid, eventName);
                    }

                }

                else if (searchstr == "" && date1 == "" && date2 == "")  //only EVENT NAME SEARCH
                {

                    String totalamount = objDonationBLL.Search_Event(parishid, eventid, eventName);//total amount
                    if (totalamount.Equals(""))
                    {
                        Dobhidden.Value = "";
                        Dobhidden1.Value = "";
                        LblSunday.Visible = false;
                        LabelTotal.Visible = false;
                       
                    }
                    else
                    {

                        LblTotalAmt.Visible = true;
                        LblTotalIncome.Visible = true;
                        LblTotalIncome.Text = totalamount;
                        dt = objDonationBLL.LoadEvent_search(parishid, eventid);//load into gv donation
                    }

                }

                if (dt.Rows.Count > 0)
                {


                    GVIncomeTable.Visible = true;
                    GVIncomeTable.DataSource = dt;
                    GVIncomeTable.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('your searched element does not exist');</script>");
                }

            }




            else    //goto sunday collection
            {
                GVIncomeTable.Visible = false;
                LblTotalAmt.Visible = false;
                LblTotalIncome.Visible = false;
                if (searchstr == "" && date1 != "" && date2 != "")    //event+date1+date2
                {
                    DateTime oDate = DateTime.Parse(date1);
                    //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                    DateTime oDate1 = DateTime.Parse(date2);
                    //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011


                    String totalamount = objDonationBLL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid, eventName);
                    if (totalamount.Equals(""))
                    {
                        Dobhidden.Value = "";
                        Dobhidden1.Value = "";

                        LblSunday.Visible = false;
                        LabelTotal.Visible = false;
                       

                    }
                    else
                    {
                        LblSunday.Visible = true;
                        LabelTotal.Visible = true;
                        LblSunday.Text = totalamount;
                        dt = objDonationBLL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid, eventName);

                    }

                }
                //else if(searchstr != "" && date1 != "" && date2 != "") //string+event+date1+date2
                //{
                //    DateTime oDate = DateTime.Parse(date1);
                //    //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                //    DateTime oDate1 = DateTime.Parse(date2);
                //    //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011

                //    //
                //}
                else if (searchstr == "" && date1 == "" && date2 == "") //only EVENT NAME SEARCH
                {
                    dt = objDonationBLL.Get_Search_IncomeDetails(eventName, parishid);
                    EventNameSundaycollection.Visible = true;


                    String totalamount = objDonationBLL.Get_Search_TotalAmount(eventName, parishid);
                    if (totalamount.Equals(""))
                    {
                        Dobhidden.Value = "";
                        Dobhidden1.Value = "";
                        
                    }
                    else
                    {
                        LblSunday.Visible = true;
                        LabelTotal.Visible = true;
                        LblSunday.Text = totalamount;
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    Dobhidden.Value = "";
                    Dobhidden1.Value = "";

                    GVSundayCollection.Visible = true;
                    GVSundayCollection.DataSource = dt;
                    GVSundayCollection.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('your searched element does not exist');</script>");
                }
            }

        }

        protected void BtnConvertPdf_Click(object sender, EventArgs e)
        {

            string eventName = Session["EventName"].ToString();
            int eventid = Convert.ToInt16(Session["Eventid"]);
            if (eventName.Equals("Sunday Collection"))
            {
                PdfPTable pdfPTable1 = new PdfPTable(1);
                PdfPCell cell1 = new PdfPCell(new Phrase("Report for " + Session["EventName"].ToString()));
                PdfPCell cell2 = new PdfPCell(new Phrase("Parish name " + Session["Parishname"].ToString()));

                pdfPTable1.AddCell(cell1);
                pdfPTable1.AddCell(cell2);
                PdfPTable pdfPTable = new PdfPTable(GVSundayCollection.HeaderRow.Cells.Count);
                foreach (TableCell headercell in GVSundayCollection.HeaderRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GVSundayCollection.HeaderStyle.ForeColor);

                    PdfPCell pdfPCell = new PdfPCell(new Phrase(headercell.Text, font));
                    pdfPCell.BackgroundColor = new BaseColor(GVSundayCollection.HeaderStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                }

                foreach (GridViewRow gridViewRow in GVSundayCollection.Rows)
                {
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(GVSundayCollection.RowStyle.ForeColor);

                        PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                        pdfPCell.BackgroundColor = new BaseColor(GVSundayCollection.RowStyle.BackColor);
                        pdfPTable.AddCell(pdfPCell);
                    }
                }
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 50f, 10f);
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
            else
            {


                PdfPTable pdfPTable1 = new PdfPTable(1);
                PdfPCell cell1 = new PdfPCell(new Phrase("Report for " + Session["EventName"].ToString()));
                pdfPTable1.AddCell(cell1);

                PdfPTable pdfPTable = new PdfPTable(GVIncomeTable.HeaderRow.Cells.Count);
                foreach (TableCell headercell in GVIncomeTable.HeaderRow.Cells)
                {
                    Font font = new Font();
                    font.Color = new BaseColor(GVIncomeTable.HeaderStyle.ForeColor);

                    PdfPCell pdfPCell = new PdfPCell(new Phrase(headercell.Text, font));
                    pdfPCell.BackgroundColor = new BaseColor(GVIncomeTable.HeaderStyle.BackColor);
                    pdfPTable.AddCell(pdfPCell);
                }

                foreach (GridViewRow gridViewRow in GVIncomeTable.Rows)
                {
                    foreach (TableCell tableCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(GVIncomeTable.RowStyle.ForeColor);

                        PdfPCell pdfPCell = new PdfPCell(new Phrase(tableCell.Text));
                        pdfPCell.BackgroundColor = new BaseColor(GVIncomeTable.RowStyle.BackColor);
                        pdfPTable.AddCell(pdfPCell);
                    }
                }
                Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 50f, 10f);
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

        protected void GVIncomeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblAmountReceivedDate = (Label)e.Row.FindControl("LblAmountReceivedDate");
                
                if (LblAmountReceivedDate == null)
                {
                    return;
                }
              
                else
                {
                    String doc = LblAmountReceivedDate.Text;
                    DateTime oDate = DateTime.Parse(doc);
                    LblAmountReceivedDate.Text = oDate.ToString("dd/MM/yyyy");

                }

            }
        }

        protected void GVSundayCollection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LBLDate = (Label)e.Row.FindControl("LBLDate");
                if (LBLDate == null)
                {
                    return;
                }
                else
                {
                    String doc = LBLDate.Text;
                    LBLDate.Text = DateTime.Parse(doc).ToString("dd/MM/yyyy");
                }
              

            }
        }
    }
}