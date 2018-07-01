using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class Paymentgateway : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["Amount"].ToString();
            
        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            int userid =Convert.ToInt32(Session["userid"].ToString());
            int usertype = Convert.ToInt32(Session["usertype_donation"].ToString());
            int eventid= Convert.ToInt32(Session["paymenteventid"]);

           int parishid =  Convert.ToInt32(Session["parishid"].ToString());
            
            DonationBLL objDonationBLL = new DonationBLL();
            objDonationBLL.Update_ispayed_inDonation(userid, usertype, parishid);
            Response.Write("<script>alert('payment successful')</script>");
            if(usertype==3)
            {
                Response.Redirect("MemberHome.aspx");
            }
            else
            {
                Response.Redirect("NonMemberHome.aspx");
            }
          
        }
    }
}