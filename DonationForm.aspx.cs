using Diocese.Project_Code;
using System;
using System.Collections.Generic;
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

        }

        protected void BtnDonation_Click(object sender, EventArgs e)
        {
            objDonationBO.FamilyName1 = TBFamilyName.Text;
            objDonationBO.Persons_ParishName1 = TBParishName.Text;
            objDonationBO.OfficialName1 = TBOfficialName.Text;
            objDonationBO.Gender1 = Convert.ToInt32(DDLGender.SelectedValue);
            objDonationBO.ContactNo1 = TBContactNobr.Text;
            objDonationBO.Diocese1 = TBdiocese.Text;
            objDonationBO.EventName1 = Convert.ToInt32(DDLEventName.SelectedValue);
            objDonationBO.ToParishid1 =;
            objDonationBO.Memberid1 =;
            objDonationBO.IsParishMember1 =;
            objDonationBO.Amount1 = TBAmount.Text;
            objDonationBO.AmountReceivedDate1 = DateTime.Now;
        }
    }
}