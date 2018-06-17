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
                
            Session["Dt"] = objParish_HallBLL.LoadGVRequest(parishid);
            GVHall.DataSource = Session["Dt"];
            GVHall.DataBind();
            
        }

        protected void GVHall_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVHall.EditIndex = -1;
            LoadGvRequest();
        }

       
        protected void GVHall_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVHall.EditIndex = e.NewEditIndex;
            LoadGvRequest();
        }

        protected void GVHall_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBDescription = GVHall.Rows[e.RowIndex].FindControl("TBDescription") as TextBox;
            DropDownList Status = GVHall.Rows[e.RowIndex].FindControl("DropDownListStatus") as DropDownList;
            Label usertype = GVHall.Rows[e.RowIndex].FindControl("Lblusertype") as Label;
            objParish_HallBO.Description = TBDescription.Text;
            objParish_HallBO.Status = Convert.ToInt32(Status.SelectedValue);
            objParish_HallBO.Usertype = Convert.ToInt32(usertype.Text);  //set is parish member
            int id = Convert.ToInt16(GVHall.DataKeys[e.RowIndex].Values["HallRequestId"].ToString());
            result = objParish_HallBLL.UpdateRequest(objParish_HallBO, id);
            GVHall.EditIndex = -1;
            LoadGvRequest();
        }

        protected void GVHall_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVHall.PageIndex = e.NewPageIndex;
            LoadGvRequest();
           
        }

        protected void DDLPagesize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue != "All"))
            {
                GVHall.PageSize = Convert.ToInt32(DDLPagesize.SelectedValue);
                DataTable dt = (DataTable)Session["Dt"];
                GVHall.DataSource = dt;
                GVHall.DataBind();
            }
            else if ((DDLPagesize.SelectedValue != "--") && (DDLPagesize.SelectedValue == "All"))
            {
                GVHall.AllowPaging = false;
                DataTable dt = (DataTable)Session["Dt"];
                GVHall.DataSource = dt;
                GVHall.DataBind();
            }
            else
            {
                GVHall.AllowPaging = false;
                LoadGvRequest();
            }
        }

        protected void GVHall_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Usertype = (Label)e.Row.FindControl("Lblusertype");
                Label Status = (Label)e.Row.FindControl("LblStatus"); 
                Label LblUsertype= (Label)e.Row.FindControl("Lbluser");
                if(Status==null)
                {
                    return;
                }
                else { 

                if (Usertype.Text=="3" ) //member
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
                if(Status.Text=="2")
                    {
                        Status.Text = "Approved";
                    }
                if(Status.Text == "3")
                    {
                        Status.Text = "Rejected";
                    }
                }
            }
        }
    }
}