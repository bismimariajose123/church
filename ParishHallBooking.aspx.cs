using Diocese.Project_Code;
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
    public partial class ParishHallBooking : System.Web.UI.Page
    {
        DonationBLL objDonationBLL = new DonationBLL();
        Parish_HallBO objParish_HallBO = new Parish_HallBO();
        Parish_HallBLL objParish_HallBLL = new Parish_HallBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());
            if (!IsPostBack)
            {
                LoadEventDDl();
                LoadHall();
                LoadMemberDetails();
            }
        }
        public void LoadMemberDetails()
        {
            objParish_HallBO = new Parish_HallBO();
            int usertype = Convert.ToInt32(Session["usertype"]);
            if(usertype==3)//member
            {
                int familyid = Convert.ToInt32(Session["family_id"]);
               
                List<string> list= objParish_HallBLL.FillMemberDetails(familyid, usertype);
                TBFamilyName.Text = list.ElementAt(0);
                TBParishName.Text = list.ElementAt(1);
                TBdiocese.Text = "Thalasery";
            }
           
        }
        public void LoadHall()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());

            DataTable dt = objDonationBLL.LoadHall(parishid);

            DDLHallName.DataSource = dt;
            DDLHallName.DataTextField = "HallName";
            DDLHallName.DataValueField = "Hall_ID";
            DDLHallName.DataBind();
          
        }
        public void LoadEventDDl()
        {
            int parishid = Convert.ToInt32(Session["parishid"].ToString());

            DataTable dt = objDonationBLL.LoadEventDDl(parishid);
            DDLEventName.DataSource = dt;
            DDLEventName.DataTextField = "EventName";
            DDLEventName.DataValueField = "EventId";
            DDLEventName.DataBind();
        }

        protected void DDLHallName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblHallRate_Capacity.Visible = true;
          
            int parishid= Convert.ToInt32(Session["parishid"].ToString());
            int hallid= Convert.ToInt32(DDLHallName.SelectedValue);

            objParish_HallBO = new Parish_HallBO();
            objParish_HallBO = objParish_HallBLL.GetParishHallDetails(hallid);


            LblHallRate_Capacity.Text = "Hall Nobr ("+objParish_HallBO.hallno+") Capacity ("+objParish_HallBO.People_count+") Rate ("+objParish_HallBO.rate+")";
        }

        protected void BtnHallRequest_Click(object sender, EventArgs e)
        {
            objParish_HallBO.Hallid1 = Convert.ToInt32(DDLHallName.SelectedValue);
            objParish_HallBO.Usertype = Convert.ToInt32(Session["usertype"]);

            if(objParish_HallBO.Usertype==3)
            {
               objParish_HallBO.Userid = Convert.ToInt32(Session["family_id"]);
             }
            else
            {
                objParish_HallBO.Userid = Convert.ToInt32(Session["nonmember_id"]);
            }
            objParish_HallBO.Eventid1 = Convert.ToInt32(DDLEventName.SelectedValue);
           
            objParish_HallBO.OfficialName1 = TBOfficialName.Text;
            DateTime created_date = DateTime.Now;
            string h = created_date.ToString();
            DateTime i = Convert.ToDateTime(h.Substring(0, 9));
            objParish_HallBO.RequestDate1 = i;
            objParish_HallBO.parishid= Convert.ToInt32(Session["parishid"].ToString());
            objParish_HallBO.Status = 1;
            objParish_HallBO.Description = "";
            int result = objParish_HallBLL.AddHallRequest(objParish_HallBO);
            Response.Redirect("ParishHallBooking.aspx");
        }

    }
}