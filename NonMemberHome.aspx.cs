using Diocese.Project_Code.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class NonMemberRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NonMemberBO objNonMemberBO = new NonMemberBO();
            objNonMemberBO.NonMember_id1 = Convert.ToInt32(Session["nonmember_id"]);
            Session["non_member_type"] = 4;
            LBLHeadName.Text = Session["Headname"].ToString();
        }
    }
}