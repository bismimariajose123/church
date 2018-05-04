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
    public partial class PriestGalary : System.Web.UI.Page
    {
        Galary_BLL objGalary_BLL = new Galary_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    Load_Image();
            //}
            Load_Image();
        }
        public void Load_Image()
        {
            DataTable dt = new DataTable();
            dt = objGalary_BLL.Get_Priest_Images();
            ListView1.DataSource = dt;
            ListView1.DataBind();
            PanelImage.Controls.Add(ListView1);
            //PanelImage.Style.Add("padding", "5px");
        }

        public void Gal_Image_Click(int priestid)
        {
            DataTable dt = new DataTable();
            dt = objGalary_BLL.Get_Clicked_Priest_Detail(priestid);
            Session["datatable"] = dt;
            Response.Redirect("Selected_priest_details.aspx");
            
            
        }

        protected void Gal_Image_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Priest")
            {
                string id = e.CommandArgument.ToString();

                int priest_id = Convert.ToInt32(id);
                Gal_Image_Click(priest_id);
            }
        }

        
    }
}