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
    }
}