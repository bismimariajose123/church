using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class CommunionForm : System.Web.UI.Page
    {
        CommunionBO objCommunionBO = new CommunionBO();
        CommunionBLL objCommunionBLL = new CommunionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
      

            protected void LnkbtnHome_Click(object sender, EventArgs e)
            {
                int usertype = Convert.ToInt32(Session["usertype"]);

                if (usertype == 3)
                {
                    Response.Redirect("MemberHome.aspx");
                }
                else if (usertype == 4)
                {
                    Response.Redirect("NonMemberHome.aspx");
                }


                else if(usertype == 6)
               {
                Response.Redirect("SundaySchool.aspx");
                 }
            }

            protected void BtnAdd_Communiondetails_Click(object sender, EventArgs e)
            {
           
               int parishid = Convert.ToInt32(Session["parishid"].ToString());


            objCommunionBO.FamilyName1 = TBFamilyName.Text;
            objCommunionBO.BaptismName1 = TBBaptismName.Text;

            objCommunionBO.OfficialName1 = TBOfficialName.Text;
            
            String dateofcommunion = Docommunionhhidden.Value;
            DateTime oDate = DateTime.Parse(dateofcommunion);

            objCommunionBO.DO_communion1 = oDate;
            objCommunionBO.FName1 = TBFatherName.Text;
            objCommunionBO.MName1 = TBMotherName.Text;
            
            objCommunionBO.Gender1 = DDLGender.SelectedItem.ToString();
            
            String dobirth = hiddob.Value;
            DateTime datebirth = DateTime.Parse(dobirth);

            objCommunionBO.DO_Birth1 = datebirth;
            int result = objCommunionBLL.AddCommunionRequest(objCommunionBO,parishid);
            if(result==1)
            {
                Response.Redirect("CommunionForm.aspx");
            }
        }
        }
    }