using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class LoginForm : System.Web.UI.Page
    {
        LoginBO objLoginBO = new LoginBO();
        LoginBLL objLoginBLL = new LoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogibBtn_Click(object sender, EventArgs e)
        {
            objLoginBO.username = TBUsername.Text;
            objLoginBO.Pwd = TBPassword.Text;
            objLoginBO.Parishid = Convert.ToInt32(DDLParish.SelectedValue);
            objLoginBO.User_type = Convert.ToInt32(DLLUsertype.SelectedValue);
            Session["parishid"] = objLoginBO.Parishid;

            int result = objLoginBLL.CheckLogin(objLoginBO);
            if(result==1)
            {
                Response.Redirect("Superadminhome.aspx");
            }
            else if(result==2)
            {
                Session["AdminName"] = objLoginBO.Personname.ToString();
                Response.Redirect("SubAdminHome.aspx");
            }
            else if (result == 3)
            {
                Response.Redirect("MemberHome.aspx");
            }
            else if (result == 4)
            {
                Response.Redirect("NonParishMemberHome.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid login');</script>");

            }

        }
    }
}