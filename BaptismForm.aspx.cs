using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class BaptismForm : System.Web.UI.Page
    {
        BaptismBLL objBaptismBLL = new BaptismBLL();
       
        BaptismBO objBaptismBO = new BaptismBO();
        protected void Page_Load(object sender, EventArgs e)
        {
            objBaptismBO.Usertype = Convert.ToInt32(Session["Usertype_normal_bap_req"]);          //viewfamilymember   gets usertype
            if(objBaptismBO.Usertype!=0)   //if member is not loaded usertype=0
            { 
            objBaptismBO.To_Parish_id = Convert.ToInt32(Session["parishid"].ToString());
            objBaptismBO.Member_id = Convert.ToInt32(Session["ParishMember_id"].ToString());
           // objBaptismBO.isParishMember = 1;
            }
            else
            {
                //if non member is loaded usertype 
                objBaptismBO.To_Parish_id = Convert.ToInt32(Session["parishid"].ToString()); //else memberid=nonmemberid
                objBaptismBO.Member_id = Convert.ToInt32(Session["nonmember_id"]);
                //objBaptismBO.isParishMember = 0;
                objBaptismBO.Usertype = Convert.ToInt32(Session["non_member_type"]);

            }
            if (!IsPostBack)
            { 
                
              Load_MemberData();
               
            }
        }

        public void Load_MemberData()
        {
            if(objBaptismBO.Usertype==3)
            { 
            objBaptismBO = objBaptismBLL.Load_MemberData(objBaptismBO);

            TBFamilyName.Text = objBaptismBO.Familyname;
            TBParishName.Text = objBaptismBO.PersonParishname;
            TBOfficialName.Text = objBaptismBO.Officialname;
            TBBaptismName.Text = objBaptismBO.Baptismname;
            TBFatherName.Text = objBaptismBO.Fathername;
            TBMotherName.Text = objBaptismBO.Mothername;
            Session["isparishmember"] = objBaptismBO.isParishMember;
            }
            else
            {
                return;
            }
        }

        protected void Btn_insertBaptism_details_Click(object sender, EventArgs e)
        {
            int b = Convert.ToInt32(Session["isparishmember"]);
            if (marriedstatus.Checked && b == 1 && parishmember.Checked) //dad 
            {
                objBaptismBO.Familyname = TBFamilyName.Text;
                objBaptismBO.PersonParishname = TBParishName.Text;
                objBaptismBO.Officialname = TBOfficialName.Text;
                objBaptismBO.Baptismname = TBBaptismName.Text;
                objBaptismBO.Fathername = TBFatherName.Text;
                objBaptismBO.Mothername = TBMotherName.Text;
                string a = Dobhidden.Value.ToString();
                DateTime oDate = DateTime.Parse(a);
                string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                objBaptismBO.Do_Baptism = dob;
                objBaptismBO.Father_BapName = TBFatherBapName.Text;
                objBaptismBO.Mother_BapName = TBMotherBapName.Text;
                objBaptismBO.GodFatherName = TBGodfatherName.Text;
                objBaptismBO.GodMotherName = TBGodmotherName.Text;
                objBaptismBO.GFatherProof = "";
                objBaptismBO.GMotherProof = "";
                objBaptismBO.FatherProof = "";
                objBaptismBO.MotherProof = "";
                objBaptismBO.gender = DDLGender.SelectedValue;
                objBaptismBO.vicar = TBParishPriestName.Text;
                objBaptismBO.celebrant = TBCelebrantName.Text;
                objBaptismBO.isParishMember = 1;
                objBaptismBO.Baptism_Status = 1;

                string fileName = string.Empty;

                if (Fileuploadurcertificate.HasFile)
                {

                    fileName = Fileuploadurcertificate.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    Fileuploadurcertificate.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.Ur_BapProof = fileName;
                }
                else
                {
                    objBaptismBO.Ur_BapProof = "";
                }
                int value = objBaptismBLL.InsertBaptism_details(objBaptismBO);
                if (value == 1)
                {
                    int Member_detail_bapid_updated = objBaptismBLL.Update_bapid_MemberDetails(objBaptismBO);
                }
            }

            else if (marriedstatus.Checked && b == 1 && (parishmember.Checked) == false) //mom married,parishmember and parents not this parish
            {
                objBaptismBO.Familyname = TBFamilyName.Text;
                objBaptismBO.PersonParishname = TBParishName.Text;
                objBaptismBO.Officialname = TBOfficialName.Text;
                objBaptismBO.Baptismname = TBBaptismName.Text;
                objBaptismBO.Fathername = TBFatherName.Text;
                objBaptismBO.Mothername = TBMotherName.Text;
                string a = Dobhidden.Value.ToString();
                DateTime oDate = DateTime.Parse(a);
                string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                objBaptismBO.Do_Baptism = dob;
                objBaptismBO.Father_BapName = TBFatherBapName.Text;
                objBaptismBO.Mother_BapName = TBMotherBapName.Text;
                objBaptismBO.GodFatherName = TBGodfatherName.Text;
                objBaptismBO.GodMotherName = TBGodmotherName.Text;
                objBaptismBO.FatherProof = "";
                objBaptismBO.MotherProof = "";
                objBaptismBO.gender = DDLGender.SelectedValue;
                objBaptismBO.vicar = TBParishPriestName.Text;
                objBaptismBO.celebrant = TBCelebrantName.Text;
                objBaptismBO.isParishMember = 1;
                objBaptismBO.Baptism_Status = 1;
               
                string fileName = string.Empty;

                if (FileuploadGF.HasFile)
                {

                    fileName = FileuploadGF.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    Fileuploadurcertificate.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.GFatherProof = fileName;
                }
                else
                {
                    objBaptismBO.GFatherProof = "";
                }
                if (FileuploadGM.HasFile)
                {

                    fileName = FileuploadGM.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    Fileuploadurcertificate.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.GMotherProof = fileName;
                }
                else
                {
                    objBaptismBO.GMotherProof = "";
                }

                int value = objBaptismBLL.InsertBaptism_details(objBaptismBO);
                if (value == 1)
                {
                    int Member_detail_bapid_updated = objBaptismBLL.Update_bapid_MemberDetails(objBaptismBO);
                }
            }
            else if ((marriedstatus.Checked) == false && b == 1 && (parishmember.Checked) == true && (newborn.Checked)==false) // me  not married,parishmember and parents this parish
            {
                objBaptismBO.Familyname = TBFamilyName.Text;
                objBaptismBO.PersonParishname = TBParishName.Text;
                objBaptismBO.Officialname = TBOfficialName.Text;
                objBaptismBO.Baptismname = TBBaptismName.Text;
                objBaptismBO.Fathername = TBFatherName.Text;
                objBaptismBO.Mothername = TBMotherName.Text;
                string a = Dobhidden.Value.ToString();
                DateTime oDate = DateTime.Parse(a);
                string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                objBaptismBO.Do_Baptism = dob;
                objBaptismBO.Father_BapName = TBFatherBapName.Text;
                objBaptismBO.Mother_BapName = TBMotherBapName.Text;
                objBaptismBO.GodFatherName = TBGodfatherName.Text;
                objBaptismBO.GodMotherName = TBGodmotherName.Text;
                objBaptismBO.GFatherProof = "";
                objBaptismBO.GMotherProof = "";
                objBaptismBO.FatherProof = "";
                objBaptismBO.MotherProof = "";
                objBaptismBO.gender = DDLGender.SelectedValue;
                objBaptismBO.vicar = TBParishPriestName.Text;
                objBaptismBO.celebrant = TBCelebrantName.Text;
                objBaptismBO.isParishMember = 1;
                objBaptismBO.Baptism_Status = 1;

                string fileName = string.Empty;

                if (Fileuploadurcertificate.HasFile)
                {

                    fileName = Fileuploadurcertificate.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    Fileuploadurcertificate.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.Ur_BapProof = fileName;
                }
                else
                {
                    objBaptismBO.Ur_BapProof = "";
                }
                int value = objBaptismBLL.InsertBaptism_details(objBaptismBO);
                if (value == 1)
                {
                    int Member_detail_bapid_updated = objBaptismBLL.Update_bapid_MemberDetails(objBaptismBO);
                }
            }
            else if ((marriedstatus.Checked) == false && b == 1 && (parishmember.Checked) == true && newborn.Checked) // newborn,is parishmember and parents this parish
            {

                
                objBaptismBO.Familyname = TBFamilyName.Text;
                objBaptismBO.PersonParishname = TBParishName.Text;
                objBaptismBO.Officialname = TBOfficialName.Text;
                objBaptismBO.Baptismname = TBBaptismName.Text;
                objBaptismBO.Fathername = TBFatherName.Text;
                objBaptismBO.Mothername = TBMotherName.Text;
                objBaptismBO.Do_Baptism = "";
                objBaptismBO.Ur_BapProof = "";
                objBaptismBO.Father_BapName = TBFatherBapName.Text;
                objBaptismBO.Mother_BapName = TBMotherBapName.Text;
                objBaptismBO.GodFatherName = TBGodfatherName.Text;
                objBaptismBO.GodMotherName = TBGodmotherName.Text;
                objBaptismBO.FatherProof = "";
                objBaptismBO.MotherProof = "";
                objBaptismBO.gender = DDLGender.SelectedValue;
                objBaptismBO.vicar = TBParishPriestName.Text;
                objBaptismBO.celebrant = TBCelebrantName.Text;
                objBaptismBO.isParishMember = 1;
                objBaptismBO.Baptism_Status = 0;

                string fileName = string.Empty;

                if (FileuploadGF.HasFile)
                {

                    fileName = FileuploadGF.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    FileuploadGF.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.GFatherProof = fileName;
                }
                else
                {
                    objBaptismBO.GFatherProof = "";
                }

                if (FileuploadGM.HasFile)
                {

                    fileName = FileuploadGM.FileName; //gets full path name in filename
                    fileName = "~/Project_Code/People/PeopleImage/" + fileName;
                    FileuploadGM.SaveAs(Server.MapPath(fileName));
                    objBaptismBO.GMotherProof = fileName;
                }
                else
                {
                    objBaptismBO.GMotherProof = "";
                }
                int value = objBaptismBLL.InsertBaptism_details(objBaptismBO);
                if (value == 1)
                {
                    RequestBO objRequestBO=new RequestBO();
                    objRequestBO.Event_Name1 = "Baptism";
                    objRequestBO.Memberid1 = objBaptismBO.Member_id;
                    objRequestBO.Parishid1 = objBaptismBO.To_Parish_id;
                    objRequestBO.RequestStatus = 0;

                    string currentdate = Convert.ToDateTime(DateTime.Now.ToLongDateString()).ToString("dd/MM/yyyy");//system date
                    objRequestBO.RequestDate1 = currentdate;
                    string time = DateTime.Now.ToString("h:mm:ss tt");//system time

                    objRequestBO.RequestTime1 = time;
                    objRequestBO.RequestStatus_Description1 = "";

                    string a = Dobhidden.Value.ToString();
                    DateTime oDate = DateTime.Parse(a);
                    string dob = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
                    objRequestBO.ProposedDateOfBap1 = dob;
                    objRequestBO.ProposedTimeOfBap1 = TBBapTime.Text;

                    int insert_Request = objBaptismBLL.BaptismRequest(objRequestBO);
                   // int Member_detail_bapid_updated = objBaptismBLL.Update_bapid_MemberDetails(objBaptismBO);
                }



            }
            Response.Redirect("ViewFamilyMembers.aspx");
        }

        protected void LnkbtnHome_Click(object sender, EventArgs e)
        {
            if(objBaptismBO.Usertype==3)
            { 
            Response.Redirect("MemberHome.aspx");
            }
            else if(objBaptismBO.Usertype == 4)
            {
                Response.Redirect("NonMemberHome.aspx");
            }
        }
    }
}