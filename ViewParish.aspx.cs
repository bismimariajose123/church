using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class ViewParish : System.Web.UI.Page
    {
        Parish_BLL objParishDetails_BLL = new Parish_BLL();
        Parish_BO objParishDetails_BO = new Parish_BO();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Load_data();
                
            }
        }

        public void Load_data()
        {
            Session["Dt"] = objParishDetails_BLL.GetParishDetails();

            GVParishTable.DataSource = Session["Dt"];
            GVParishTable.DataBind();
        }
        protected void GVParishTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVParishTable.DataKeys[e.RowIndex].Values["Parish_ID"].ToString());
            result=objParishDetails_BLL.Delete_Parish(id);
            Load_data();
        }

        protected void GVParishTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVParishTable.EditIndex = -1;
            Load_data();
        }

        

        protected void GVParishTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVParishTable.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVParishTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBParish_Name = GVParishTable.Rows[e.RowIndex].FindControl("TBParish_Name") as TextBox;
            TextBox TBPlace = GVParishTable.Rows[e.RowIndex].FindControl("TBPlace") as TextBox;
            TextBox TBUname = GVParishTable.Rows[e.RowIndex].FindControl("TBUname") as TextBox;
            TextBox TBPwd = GVParishTable.Rows[e.RowIndex].FindControl("TBPwd") as TextBox;

            int id = Convert.ToInt16(GVParishTable.DataKeys[e.RowIndex].Values["Parish_ID"].ToString());
            objParishDetails_BO.ParishName = TBParish_Name.Text;
            objParishDetails_BO.ParishPlace = TBPlace.Text;
            objParishDetails_BO.UName = TBUname.Text;
            objParishDetails_BO.Passwd = TBPwd.Text;
            result = objParishDetails_BLL.UpdateParish(objParishDetails_BO,id);
            GVParishTable.EditIndex = -1;
            Load_data();
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            DataTable dt = new DataTable();
            dt= objParishDetails_BLL.Get_Search_ParishDetails(searchstr);
            if (dt.Rows.Count >0)
            {
                GVParishTable.DataSource = dt;
                GVParishTable.DataBind();
            }
            else
            {
                Response.Write("<script>alert('search not found');</script>");

            }
        }

        protected void GVParishTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVParishTable.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVParishTable.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt= (DataTable)Session["Dt"];
                GVParishTable.DataSource = dt;
                GVParishTable.DataBind();
            }
            else if((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All")) 
            {
                GVParishTable.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVParishTable.DataSource = dt;
                GVParishTable.DataBind();
            }
            else
            {
                GVParishTable.AllowPaging = false;
                Load_data();
            }
        }
    }
}