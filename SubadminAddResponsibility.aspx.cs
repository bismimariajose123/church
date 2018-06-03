using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class SubadminAddResponsibility : System.Web.UI.Page
    {
        ResponsibilityBO objResponsibilityBO = new ResponsibilityBO();
        ResponsibilityBLL objResponsibilityBLL = new ResponsibilityBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objResponsibilityBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
        }

        protected void BtnAddResponsibility_Click(object sender, EventArgs e) //ADD RESPONSIBILITY(1)
        {
            objResponsibilityBO.DutyName1 = TBResponsibilityName.Text;
            objResponsibilityBO.Uname = TBUname.Text;
            objResponsibilityBO.Pwd = TBPasswd.Text;
            int result = objResponsibilityBLL.AddResponsibility(objResponsibilityBO);
            Response.Redirect("SubadminAddResponsibility.aspx");
        }
    }
}