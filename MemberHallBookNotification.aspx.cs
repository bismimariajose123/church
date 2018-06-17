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
    public partial class MemberHallBookNotification : System.Web.UI.Page
    {
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        Parish_HallBO objParish_HallBO = new Parish_HallBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadMemberNotification();
            }
        }

        public void LoadMemberNotification()
        {
            int parishid= Convert.ToInt32(Session["parishid"]);
            int userid= Convert.ToInt32(Session["family_id"].ToString());
            int usertype = Convert.ToInt32(Session["usertype"]);
            Session["DT"] = objParish_HallBLL.LoadMemberNotification(parishid,userid, usertype);
            GVMemberNotification.DataSource = Session["DT"];
            GVMemberNotification.DataBind();

        }
        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVMemberNotification.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVMemberNotification.DataSource = dt;
                GVMemberNotification.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVMemberNotification.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVMemberNotification.DataSource = dt;
                GVMemberNotification.DataBind();
            }
            else
            {
                GVMemberNotification.AllowPaging = false;
                LoadMemberNotification();
            }
        }

        protected void GVMemberNotification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVMemberNotification.EditIndex = -1;
            LoadMemberNotification();
        }

        protected void GVMemberNotification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVMemberNotification.EditIndex = e.NewEditIndex;
            LoadMemberNotification();
        }

        protected void GVMemberNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBRequestDate = GVMemberNotification.Rows[e.RowIndex].FindControl("TBRequestDate") as TextBox;
            int id = Convert.ToInt16(GVMemberNotification.DataKeys[e.RowIndex].Values["HallRequestId"].ToString());
            objParish_HallBO.RequestDate1 = Convert.ToDateTime(TBRequestDate);
            result = objParish_HallBLL.UpdateMember_Request(objParish_HallBO, id);
            GVMemberNotification.EditIndex = -1;
            LoadMemberNotification();


           
        }

        protected void GVMemberNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMemberNotification.PageIndex = e.NewPageIndex;
            LoadMemberNotification();
        }
    }
}