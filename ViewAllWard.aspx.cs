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
    public partial class ViewAllWard : System.Web.UI.Page
    {
        WardBO objWardBO = new WardBO();
        WardBLL objWardBLL = new WardBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_data();
            }
        }

        public void Load_data()
        {
            objWardBO.Parish_id = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt;
            dt= objWardBLL.GetWardDetails(objWardBO);
            Session["Dt"] = dt;

            GVWardTable.DataSource = dt;
            GVWardTable.DataBind();
        }
        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVWardTable.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVWardTable.DataSource = dt;
                GVWardTable.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVWardTable.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVWardTable.DataSource = dt;
                GVWardTable.DataBind();
            }
            else
            {
                GVWardTable.AllowPaging = false;
                Load_data();
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            objWardBO.Parish_id = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objWardBLL.Get_Search_WardDetails(objWardBO,searchstr);

            if (dt.Rows.Count > 0)
            {
                GVWardTable.DataSource = dt;
                GVWardTable.DataBind();
            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");

            }
            

        }

        protected void GVWardTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVWardTable.EditIndex = -1;
            Load_data();
        }

        protected void GVWardTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVWardTable.DataKeys[e.RowIndex].Values["Ward_ID"].ToString());
            result = objWardBLL.Delete_Ward(id);
            Load_data();
        }

        protected void GVWardTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVWardTable.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVWardTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBWard_Name = GVWardTable.Rows[e.RowIndex].FindControl("TBWardName") as TextBox;
            int id = Convert.ToInt16(GVWardTable.DataKeys[e.RowIndex].Values["Ward_ID"].ToString());
            objWardBO.Wardname = TBWard_Name.Text;
            result = objWardBLL.UpdateWard(objWardBO, id);
            GVWardTable.EditIndex = -1;
            Load_data();
        }

        protected void GVWardTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVWardTable.PageIndex = e.NewPageIndex;
            this.Load_data();
        }
    }
}