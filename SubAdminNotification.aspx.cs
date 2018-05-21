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
    public partial class SubAdminNotification : System.Web.UI.Page
    {
        RequestBO objRequestBO = new RequestBO();
        RequestBLL objRequestBLL = new RequestBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            objRequestBO.Parishid1 = Convert.ToInt32(Session["parishid"]);
            if (!Page.IsPostBack)
            {
                Load_data();

            }

        }
        public void Load_data()
        {
            Session["Dt"] = objRequestBLL.GetNotificationDetails(objRequestBO);
            GVSubAdminNotification.DataSource = Session["Dt"];
            GVSubAdminNotification.DataBind();
        }

        protected void GVSubAdminNotification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVSubAdminNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVSubAdminNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVSubAdminNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
            result = objRequestBLL.Delete_Request(id);
            Load_data();
        }

        protected void GVSubAdminNotification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVSubAdminNotification.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVSubAdminNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBDescription = GVSubAdminNotification.Rows[e.RowIndex].FindControl("TBDescription") as TextBox;
            DropDownList Status = GVSubAdminNotification.Rows[e.RowIndex].FindControl("DropDownList1") as DropDownList;
            objRequestBO.RequestStatus_Description1 = TBDescription.Text;
            objRequestBO.RequestStatus = Convert.ToInt32(Status.SelectedValue);
            int id = Convert.ToInt16(GVSubAdminNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
            result = objRequestBLL.UpdateRequest(objRequestBO, id);
            GVSubAdminNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVSubAdminNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSubAdminNotification.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVSubAdminNotification.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVSubAdminNotification.DataSource = dt;
                GVSubAdminNotification.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVSubAdminNotification.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVSubAdminNotification.DataSource = dt;
                GVSubAdminNotification.DataBind();
            }
            else
            {
                GVSubAdminNotification.AllowPaging = false;
                Load_data();
            }
        }

        protected void Imgbtnsearch_Click(object sender, ImageClickEventArgs e)
        {

        }



        protected void GVSubAdminNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label RequestStatus = (Label)e.Row.FindControl("LBLRequestStatus");
                Button requestbtn = (Button)e.Row.FindControl("Downloadbtn");
                Label Event_Name = (Label)e.Row.FindControl("LBLEvent_Name");
                if (RequestStatus.Text=="1" && Event_Name.Text=="Baptism")
                {

                    requestbtn.Visible=true;
                }

            }
        }

        protected void Downloadbtn_Click(object sender, EventArgs e)
        {

            int memberid = Convert.ToInt32(((Button)sender).CommandArgument);
            Session["btn_Dwn_memberid"] = memberid;

            //pending codes for update

        }

        protected void LinkBtnMoreDetails_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Details")
            {
                int memberid = Convert.ToInt32(e.CommandArgument.ToString());
                Session["SubAdmin_viewDetails"] = memberid;
                //check whether member is 'isparish' or 'or not' 
                Response.Redirect("Sub_ViewMore_Baptism_Details.aspx");
            }
        }
    }
}