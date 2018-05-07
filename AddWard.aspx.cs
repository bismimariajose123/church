using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddWard : System.Web.UI.Page
    {
        WardBO objAddWardBO = new WardBO();
        WardBLL objAddWardBLL = new WardBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddWard_Click(object sender, EventArgs e)
        {
            objAddWardBO.Wardname = TBWardName.Text;
            objAddWardBO.Parish_id = Convert.ToInt32(Session["parishid"].ToString());
            int result = objAddWardBLL.AddWard(objAddWardBO);
            if(result==1)
            {
                Response.Redirect("AddWard.aspx");
            }
            
        }
    }
}