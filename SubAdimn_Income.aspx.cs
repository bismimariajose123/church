using Diocese.Project_Code;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class SubAdimn_Income : System.Web.UI.Page
    {
        DonationBLL objDonationBLL = new DonationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            if (!IsPostBack)
            {
                LoadEventDDl();
            }
        }
        public void LoadEventDDl()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());

            DataTable dt = objDonationBLL.LoadEventDDl(parishid);
            DDleventid.DataSource = dt;
            DDleventid.DataTextField = "EventName";
            DDleventid.DataValueField = "EventId";
            DDleventid.DataBind();
        }

        public void Load_DonationIncome() //Load donation details to gv first
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objDonationBLL.Load_DonationIncome(parishid);
            Session["Datatable"] = dt;
            LblTotalIncome.Text = objDonationBLL.Display_TotalAmount(parishid);  //display total amount

            GVIncomeTable.DataSource = dt;
            GVIncomeTable.DataBind();

        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)  //IMAGEBTN SEARCH
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text.Trim().ToLower().Replace("'", "''");

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
                    Response.Write("<script>alert('search not found');</script>");
                }
            
        }



        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVIncomeTable.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Datatable"];
                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVIncomeTable.AllowPaging = false;
                DataTable dt = (DataTable)Session["Datatable"];
                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
            }
            else
            {
                GVIncomeTable.AllowPaging = false;
                Load_DonationIncome();
            }
        }

      
        protected void GVIncomeTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVIncomeTable.PageIndex = e.NewPageIndex;
            this.Load_DonationIncome();
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
            if (eventid != 6)   //not sunday collection
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
                    LblTotalAmt.Visible = true;
                    LblTotalIncome.Visible = true;
                    LblTotalIncome.Text = objDonationBLL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid);
                    dt = objDonationBLL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid);
                }
                
               else if(searchstr == "" && date1 == "" && date2 == "")  //only EVENT NAME SEARCH
                {
                    LblTotalAmt.Visible = true;
                    LblTotalIncome.Visible = true;
                    LblTotalIncome.Text = objDonationBLL.Search_Event(parishid, eventid);//total amount
                    dt = objDonationBLL.LoadEvent_search(parishid, eventid);//load into gv donation
                }

                if (dt.Rows.Count > 0)
                {
                   

                    GVIncomeTable.Visible = true;
                    GVIncomeTable.DataSource = dt;
                    GVIncomeTable.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");
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

                    LblSunday.Visible = true;
                    LabelTotal.Visible = true;
                    LblSunday.Text = objDonationBLL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid);

                    dt = objDonationBLL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid);

                }
                //else if(searchstr != "" && date1 != "" && date2 != "") //string+event+date1+date2
                //{
                //    DateTime oDate = DateTime.Parse(date1);
                //    //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                //    DateTime oDate1 = DateTime.Parse(date2);
                //    //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011

                //    //
                //}
                else if(searchstr == "" && date1 == "" && date2 == "") //only EVENT NAME SEARCH
                {
                    dt = objDonationBLL.Get_Search_IncomeDetails(eventName, parishid);
                    EventNameSundaycollection.Visible = true;
                    LblSunday.Visible = true;
                    LabelTotal.Visible = true;
                    LblSunday.Text = objDonationBLL.Get_Search_TotalAmount(eventName, parishid);
                }
                if (dt.Rows.Count > 0)
                {
                   

                    GVSundayCollection.Visible = true;
                    GVSundayCollection.DataSource = dt;
                    GVSundayCollection.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");
                }
            }

        }

        protected void BtnConvertPdf_Click(object sender, EventArgs e)
        {
            
            string  eventName= Session["EventName"].ToString();
            int eventid= Convert.ToInt16(Session["Eventid"]);
            if(eventid==6)
            {
                PdfPTable pdfPTable1 = new PdfPTable(1);
                PdfPCell cell1 = new PdfPCell(new Phrase("Report for " + Session["EventName"].ToString()));
                pdfPTable1.AddCell(cell1);

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
    }
}