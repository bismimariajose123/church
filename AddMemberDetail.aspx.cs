using Diocese.Project_Code.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddMemberDetail : System.Web.UI.Page
    {
        MemberBO objMemberRegisterBO = new MemberBO();
        MemberBLL objMemberRegisterBLL = new MemberBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objMemberRegisterBO.Parishid = Convert.ToInt32(Session["parishid"].ToString());
            objMemberRegisterBO.Familyid = Convert.ToInt32(Session["family_id"].ToString());
            if(!IsPostBack)
            {
                Load_MemberData();
            }
        }

        public void Load_MemberData()
        {
            MemberBO memberobj = new MemberBO();
            memberobj = objMemberRegisterBLL.Load_MemberData(objMemberRegisterBO);
            TBFamilyName.Text = memberobj.FamilyName;
            TBParishName.Text = Session["Parishname"].ToString();
        }
        protected void BtnAddMember_Click(object sender, EventArgs e)
        {
            if(marriedstatus.Checked)
            {
                objMemberRegisterBO.Marriedstatus = 1;
                objMemberRegisterBO.WifesOfficialname = TBWifeOffName.Text;
                objMemberRegisterBO.WifesBapname = TBWifeBapName.Text;
            }
            else
            {
                objMemberRegisterBO.Marriedstatus = 0;
                objMemberRegisterBO.WifesOfficialname =" ";
                objMemberRegisterBO.WifesBapname =" ";
            }
            string fileName = string.Empty;
            if (FileUploadimg.HasFile)
            {

                fileName = FileUploadimg.FileName; //gets full path name in filename
                fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                FileUploadimg.SaveAs(Server.MapPath(fileName));
            }
            else
            {
                fileName = " ";
               
            }
            objMemberRegisterBO.Relationid = Convert.ToInt32(DDLRelation.SelectedValue);
            objMemberRegisterBO.Officialname = TBOfficialName.Text;
            objMemberRegisterBO.Baptismname = TBBaptismName.Text;
            objMemberRegisterBO.Contactno = TBContactNumber.Text;
            if(TBOccupation.Text=="")
            {
                objMemberRegisterBO.occupation = "";
            }
            else
            {
                objMemberRegisterBO.occupation = TBOccupation.Text;
            }
            if (TBEmail.Text == "")
            {
                objMemberRegisterBO.email = "";
            }
            else
            {
                objMemberRegisterBO.email = TBEmail.Text;
            }
            
            string a = Dobhidden.Value.ToString();
            DateTime oDate = DateTime.Parse(a);
            string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
            objMemberRegisterBO.dob = dob;
            objMemberRegisterBO.landmark = TBLandmark.Text;
            objMemberRegisterBO.Fathername = TBFatherName.Text;
            objMemberRegisterBO.Mothername = TBMotherName.Text;
            objMemberRegisterBO.Parishmember = 1;
            objMemberRegisterBO.po = TBPO.Text;
            objMemberRegisterBO.Imagepath = fileName;
            objMemberRegisterBO.Baptism_id = 0;
            objMemberRegisterBO.Marriage_id = 0;
            objMemberRegisterBO.Registered_Status = 0;
            objMemberRegisterBO.NativeParishName = TBParishName.Text;
            objMemberRegisterBO.FamilyName = TBFamilyName.Text;
            int value = objMemberRegisterBLL.InsertMemberDetails(objMemberRegisterBO);
            Response.Redirect("AddMemberDetail.aspx");
        }

        protected void LinkButtonHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("MemberHome.aspx");
        }
    }
}