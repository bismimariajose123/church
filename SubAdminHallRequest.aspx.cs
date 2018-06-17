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
    public partial class SubAdminHallRequest : System.Web.UI.Page
    {
        Parish_HallBO objParish_HallBO = new Parish_HallBO();
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadGvRequest();
            }
            

        }

        public void LoadGvRequest()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            int usertype = Convert.ToInt32(Session["usertype"]);
            int userid;
            if (usertype == 3)//member
            {
                 userid = Convert.ToInt32(Session["family_id"]);
            }
            else
            {
                 userid= Convert.ToInt32(Session["nonmember_id"]);
            }
                DataTable dt=new DataTable();
            dt = objParish_HallBLL.LoadGVRequest(parishid);
            GVHall.DataSource = dt;
            GVHall.DataBind();
            
        }

        protected void GVHall_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GVHall_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVHall_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVHall_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVHall_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GVHall_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Usertype = (Label)e.Row.FindControl("Lblusertype");
                Label Status = (Label)e.Row.FindControl("LblStatus"); 
                Label LblUsertype= (Label)e.Row.FindControl("Lbluser");
                if(Usertype.Text=="3")
                {
                    LblUsertype.Visible = true;
                    LblUsertype.Text="Member";
                }
                else
                {
                    LblUsertype.Visible = true;
                    LblUsertype.Text = "Non-Member";
                }
                if(Status.Text=="1")
                {
                    Status.Text = "Request";
                }
            }
        }
    }
}