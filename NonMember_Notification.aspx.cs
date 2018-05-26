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
    public partial class NonMember_Notification : System.Web.UI.Page
    {
        RequestBLL objRequestBLL = new RequestBLL();
        RequestBO objRequestBO = new RequestBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            objRequestBO.Parishid1 = Convert.ToInt32(Session["parishid"]);
            objRequestBO.IsParishMember = 0;
            if (!IsPostBack)
            {
                Load_data();
            }

        }

        public void Load_data()
        {
            Session["Dt"] = objRequestBLL.GetNon_MemberNotificationDetails(objRequestBO);
            GV_Non_MemberNotification.DataSource = Session["Dt"];
            GV_Non_MemberNotification.DataBind();
        }
        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GV_Non_MemberNotification.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GV_Non_MemberNotification.DataSource = dt;
                GV_Non_MemberNotification.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GV_Non_MemberNotification.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GV_Non_MemberNotification.DataSource = dt;
                GV_Non_MemberNotification.DataBind();
            }
            else
            {
                GV_Non_MemberNotification.AllowPaging = false;
                Load_data();
            }
        }

        protected void GV_Non_MemberNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV_Non_MemberNotification.PageIndex = e.NewPageIndex;
            this.Load_data();
        }

        protected void GV_Non_MemberNotification_RowUpdating(object sender, GridViewUpdateEventArgs e) //updation based on Request_Id
        {
            int result = 0;
            TextBox TBProposedDate = GV_Non_MemberNotification.Rows[e.RowIndex].FindControl("TBProposedDate") as TextBox;
            TextBox TBProposedTime = GV_Non_MemberNotification.Rows[e.RowIndex].FindControl("TBProposedTime") as TextBox;
            objRequestBO.ProposedDateOfBap1 = TBProposedDate.Text;
            objRequestBO.ProposedTimeOfBap1 = TBProposedTime.Text;
            int id = Convert.ToInt16(GV_Non_MemberNotification.DataKeys[e.RowIndex].Values["Request_Id"].ToString());
            result = objRequestBLL.UpdateNon_Member_Request(objRequestBO, id);
            GV_Non_MemberNotification.EditIndex = -1;
            Load_data();
        }

        protected void GV_Non_MemberNotification_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GV_Non_MemberNotification.EditIndex = e.NewEditIndex;
            Load_data();
        }

        protected void GV_Non_MemberNotification_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GV_Non_MemberNotification.EditIndex = -1;
            Load_data();
        }
    }
}