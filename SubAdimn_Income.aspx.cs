using Diocese.Project_Code;
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
            if(!IsPostBack)
            {
                Load_DonationIncome();
            }
        }
        public void Load_DonationIncome() //Load donation details to gv first
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt=objDonationBLL.Load_DonationIncome(parishid);
            Session["Datatable"] = dt;
            LblTotalIncome.Text = objDonationBLL.Display_TotalAmount(parishid);  //display total amount

            GVIncomeTable.DataSource = dt;
            GVIncomeTable.DataBind();
            
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)  
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text.Trim().ToLower().Replace("'","''");
          
            //select sum(Amount) as Sum from DonationTable where ToParishid=1 and  OfficialName like '%Vijish%' or AmountReceivedDate='05/08/2018'  

            string date1 = Dobhidden.Value;
            string date2 = Dobhidden1.Value;
            if(searchstr!="" && date1!="" && date2!="")     //string+date1+date2+parishid (1a)
            {
                DateTime oDate = Convert.ToDateTime(date1);
              //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                DateTime oDate1 = Convert.ToDateTime(date2);
                //date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                LblTotalIncome.Text = objDonationBLL.DisplayTwoDatesBasedString_TotalAmount(parishid, oDate, oDate1, searchstr); //string+date1+date2+parishid (1a)

                DataTable dt = new DataTable();
                dt = objDonationBLL.Load_DonationIncome_Two_date_string(oDate, oDate1, parishid,searchstr); //string+date1+date2+parishid (1b)

                if (dt.Rows.Count>0)
                { 
                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
                }
            }
            else    //only string search
            {


                     DataTable dt = new DataTable();
                
                     dt = objDonationBLL.Get_Search_IncomeDetails(searchstr, parishid);
                     LblTotalIncome.Text = objDonationBLL.Get_Search_TotalAmount(searchstr,parishid); 

                       if (dt.Rows.Count > 0)
                        {
                       GVIncomeTable.DataSource = dt;
                        GVIncomeTable.DataBind();
                         }
                      else
                      {
                        Response.Write("<script>alert('search not found');</script>");
                      }
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

        protected void Datesearch_Click(object sender, EventArgs e)   //search by date  SEARCH BUTTON
        {
            DataTable dt = new DataTable();
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            string date1 = Dobhidden.Value;
            string date2 = Dobhidden1.Value;
            int eventid = Convert.ToInt32(DDleventid.SelectedValue);
            if (date1!="" && date2=="" && eventid == 0) //FIRST DATE NOT EMPTY
            {
                DateTime oDate = Convert.ToDateTime(date1);
               // date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
           
              dt = objDonationBLL.Load_DonationIncome_Onedate1(oDate, parishid);   //date1+parishid (2a)
                LblTotalIncome.Text = objDonationBLL.DisplaySearchedString_TotalAmount(parishid, oDate);  //date1+parishid (2b)
            }

            else if(date2 !="" && date1 == "" && eventid == 0) //SECOND DATE NOT EMPTY
            {
                DateTime oDate1 = Convert.ToDateTime(date2);
                // date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011

                dt = objDonationBLL.Load_DonationIncome_Onedate1(oDate1, parishid); //date1+parishid (2a)
                LblTotalIncome.Text = objDonationBLL.DisplaySearchedString_TotalAmount(parishid, oDate1); ///date1+parishid (2b)
            }

            else if(date1 !="" && date2 !="" && searchstr=="" && eventid == 0) //BOTH DATES NOT EMPTY
            {
                DateTime oDate = Convert.ToDateTime(date1);
                //    date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                DateTime oDate1 =Convert.ToDateTime(date2);
                // date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011

                dt = objDonationBLL.Load_DonationIncome_TwoDate(oDate, oDate1, parishid);    //date1+date2+parishid (3a)

                LblTotalIncome.Text = objDonationBLL.DisplayTwoDatesBased_TotalAmount(parishid, oDate, oDate1); //date1+date2+parishid (3b)
            }
            else if(searchstr != "" && date1 != "" && date2 != "" && eventid == 0)
                {
                    DateTime oDate = DateTime.Parse(date1);
                  //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                    DateTime oDate1 = DateTime.Parse(date2);
                //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                LblTotalIncome.Text = objDonationBLL.DisplayTwoDatesBasedString_TotalAmount(parishid, oDate, oDate1, searchstr);


                dt = objDonationBLL.Load_DonationIncome_Two_date_string(oDate, oDate1, parishid, searchstr); //string+date1+date2+parishid (1b)

                //if (dt.Rows.Count > 0)
                //{
                //    GVIncomeTable.DataSource = dt;
                //    GVIncomeTable.DataBind();
                //}
            }
            else if(searchstr=="" && date1 !="" && date2!="" && eventid!=0)    //event+date1+date2
            {

                DateTime oDate = DateTime.Parse(date1);
                //  date1 = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                DateTime oDate1 = DateTime.Parse(date2);
                //   date2 = Convert.ToDateTime(oDate1.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                LblTotalIncome.Text = objDonationBLL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid);


                dt = objDonationBLL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid); 

            }

            if (dt.Rows.Count > 0)
            {
                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");

            }
        }

        protected void BtnEventvalue_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            int eventid = Convert.ToInt32(DDleventid.SelectedValue);

            string eventName = Convert.ToString(DDleventid.SelectedItem);

            if (eventName == "Sunday Collection")
            {
                dt = objDonationBLL.Get_Search_IncomeDetails(eventName, parishid);
                EventNameSundaycollection.Visible = true;
                LblTotalIncome.Text = objDonationBLL.Get_Search_TotalAmount(eventName, parishid);

                if (dt.Rows.Count > 0)
                {
                    GVSundayCollection.DataSource = dt;
                    GVSundayCollection.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");
                }
            }

            else { 
            LblTotalIncome.Text = objDonationBLL.Search_Event(parishid, eventid);//total amount
            dt = objDonationBLL.LoadEvent_search(parishid, eventid);//load into gv donation
            if (dt.Rows.Count > 0)
            {
                GVIncomeTable.DataSource = dt;
                GVIncomeTable.DataBind();
            }
            }

        }
    }
}