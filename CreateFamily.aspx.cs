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
    public partial class CreateFamily : System.Web.UI.Page
    {
        FamilyBO objFamilyBO = new FamilyBO();
        FamilyBLL objFamilyBLL = new FamilyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            objFamilyBO.parish_id = Convert.ToInt32(Session["parishid"].ToString());

            if (!IsPostBack)
            {
                Load_FamilyNo();
                Load_WardName();
            }
        }
        public void Load_FamilyNo()
        {
            objFamilyBO = objFamilyBLL.GetFamilyNo(objFamilyBO);
            TBFamilyNbr.Text = objFamilyBO.Familyno.ToString();
        }
        public void Load_WardName()
        {
            DataTable dt = new DataTable();
            dt=objFamilyBLL.GetWardName(objFamilyBO);
            DDLWardName.DataTextField = "WardName";
            DDLWardName.DataValueField = "Ward_ID";
            DDLWardName.DataSource = dt;
            DDLWardName.DataBind();
        }

        protected void BtnCreateFamily_Click(object sender, EventArgs e)
        {
            objFamilyBO.familyname = TBFamilyName.Text;
            objFamilyBO.ward_id = Convert.ToInt32(DDLWardName.SelectedValue);
            objFamilyBO.parish_id= Convert.ToInt32(Session["parishid"].ToString());
            objFamilyBO.username = TBUname.Text;
            objFamilyBO.password = TBPass.Text;
            objFamilyBO.Familyno = Convert.ToInt32(TBFamilyNbr.Text);
            objFamilyBO.ContactNo = TBContactNo.Text;
            objFamilyBO.Headname = TBHeadName.Text;
            int result = objFamilyBLL.AddFamily(objFamilyBO);
            
           Response.Redirect("CreateFamily.aspx");
           
        }
        
    }
}