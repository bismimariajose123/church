using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class Super_AdminChange : System.Web.UI.Page
    {
        SuperAdminBO objSuperAdminBO = new SuperAdminBO();
        SuperAdminBLL objSuperAdminBLL = new SuperAdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void BtnPriest_SuperAdmin_Click(object sender, EventArgs e)
        {
            objSuperAdminBO.Username1 = TBUsername.Text;
            objSuperAdminBO.Password1 = TBPassword.Text;
            objSuperAdminBO.Priestid1 = Convert.ToInt32(DDLPriestName.SelectedValue);
            DateTime created_date = DateTime.Now;
            string date_joined = Convert.ToDateTime(created_date.ToLongDateString()).ToString("dd/MM/yyyy");
            objSuperAdminBO.Date_created1 = date_joined;
            objSuperAdminBO.IsActive1 = 1;
            int result=objSuperAdminBLL.AddSuperAdmin(objSuperAdminBO);
            if(result==1)
            {
                Response.Redirect("Super_AdminChange.aspx");
            }
        }
    }
}