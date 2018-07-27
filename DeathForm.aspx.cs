using Diocese.Project_Code.People;
using Diocese.Project_Code.SubAdmin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class DeathForm : System.Web.UI.Page
    {
        FamilyBO objFamilyBO = new FamilyBO();
        FamilyBLL objFamilyBLL = new FamilyBLL();
        WardBO objWardBO = new WardBO();
        WardBLL objWardBLL = new WardBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetWardDetail();
            }
           
        }
        public void Load_FamilyName(int wardid)
        {

            objFamilyBO.parish_id = Convert.ToInt16(Session["parishid"]);
            objFamilyBO.ward_id = wardid;
            DataTable dt;
            dt = objFamilyBLL.getFamilyName(objFamilyBO);
            if(dt.Rows.Count>0)
            { 
            Session["Dt"] = dt;
            DDlFamilyName.DataSource = dt;
            DDlFamilyName.DataTextField = "FamilyName";
            DDlFamilyName.DataValueField = "Family_ID";
            DDlFamilyName.DataBind();
            }
            else
            {
                 Response.Write("<script>alert('No members')</script>");
               // GetWardDetail();
            }
        }
        public void GetWardDetail()
        {
            objWardBO.Parish_id = Convert.ToInt16(Session["parishid"]);
            DataTable dt;
            dt = objWardBLL.GetWardDetails(objWardBO);
            Session["Dt"] = dt;
            DDlWardName.DataSource = dt;
            DDlWardName.DataTextField = "WardName";
            DDlWardName.DataValueField = "Ward_ID";
            DDlWardName.DataBind();
        }

        protected void DDlWardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int wardid = Convert.ToInt32(DDlWardName.SelectedItem.Value);
            Load_FamilyName(wardid);
        }

        protected void DDlFamilyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            int familyid = Convert.ToInt32(DDlFamilyName.SelectedItem.Value);
            int wardid = Convert.ToInt32(DDlWardName.SelectedItem.Value);
            int Parish_id = Convert.ToInt16(Session["parishid"]);

            Load_MemberDetails(familyid, wardid, Parish_id);
        }

        private void Load_MemberDetails(int familyid, int wardid, int parish_id)
        {
            //not done
            MemberBLL objMemberBLL = new MemberBLL();
            DataTable dt= objMemberBLL.Load_MemberDetails(familyid, wardid, parish_id);
            DDLOfficialName.DataSource = dt;
            DDLOfficialName.DataTextField = "OfficialName";
            DDLOfficialName.DataValueField = "Member_ID";
            DDLOfficialName.DataBind();
        }

        
        protected void LnkbtnHome_Click(object sender, EventArgs e)
        {
          
                Response.Redirect("SubAdminHome.aspx");
        
          
        }

        protected void Btndeath_Click(object sender, EventArgs e)
        {
            int memberid = Convert.ToInt32(DDLOfficialName.SelectedItem.Value);
          
            int Parish_id = Convert.ToInt16(Session["parishid"]);

            DeathBO objDeathBO = new DeathBO();
            DeathBLL objDeathBLL = new DeathBLL();
            objDeathBO.DO_Death1 = Dodeathhidden.Value;
            objDeathBO.Do_Funeral1 = Hiddenfield1.Value;
            objDeathBO.FuneralTime1 = TBFuneralTime.Text;
            objDeathBO.Gender1 = Convert.ToInt32(DDLGender.SelectedValue);
            objDeathBO.Parish_id1 = Parish_id;
            objDeathBO.Member_id1=memberid;
            objDeathBO.OfficialName1 = DDLOfficialName.SelectedItem.ToString();
            int result=objDeathBLL.addDeathREcord(objDeathBO);
            if(result==1)
            {
                Response.Write("<script>alert('inserted successfully')</script>");
                Response.Redirect("SubAdminHome.aspx");
            }
        }
    }
}