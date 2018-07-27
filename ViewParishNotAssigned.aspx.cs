using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class ViewParishNotAssigned : System.Web.UI.Page
    {
        Parish_BLL objParishDetails_BLL = new Parish_BLL();
        Parish_BO objParishDetails_BO = new Parish_BO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_data();

            }
        }

        private void Load_data()
        {
            Session["Dt"] = objParishDetails_BLL.GetParishNotAssignedDetails();

            GVParishTable.DataSource = Session["Dt"];
            GVParishTable.DataBind();
        }
    }
}