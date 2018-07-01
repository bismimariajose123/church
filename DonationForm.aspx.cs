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
    public partial class DonationForm : System.Web.UI.Page
    {
        DonationBO objDonationBO = new DonationBO();
        DonationBLL objDonationBLL = new DonationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                Load_Event();
            }
        }
        public void Load_Event()
        {
            int parishid= Convert.ToInt32(Session["parishid"].ToString());
            DataTable dt = objDonationBLL.LoadEvent(parishid);
            DDLEventName.DataSource = dt;
            DDLEventName.DataTextField = "EventName";
            DDLEventName.DataValueField = "EventId";
            DDLEventName.DataBind();

        }

        protected void BtnDonation_Click(object sender, EventArgs e)
        {
           
            int usertype = Convert.ToInt32(Session["usertype"].ToString());
            objDonationBO.FamilyName1 = TBFamilyName.Text;
            objDonationBO.Persons_ParishName1 = TBParishName.Text;
            objDonationBO.OfficialName1 = TBOfficialName.Text;
            objDonationBO.Gender1 = Convert.ToInt32(DDLGender.SelectedValue);
            objDonationBO.ContactNo1 = TBContactNobr.Text;
            objDonationBO.Diocese1 = TBdiocese.Text;
            objDonationBO.EventName1 = Convert.ToInt32(DDLEventName.SelectedValue);
            objDonationBO.ToParishid1 = Convert.ToInt32(Session["parishid"].ToString());
            if(usertype==4)
            {
               
                objDonationBO.Memberid1 = Convert.ToInt32(Session["nonmember_id"].ToString());
                objDonationBO.IsParishMember1 =0;
                Session["userid"] = objDonationBO.Memberid1;//for donation
                Session["usertype_donation"] = 4;
            }
            else if(usertype==3)
            {
                objDonationBO.Memberid1 = Convert.ToInt32(Session["family_id"].ToString());//familyid
                objDonationBO.IsParishMember1 = 1;
                Session["userid"] = objDonationBO.Memberid1;//for donation
                Session["usertype_donation"] = 3;
            }
            
            objDonationBO.Amount1 = Convert.ToInt64(TBAmount.Text);
            DateTime created_date = DateTime.Now;
            string h = created_date.ToString();
            DateTime i = Convert.ToDateTime(h.Substring(0, 9));

            // string date_joined = Convert.ToDateTime(created_date.ToLongDateString()).ToString("dd/MM/yyyy");

            objDonationBO.AmountReceivedDate1 = i;
            objDonationBO.BalanceAmount1 = objDonationBO.Amount1;
            Session["Amount"]= TBAmount.Text;
           
            int result = objDonationBLL.DonationAmount(objDonationBO);
            if(result==1)
            {
                Response.Redirect("Paymentgateway.aspx");
            }
        }

        protected void LnkbtnHome_Click(object sender, EventArgs e)
        {
            int usertype = Convert.ToInt32(Session["usertype"].ToString());
            if (usertype == 3)
            {
                Response.Redirect("MemberHome.aspx");
            }
            else if (usertype == 4)
            {
                Response.Redirect("NonMemberHome.aspx");
            }
        }
    }
}