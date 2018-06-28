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
    public partial class Member_ViewNotification : System.Web.UI.Page
    {
        RequestBLL objRequestBLL = new RequestBLL();
        RequestBO objRequestBO = new RequestBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            objRequestBO.Parishid1 = Convert.ToInt32(Session["parishid"]); // from login
            objRequestBO.IsParishMember = 1;
            objRequestBO.FamilyId1 = Convert.ToInt32(Session["family_id"].ToString());
            if (!IsPostBack)
            {
                Load_data();
            }
        }

        public void Load_data()
        {
            DataTable dt = objRequestBLL.GetMemberNotificationDetails(objRequestBO);
            if (dt.Rows.Count > 0)
            {
                Session["Dt"] = dt;
                GVMemberNotification.DataSource = Session["Dt"];
                GVMemberNotification.DataBind();
            }
            else
            {
                Response.Write("<script>alert('no notification')</script>");
            }
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
                Load_data();
            }
        }

        protected void GVMemberNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMemberNotification.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        //protected void GVMemberNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int result = 0;
        //    int id = Convert.ToInt16(GVMemberNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
        //    result = objRequestBLL.Delete_MemberRequest(id);
        //    Load_data();
        //}



        protected void GVMemberNotification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVMemberNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVMemberNotification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVMemberNotification.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GVMemberNotification_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBProposedDate = GVMemberNotification.Rows[e.RowIndex].FindControl("TBProposedDate") as TextBox;
            TextBox TBProposedTime = GVMemberNotification.Rows[e.RowIndex].FindControl("TBProposedTime") as TextBox;
            objRequestBO.ProposedDateOfBap1 = TBProposedDate.Text;
            objRequestBO.ProposedTimeOfBap1 = TBProposedTime.Text;
            int id = Convert.ToInt16(GVMemberNotification.DataKeys[e.RowIndex].Values["Memberid"].ToString());
            result = objRequestBLL.UpdateMember_Request(objRequestBO, id);
            GVMemberNotification.EditIndex = -1;
            Load_data();
        }

        protected void GVMemberNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label RequestStatus = (Label)e.Row.FindControl("LBLRequestStatus");
                Label LBLRequestStatusLabel = (Label)e.Row.FindControl("LBLRequestStatusLabel");
                if (RequestStatus == null && LBLRequestStatusLabel == null)
                {
                    return;
                }
                if (RequestStatus.Text == "1")
                {
                    LBLRequestStatusLabel.Visible = true;
                    LBLRequestStatusLabel.Text = "Approved";
                }
                if (RequestStatus.Text == "2")
                {
                    LBLRequestStatusLabel.Visible = true;
                    LBLRequestStatusLabel.Text = "Rejected";
                }
                if (RequestStatus.Text == "4")
                {
                    LBLRequestStatusLabel.Visible = true;
                    LBLRequestStatusLabel.Text = "Added";
                }

            }
        }
    }
}