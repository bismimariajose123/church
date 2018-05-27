using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class SubAdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             LBLsubadminname.Text = Session["AdminName"].ToString();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            Session.Clear();
            Response.Redirect("LoginForm.aspx");
        }
    }
}