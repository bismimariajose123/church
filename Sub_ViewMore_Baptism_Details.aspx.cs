using Diocese.Project_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Diocese
{
    public partial class Sub_ViewMoreDetails : System.Web.UI.Page
    {
        BaptismBO objBaptismBO = new BaptismBO();
        BaptismBLL objBaptismBLL = new BaptismBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_Baptism_data();
            }
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubAdminNotification.aspx");
        }

        public void Load_Baptism_data()
        {
            int id = Convert.ToInt32(Session["SubAdmin_viewDetails_memberid"]);
            int isparishmember = Convert.ToInt32(Session["isparishmember"]);
            DataTable dt = new DataTable();
            dt = objBaptismBLL.GEt_BapDetails(id, isparishmember);
            if (dt.Rows.Count > 0)
            {
                ListView1.DataSource = dt;
                ListView1.DataBind();
                PanelImage.Controls.Add(ListView1);

            }
            else
            {
                Response.Write("<script>alert('None data');</script>");
            }
        }
       

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                DataRowView drv = (DataRowView)dataItem.DataItem;
                //LinkButton gfproof = (LinkButton)e.Item.FindControl("LnkbtnGFproof");
                //LinkButton gmproof = (LinkButton)e.Item.FindControl("LnkbtnGMproof");
                //LinkButton fproof = (LinkButton)e.Item.FindControl("LnkbtnFproof");
                //LinkButton mproof = (LinkButton)e.Item.FindControl("LnkbtnMproof");
                //LinkButton urproof = (LinkButton)e.Item.FindControl("Lnkbtnurproof");

                HtmlGenericControl GF = (e.Item.FindControl("GF") as HtmlGenericControl);
                HtmlGenericControl GM = (e.Item.FindControl("GM") as HtmlGenericControl);
                HtmlGenericControl F = (e.Item.FindControl("F") as HtmlGenericControl);
                HtmlGenericControl M = (e.Item.FindControl("M") as HtmlGenericControl);
                HtmlGenericControl ur = (e.Item.FindControl("ur") as HtmlGenericControl);

                string gfproof = drv["GFProof"].ToString();
                string gmproof = drv["GMProof"].ToString();
                string fproof = drv["FProof"].ToString();
                string mproof = drv["MProof"].ToString();
               string urproof = drv["UrBapProof"].ToString();
                

                //gfproof.Text = drv["GFProof"].ToString();
                //gmproof.Text = drv["GMProof"].ToString();
                //fproof.Text = drv["FProof"].ToString();
                //mproof.Text = drv["MProof"].ToString();
                //urproof.Text = drv["UrBapProof"].ToString();
                if (gfproof==string.Empty && gmproof==string.Empty)
                {
                    GF.Visible = false;
                    GM.Visible = false;
                }
                else
                {
                    GF.Visible = true;
                    GM.Visible = true;
                   
                }

                if (fproof == string.Empty && mproof == string.Empty)
                {
                    F.Visible = false;
                    M.Visible = false;
                }
                else
                {
                    F.Visible = true;
                    M.Visible = true;
                }
                if (urproof == string.Empty)
                {
                    ur.Visible = false;
                   
                }
                else
                {
                    ur.Visible = true;
                }

            }
              }
    }
}