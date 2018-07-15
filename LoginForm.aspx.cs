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
            Session["Parishname"] = DDLParish.SelectedItem.Text;
            objLoginBO.User_type = Convert.ToInt32(DLLUsertype.SelectedValue);
            Session["parishid"] = objLoginBO.Parishid;

             int value = objLoginBLL.CheckLogin(objLoginBO);
            if(value==1 && objLoginBO.User_type==1)       //Superadmin
            {
                Response.Redirect("Superadminhome.aspx");
            }
            else if(value == 1 && objLoginBO.User_type == 2)  //subadmin
            {
                Session["AdminName"] = objLoginBO.Personname.ToString();
                Response.Redirect("SubAdminHome.aspx");
            }
            else if (value == 1 && objLoginBO.User_type == 3) //member
            {
                Session["usertype"] = 3;  //for donation identification

                Session["Headname"] = objLoginBO.Personname;
                Session["family_id"] = objLoginBO.Familyid;
                Response.Redirect("MemberHome.aspx");
            }
            else if (value == 1 && objLoginBO.User_type == 4)
            {
                Session["usertype"] = 4; //for donation identification
                Session["nonmember_id"] = objLoginBO.Familyid;
                Response.Redirect("NonMemberHome.aspx");
            }
            else if (value == 1 && objLoginBO.User_type == 5)
            {
                Session["usertype"] = 5; //for donation identification
                Session["Responsibilityid"] = objLoginBO.Familyid;    //here familyid as  Responsibilityd id
                Session["DutyName"] = objLoginBO.Personname;       //here personname as dutyname
                Response.Redirect("AccountantSundayCollection.aspx");
            }
            else if (value == 1 && objLoginBO.User_type == 6)
            {
                Session["usertype"] = 6; //for donation identification
                Session["Responsibilityid"] = objLoginBO.Familyid;    //here familyid as  Responsibilityd id
                Session["DutyName"] = objLoginBO.Personname;       //here personname as dutyname
                Response.Redirect("SundaySchool.aspx");
            }

            else
            {
                Response.Write("<script>alert('Invalid login');</script>");

            }

        }
    }
}