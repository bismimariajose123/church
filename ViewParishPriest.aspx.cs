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
    public partial class ViewParishPriest : System.Web.UI.Page
    {
        Parish_Priest_BO objPriestDetails_BO = new Parish_Priest_BO();
        Parish_Priest_BLL objPriestDetails_BLL = new Parish_Priest_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_data();

            }
        }

        public void Load_data()
        {
            Session["Dt"] = objPriestDetails_BLL.GetPriestDetails();
            GVPriestTable.DataSource = Session["Dt"];
            GVPriestTable.DataBind();
        }
        protected void GVPriestTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVPriestTable.EditIndex = -1;
            Load_data();
        }

        protected void GVPriestTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVPriestTable.DataKeys[e.RowIndex].Values["Parish_Priest_ID"].ToString());
            result = objPriestDetails_BLL.Delete_Parish(id);
            Load_data();
        }

        protected void GVPriestTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVPriestTable.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVPriestTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBPriest_Name = GVPriestTable.Rows[e.RowIndex].FindControl("TBParish_Priest_Name") as TextBox;
            TextBox TBPhoneNo = GVPriestTable.Rows[e.RowIndex].FindControl("TBPhoneNo") as TextBox;
            TextBox TBOrdinationDate = GVPriestTable.Rows[e.RowIndex].FindControl("TBOrdinationDate") as TextBox;
            TextBox TBNative_Place = GVPriestTable.Rows[e.RowIndex].FindControl("TBNative_Place") as TextBox;
            TextBox TBDesignation = GVPriestTable.Rows[e.RowIndex].FindControl("TBDesignation") as TextBox;
            //TextBox TBCurrentParish = GVPriestTable.Rows[e.RowIndex].FindControl("TBCurrentParish") as TextBox;
            
            int id = Convert.ToInt16(GVPriestTable.DataKeys[e.RowIndex].Values["Parish_Priest_ID"].ToString());
            objPriestDetails_BO.PPName = TBPriest_Name.Text;
            objPriestDetails_BO.NativePlace = TBNative_Place.Text;
            objPriestDetails_BO.Contact = TBPhoneNo.Text;
            objPriestDetails_BO.Ordination_Date = TBOrdinationDate.Text;
            objPriestDetails_BO.P_Designation = TBDesignation.Text;
            result = objPriestDetails_BLL.UpdatePriest(objPriestDetails_BO, id);
            GVPriestTable.EditIndex = -1;
            Load_data();
        }

        protected void GVPriestTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVPriestTable.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVPriestTable.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVPriestTable.DataSource = dt;
                GVPriestTable.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVPriestTable.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVPriestTable.DataSource = dt;
                GVPriestTable.DataBind();
            }
            else
            {
                GVPriestTable.AllowPaging = false;
                Load_data();
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {
            string searchstr = string.Empty;
            searchstr = TBsearch.Text;
            GVPriestTable.DataSource = objPriestDetails_BLL.Get_Search_PriestDetails(searchstr);
            GVPriestTable.DataBind();
        }
    }
}