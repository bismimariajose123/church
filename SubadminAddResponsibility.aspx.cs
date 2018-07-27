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
             if (!IsPostBack)
            {
                if (Session["AdminName"] == null)
                {
                    Response.Redirect("Logout.aspx");
                }
                else
                {
                    LBLsubadminname.Text = Session["AdminName"].ToString();
                }
                objResponsibilityBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());

            }
        }

        protected void BtnAddResponsibility_Click(object sender, EventArgs e) //ADD RESPONSIBILITY(1)
        {
            objResponsibilityBO.DutyName1 = TBResponsibilityName.Text;
            objResponsibilityBO.Uname = TBUname.Text;
            objResponsibilityBO.Pwd = TBPasswd.Text;
            objResponsibilityBO.Parishid1 = Convert.ToInt32(Session["parishid"].ToString());
            String tbresponsibilityname = TBResponsibilityName.Text;
            List<String> list = new List<String>();
            list.Add("Sunday Collection");
            list.Add("SundaySchool");
            int ch = 0;
            foreach (String a in list)
            {
                if (a.Equals(tbresponsibilityname))
                {
                    ch = 1;
                   
                    break;
                   
                }
                else
                {
                    ch = 0;
                }
               
            }
            if (ch == 0)
            {
                Response.Write("<script>alert('responsibility should only be Sunday Collection or SundaySchool');</script>;");
            }
            else
            {

                int chk_duplicate_responsibility = objResponsibilityBLL.chk_duplicate_responsibility(objResponsibilityBO);
                if(chk_duplicate_responsibility==0)
                {
                    int result = objResponsibilityBLL.AddResponsibility(objResponsibilityBO);
                    if (result == 1)
                    {
                        Response.Write("<script>alert('added successfully');</script>");
                    }
                   
                }
                else
                {
                    Response.Write("<script>alert('Value already exists');</script>");
                }

                Response.Redirect("SubadminAddResponsibility.aspx");
            }
           
        }

       
    }
}