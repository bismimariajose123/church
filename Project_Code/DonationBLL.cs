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

        public DataTable Load_DonationIncome(int parishid) //load into gv
        {
           return  objDonationDAL.Load_DonationIncome(parishid);
        }

        public void Update_ispayed_inDonation(int userid, int usertype,int parishid)
        {
             objDonationDAL.Update_ispayed_inDonation(userid, usertype, parishid);
        }

        public DataTable LoadHall(int parishid)
        {
            return objDonationDAL.LoadHall(parishid);
        }

        public DataTable LoadEventDDl(int parishid)
        {
            return objDonationDAL.LoadEventDDl(parishid);
        }

        public DataTable Get_Search_IncomeDetails(string searchstr,int parishid)  //BTN SEARCH(A)
        {
            return objDonationDAL.Get_Search_IncomeDetails(searchstr, parishid);
        }

        public string Display_TotalAmount(int parishid)    //display total amount
        {
            return objDonationDAL.Display_TotalAmount(parishid);
        }

        public DataTable Load_DonationIncome_Onedate1(DateTime date1, int parishid) //date1parishid (2a)
        {
            return objDonationDAL.Load_DonationIncome_Onedate1(date1, parishid);
        }

        public DataTable Load_DonationIncome_TwoDate(DateTime oDate, DateTime oDate1, int parishid) //date1+date2+parishid (3a)
        {
            return objDonationDAL.Load_DonationIncome_TwoDate(oDate, oDate1, parishid);
        }

        public string DisplaySearchedString_TotalAmount(int parishid, DateTime date1) //date1+parishid (2b)
        {
            return objDonationDAL.DisplaySearchedString_TotalAmount(parishid, date1);
        }

        public string DisplayTwoDatesBased_TotalAmount(int parishid, DateTime date1, DateTime date2) //date1+date2+parishid (3a)
        {
            return objDonationDAL.DisplayTwoDatesBased_TotalAmount(parishid, date1, date2);
        }

 //       public DataTable Load_DonationIncome_Two_date_string(DateTime date1, DateTime date2, int parishid, string searchstr) //IMAGEBTN SEARCH //string+date1+date2+parishid (1b)
 //    {
 //           return objDonationDAL.Load_DonationIncome_Two_date_string(date1, date2,parishid,searchstr)
 //;
 //       }

        //public string DisplayTwoDatesBasedString_TotalAmount(int parishid, DateTime date1, DateTime date2, string searchstr) //IMAGEBTN SEARCH //string+date1+date2+parishid (1a)
        //{
        //    return objDonationDAL.DisplayTwoDatesBasedString_TotalAmount(parishid, date1, date2, searchstr);
        //}

        internal DataTable Get_Search_Str(string searchstr, int parishid) //IMAGEBTN SEARCH
        {
            return objDonationDAL.Get_Search_Str(searchstr, parishid);
        }

        public string Search_Event(int parishid, int eventid,String eventName)  //BTN SEARCH(A)
        {
            return objDonationDAL.Search_Event(parishid, eventid, eventName);
        }

        public string Get_Search_TotalAmount(string searchstr, int parishid)  //BTN SEARCH(A)   
        {
            return objDonationDAL.Get_Search_TotalAmount(searchstr, parishid);
        }

        public DataTable LoadEvent_search(int parishid, int eventid)  //BTN SEARCH(A)
        {
            return objDonationDAL.LoadEvent_search(parishid, eventid);
        }

        public string DisplayTwoDatesBasedEventName_TotalAmount(int parishid, DateTime oDate, DateTime oDate1, int eventid,String eventName)  //BTN SEARCH(A)
        {
            return objDonationDAL.DisplayTwoDatesBasedEventName_TotalAmount(parishid, oDate, oDate1, eventid, eventName);
        }

       

        public DataTable Load_DonationIncome_Twodate_EventName(DateTime oDate, DateTime oDate1, int parishid, int eventid,String eventName)  //BTN SEARCH(A)
        {
            return objDonationDAL.Load_DonationIncome_Twodate_EventName(oDate, oDate1, parishid, eventid, eventName);
        }
    }
}