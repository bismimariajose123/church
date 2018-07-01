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
    public partial class MemberHallBookNotification1 : System.Web.UI.Page
    {
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        Parish_HallBO objParish_HallBO = new Parish_HallBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMemberNotification();
                LoadEventName();
            }
        }

        public void LoadMemberNotification()
        {
            int parishid = Convert.ToInt32(Session["parishid"]);
            int userid = Convert.ToInt32(Session["family_id"].ToString());
            int usertype = Convert.ToInt32(Session["usertype"]);
            
                DataTable dt = new DataTable();
               dt = objParish_HallBLL.LoadMemberNotification(parishid, userid, usertype);
            Session["DT"] = dt;
            if(dt.Rows.Count>0)
            { 
            GVMemberNotification.DataSource = Session["DT"];
            GVMemberNotification.DataBind();
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
           
            objParish_HallBO.RequestDate1 = Convert.ToDateTime(TBRequestDate.Text);
            result = objParish_HallBLL.UpdateMember_Request(objParish_HallBO, id);
            GVMemberNotification.EditIndex = -1;
            LoadMemberNotification();
        }

        protected void GVMemberNotification_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMemberNotification.PageIndex = e.NewPageIndex;
            LoadMemberNotification();
        }

        protected void GVMemberNotification_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                Label Status = (Label)e.Row.FindControl("LblStatus");
                Label LblUsertype = (Label)e.Row.FindControl("Lbluser");
                if (Status == null)
                {
                    return;
                }
                else
                {
                   
                    if (Status.Text == "1")
                    {
                        Status.Text = "Request";
                    }
                    if (Status.Text == "2")
                    {
                        Status.Text = "Approved";
                    }
                    if (Status.Text == "3")
                    {
                        Status.Text = "Rejected";
                    }
                    if(Status.Text == "4")
                    {
                        Status.Text = "Added";
                    }
                }
            }
        }
        public void LoadEventName()
        {
            
            ExpenseBO objExpenseBO = new ExpenseBO();
            ExpenseBLL objExpenseBLL = new ExpenseBLL();
            objExpenseBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = new DataTable();
            dt = objExpenseBLL.DDl_EventName(objExpenseBO);
            if (dt.Rows.Count > 0)
            {
                DDlEventName.DataSource = dt;                  //DDLExpenseEvent [AMOUNT TAKEN FROM]
                DDlEventName.DataTextField = "EventName";
                DDlEventName.DataValueField = "EventId";
                DDlEventName.DataBind();
            }
            else
            {
                Response.Write("<script>alert(' no record found');</script>");
            }
        }
       

        protected void BtnSearch_Click(object sender, EventArgs e)   //not completed
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            string date1 = Dobhidden.Value;
            int userid = Convert.ToInt32(Session["family_id"].ToString());
            int usertype = Convert.ToInt32(Session["usertype"]);
            int eventid = Convert.ToInt32(DDlEventName.SelectedValue);
            //string eventname = DDlExpenseEvent.SelectedItem.ToString();
            //Session["EventName"] = eventname;
            DataTable dt = new DataTable();
            if (eventid != 0)
            {
                if (date1 != "" )//all not null
                {
                    DateTime oDate = DateTime.Parse(date1);
                   
                    dt = objParish_HallBLL.Search(oDate, parishid, eventid, userid, usertype);
                   

                }
                else if (date1 =="" ) //only event search
                {
                    dt = objParish_HallBLL.SearchEvent(parishid, eventid, userid, usertype);
                   
                }
                if (dt.Rows.Count > 0)
                {


                    GVMemberNotification.Visible = true;
                    GVMemberNotification.DataSource = dt;
                    GVMemberNotification.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('search not found');</script>");
                }


            }
            else
            {
                Response.Write("<script>alert('select event');</script>");
            }

        }

        protected void GVMemberNotification_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVMemberNotification.DataKeys[e.RowIndex].Values["HallRequestId"].ToString());
            result = objParish_HallBLL.Delete_HallRequest(id);
            LoadMemberNotification();
        }
    }
}