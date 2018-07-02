using Diocese.Project_Code;
using System;
using System.Collections.Generic;
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
        }

        protected void BtnAdd_Communiondetails_Click(object sender, EventArgs e)
        {
            int usertype = Convert.ToInt32(Session["usertype"]);
            int parishid= Convert.ToInt32(Session["parishid"].ToString());
            int familyid= Convert.ToInt32(Session["family_id"]);
            objCommunionBO.FamilyName1 = TBFamilyName.Text;
            objCommunionBO.PersonsParishName1 = TBParishName.Text;
            objCommunionBO.OfficialName1 = TBOfficialName.Text;
            objCommunionBO.BaptismName1 = TBBaptismName.Text;
            objCommunionBO.ParishofCommumion1 = TBCommunionParish.Text;

            String dateofcommunion= Docommunionhhidden.Value;
            DateTime oDate = DateTime.Parse(dateofcommunion);

            objCommunionBO.DO_communion1 = oDate;
            objCommunionBO.FName1 = TBFatherName.Text;
            objCommunionBO.MName1 = TBMotherName.Text;
            objCommunionBO.Parish_PriestName1 = TBParishName.Text;
            objCommunionBO.BlessedBy1 = TBCelebrantName.Text;
            objCommunionBO.Gender1 = DDLGender.SelectedItem.ToString();
            objCommunionBO.Commu_status1 = "pending";
            int result = objCommunionBLL.AddCommunionRequest(objCommunionBO, usertype, parishid, familyid);
        }
    }
}