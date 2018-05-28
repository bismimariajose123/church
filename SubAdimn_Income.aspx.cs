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
        public void Load_DonationIncome()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt=objDonationBLL.Load_DonationIncome(parishid);
            Session["Datatable"] = dt;
            GVIncomeTable.DataSource = dt;
            GVIncomeTable.DataBind();
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
        
            DataTable dt = new DataTable();
            dt = objDonationBLL.Get_Search_IncomeDetails(searchstr, parishid);
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
    }
}