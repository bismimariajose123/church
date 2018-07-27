using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddEvent : System.Web.UI.Page
    {
        EventBO objEventBO = new EventBO();
        EventBLL objEventBLL = new EventBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            
            objEventBO.EventName1 = TBEventName.Text;

            if (Session["parishid"].ToString() == null)
            {
                Response.Redirect("Logout.aspx");
            }
            else
            {
                objEventBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
                int result = objEventBLL.AddEvent(objEventBO);
                Response.Redirect("AddEvent.aspx");
            }
           

        }
    }
}