using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddParish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void BtnAddParish_Click(object sender, EventArgs e)
        {
            int result=0;
            Parish_BO objParishDetails = new Parish_BO();
            Parish_BLL objPariahDetailsBLL = new Parish_BLL();
            objParishDetails.ParishName = TBChurchName.Text;
            objParishDetails.ParishPlace = TBPlace.Text;
           result=objPariahDetailsBLL.InsertParishDetails(objParishDetails);
            Response.Redirect("AddParish.aspx");

        }
    }
}