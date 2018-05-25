using Diocese.Project_Code.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class NonMemberRegistration : System.Web.UI.Page
    {
        NonMemberBO objNonMemberBO = new NonMemberBO();
        NonMemberBLL objNonMemberBLL = new NonMemberBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnAddMember_Click(object sender, EventArgs e)
        {
            objNonMemberBO.Uname1 = TBusername.Text;
            objNonMemberBO.Pwd1 = TBPassword.Text;
            objNonMemberBO.ContactNo1 = TBContactNumber.Text;
            objNonMemberBO.Email1 = TBEmail.Text;
            objNonMemberBO.To_Parishid1 = Convert.ToInt32(DropDownList1.SelectedValue);
            objNonMemberBO.Family_Name1 = TBFamilyName.Text;
            objNonMemberBO.OfficialName1 = TBOfficialName.Text;
            objNonMemberBO.Po1 = TBPO.Text;
            string a = Dobhidden.Value.ToString();
            DateTime oDate = DateTime.Parse(a);
            string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
            objNonMemberBO.Dob1 = dob;
            objNonMemberBO.Landmark1 = TBLandmark.Text;
            objNonMemberBO.FName1 = TBFatherName.Text;
            objNonMemberBO.MName1 = TBMotherName.Text;
            objNonMemberBO.IsParishMember1 =0;
            int result = objNonMemberBLL.RegisterNonMemberDetails(objNonMemberBO);
            Response.Redirect("LoginForm.aspx");
        }
    }
}