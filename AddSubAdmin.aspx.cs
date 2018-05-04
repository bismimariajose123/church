using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddSubAdmin : System.Web.UI.Page
    {
        Sub_admin_LoginBLL obj_Sub_admin_LoginBLL = new Sub_admin_LoginBLL();
        Sub_admin_LoginBO obj_Sub_admin_LoginBO = new Sub_admin_LoginBO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Sub_admin_login_Click(object sender, EventArgs e)
        {
            obj_Sub_admin_LoginBO.Sub_admin_UName = TBUname.Text;
            obj_Sub_admin_LoginBO.Sub_Ad_PWD = TBPwd.Text;
            obj_Sub_admin_LoginBO.Sub_Ad_ParishID = Convert.ToInt32(DDLChurchName.SelectedValue);
            int result = obj_Sub_admin_LoginBLL.Add_sub_admin_login(obj_Sub_admin_LoginBO);
            Response.Redirect("AddSubAdmin.aspx");
        }
    }
}