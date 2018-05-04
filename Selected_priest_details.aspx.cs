using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class Selected_priest_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                load();
            }
        }
        public void load()
        {
            ListView2.DataSource = Session["datatable"];
            ListView2.DataBind();
        }
    }
}