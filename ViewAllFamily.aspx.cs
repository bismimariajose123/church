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
    public partial class ViewAllFamily : System.Web.UI.Page
    {
        FamilyBO objFamilyBO = new FamilyBO();
        FamilyBLL objFamilyBLL = new FamilyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objFamilyBO.parish_id = Convert.ToInt32(Session["parishid"].ToString());

            if (!IsPostBack)
            {
                Load_data();
            }
        }
        public void Load_data()
        {
            DataTable dt = new DataTable();
            dt= objFamilyBLL.GetFamilyDetails(objFamilyBO);
            if(dt.Rows.Count > 0)
                {
                Session["Dt"] = dt;
                GVFamilyDetails.DataSource = Session["Dt"];
                GVFamilyDetails.DataBind();
            }
            else
            {
                Response.Write("<script>alert(' not data found');</script>");

            }

        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            objFamilyBO.parish_id = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objFamilyBLL.Get_Search_FamilyDetails(objFamilyBO, searchstr);

            if (dt.Rows.Count > 0)
            {
                GVFamilyDetails.DataSource = dt;
                GVFamilyDetails.DataBind();
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
                GVFamilyDetails.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVFamilyDetails.DataSource = dt;
                GVFamilyDetails.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVFamilyDetails.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVFamilyDetails.DataSource = dt;
                GVFamilyDetails.DataBind();
            }
            else
            {
                GVFamilyDetails.AllowPaging = false;
                Load_data();
            }
        }

        //protected void GVFamilyDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GVFamilyDetails.EditIndex = -1;
        //    Load_data();
        //}

        protected void GVFamilyDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVFamilyDetails.DataKeys[e.RowIndex].Values["Family_ID"].ToString());
            result = objFamilyBLL.Delete_Family(id);
            Load_data();
        }

        //protected void GVFamilyDetails_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GVFamilyDetails.EditIndex = e.NewEditIndex;
        //    Load_data();
        //}

        //protected void GVFamilyDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int result = 0;
        //    TextBox TBFamilyName = GVFamilyDetails.Rows[e.RowIndex].FindControl("FamilyName") as TextBox;
           
        //    int id = Convert.ToInt16(GVFamilyDetails.DataKeys[e.RowIndex].Values["Family_ID"].ToString());
        //    objFamilyBO.familyname = TBFamilyName.Text;
          // result = objFamilyBLL.UpdateWard(objFamilyBO, id);
        //    GVFamilyDetails.EditIndex = -1;
        //    Load_data();
        //}

        protected void GVFamilyDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVFamilyDetails.PageIndex = e.NewPageIndex;
            this.Load_data();
        }
    }
}