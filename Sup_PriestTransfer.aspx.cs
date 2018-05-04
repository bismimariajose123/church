using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class Sup_PriestTransfer : System.Web.UI.Page
    {
        Priest_TransferBO objPriestTransfer_BO = new Priest_TransferBO();
        Priest_Transfer_BLL objPriestTransfer_BLL = new Priest_Transfer_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Data_Concate_inDDL();
            }
        }

        protected void BtnPriest_Transfer_Click(object sender, EventArgs e)
        {

            objPriestTransfer_BO.PriestID = Convert.ToInt32(DDLPriestName.SelectedValue);
            objPriestTransfer_BO.ParishID = Convert.ToInt32(DDLParishName.SelectedValue);
            string designation = TBDesignation.Text;
            int result=objPriestTransfer_BLL.Save_PreistTransfer_Details(objPriestTransfer_BO,designation);
            Response.Redirect("Sup_PriestTransfer.aspx");

        }
        public void Data_Concate_inDDL()
        {
            DataTable dt = new DataTable();
            dt = objPriestTransfer_BLL.Priest_Parish_Ddlist();
            DDLParishName.DataSource = dt;
            //DDLParishName.DataTextField = "Creator";
            DDLParishName.DataTextField = "Parish_Name";
            DDLParishName.DataValueField = "Parish_ID";
            DDLParishName.DataBind(); 
        }
    }
}