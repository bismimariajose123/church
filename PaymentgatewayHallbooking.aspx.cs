using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class PaymentgatewayHallbooking : System.Web.UI.Page
    {
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["HallRate"].ToString();

        }

        protected void PayButton_Click(object sender, EventArgs e)
        {
            Parish_HallBO objParish_HallBO = new Parish_HallBO();
            ArrayList al = (ArrayList)Session["arraylist"];
            objParish_HallBO.Hallid1=Convert.ToInt32(al[0]);
            objParish_HallBO.Usertype = Convert.ToInt32(al[1]);
            objParish_HallBO.Eventid1 = Convert.ToInt32(al[2]);
            objParish_HallBO.parishid = Convert.ToInt32(al[3]);
            objParish_HallBO.Userid= Convert.ToInt32(al[4]);
            objParish_HallBO.IsPaid1 = "paid";
           int result= objParish_HallBLL.UpdateIsPaid(objParish_HallBO);
            Response.Write("<script>alert('payment successful')</script>");
            if (objParish_HallBO.Usertype == 3)
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