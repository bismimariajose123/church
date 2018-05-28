using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class DonationBLL
    {
        DonationDAL objDonationDAL = new DonationDAL();
        public int DonationAmount(DonationBO objDonationBO)
        {
            return objDonationDAL.DonationAmount(objDonationBO);
        }



        public DataTable LoadEvent(int parishid)
        {
            return objDonationDAL.LoadEvent(parishid);
        }

        public DataTable Load_DonationIncome(int parishid)
        {
           return  objDonationDAL.Load_DonationIncome(parishid);
        }

        public void Update_ispayed_inDonation(int userid, int usertype)
        {
             objDonationDAL.Update_ispayed_inDonation(userid, usertype);
        }

        public DataTable Get_Search_IncomeDetails(string searchstr,int parishid)
        {
            return objDonationDAL.Get_Search_IncomeDetails(searchstr, parishid);
        }
    }
}