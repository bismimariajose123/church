using Diocese.Project_Code.SuperAdmin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class AddPriest : System.Web.UI.Page
    {
        Parish_Priest_BO ObjPP_BO = new Parish_Priest_BO();
        Parish_Priest_BLL ObjPP_BLL = new Parish_Priest_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void PriestAdd_Click(object sender, EventArgs e)
        {
            string fileName = string.Empty;
            if (FileUploadimg.HasFile)
            {

                fileName = FileUploadimg.FileName; //gets full path name in filename
                fileName = "~/Project_Code/SuperAdmin/Priest_Images/" + fileName;
                FileUploadimg.SaveAs(Server.MapPath(fileName));
            }
            ObjPP_BO.PPName = TBPriestName.Text;
            ObjPP_BO.P_Designation ="";
            ObjPP_BO.PPImage = fileName;
            ObjPP_BO.NativePlace = TBNativeParish.Text;
            string a = HidOrdinanceDate.Value.ToString();
            DateTime oDate = DateTime.Parse(a);
            string d = Convert.ToDateTime(oDate.ToLongDateString()).ToString("dd/MM/yyyy"); //returns 25/09/2011
            ObjPP_BO.Ordination_Date = d;
            ObjPP_BO.Contact = TBContactNumber.Text;
            int result = ObjPP_BLL.Insert_Priest_Detail(ObjPP_BO);
            Response.Redirect("AddPriest.aspx");
        }
    }
}