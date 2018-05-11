using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class MemberHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LBLHeadName.Text = Session["Headname"].ToString();
            HiddenFieldFamilyID.Value = Session["family_id"].ToString();

        }
        
    }
}