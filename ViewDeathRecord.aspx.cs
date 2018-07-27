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
    public partial class ViewDeathRecord : System.Web.UI.Page
    {
        DeathBLL objDeathBLL = new DeathBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_data();
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            if(searchstr.Equals(""))
            {
                Response.Write("<script>alert('enter a valid string for search');</script>");
            }
            else
            {
                int parishid = Convert.ToInt32(Session["parishid"].ToString());
                DataTable dt = objDeathBLL.Get_Search_DeathDetails(parishid, searchstr);

                if (dt.Rows.Count > 0)
                {
                    GVDeathTable.DataSource = dt;
                    GVDeathTable.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");

                }
            }
          

        }
        private void Load_data()
             {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt;
            dt = objDeathBLL.GetDeathDetails(parishid);
            if(dt.Rows.Count>0)
            { 
            Session["Dt"] = dt;

            GVDeathTable.DataSource = dt;
            GVDeathTable.DataBind();
            }
            else
            {
                Response.Write("<script>alert('no records')</script>");
            }
        }
        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVDeathTable.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVDeathTable.DataSource = dt;
                GVDeathTable.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVDeathTable.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVDeathTable.DataSource = dt;
                GVDeathTable.DataBind();
            }
            else
            {
                GVDeathTable.AllowPaging = false;
                Load_data();
            }
        }
        protected void GVDeathTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVDeathTable.PageIndex = e.NewPageIndex;
            this.Load_data();
        }
        protected void GVDeathTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LBLDO_Death = (Label)e.Row.FindControl("LBLDO_Death");
                Label LBLDo_Funeral = (Label)e.Row.FindControl("LBLDo_Funeral");
                if (LBLDO_Death == null && LBLDo_Funeral==null)
                {
                    return;
                }
                else
                {
                   
                    DateTime oDate1 = DateTime.Parse(LBLDo_Funeral.Text);
                    DateTime oDate2 = DateTime.Parse(LBLDO_Death.Text);
                    
                    String dofuneral = oDate1.ToString("dd/MM/yyyy");
                    String dodeath = oDate2.ToString("dd/MM/yyyy");
                    LBLDo_Funeral.Text = dofuneral;
                    LBLDO_Death.Text = dodeath;
                }

            }
        }

    }
}