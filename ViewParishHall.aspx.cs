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
    public partial class ViewParishHall : System.Web.UI.Page
    {
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        Parish_HallBO objParish_HallBO = new Parish_HallBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_Data();
            }
        }

        public void Load_Data()
        {
            objParish_HallBO.parishid = Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt=new DataTable();
            dt = objParish_HallBLL.GetParishHallDetails(objParish_HallBO);
            Session["Dt"] = dt;
            GVHallTable.DataSource = dt;
            GVHallTable.DataBind();
        }
        protected void GVHallTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVHallTable.EditIndex = -1;
            Load_Data();
        }

        protected void GVHallTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            int id = Convert.ToInt16(GVHallTable.DataKeys[e.RowIndex].Values["Hall_ID"].ToString());
            result = objParish_HallBLL.Delete_ParishHall(id);
            Load_Data();
        }

        protected void GVHallTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVHallTable.EditIndex = e.NewEditIndex;
            Load_Data();
        }

        protected void GVHallTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            TextBox TBHallName = GVHallTable.Rows[e.RowIndex].FindControl("TBHallName") as TextBox;
            TextBox TBPeopleCount = GVHallTable.Rows[e.RowIndex].FindControl("TBPeopleCount") as TextBox;
            TextBox TBRate = GVHallTable.Rows[e.RowIndex].FindControl("TBRate") as TextBox;
           
            int id = Convert.ToInt16(GVHallTable.DataKeys[e.RowIndex].Values["Hall_ID"].ToString());
            objParish_HallBO.Hallname = TBHallName.Text;
            objParish_HallBO.People_count = Convert.ToInt32(TBPeopleCount.Text);
            objParish_HallBO.rate = TBRate.Text;
            result = objParish_HallBLL.UpdateParishHall(objParish_HallBO, id);
            GVHallTable.EditIndex = -1;
            Load_Data();
        }

        protected void GVHallTable_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVHallTable.PageIndex = e.NewPageIndex;
            this.Load_Data();
        }
    }
}