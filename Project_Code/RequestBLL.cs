using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class RequestBLL
    {
        RequestDAL objRequestDAL = new RequestDAL();
        public DataTable GetNotificationDetails(RequestBO objRequestBO)
        {
            return objRequestDAL.GetNotificationDetails(objRequestBO);
        }

        public int Delete_Request(int id)
        {
            return objRequestDAL.Delete_Request(id);
        }

        public int UpdateRequest(RequestBO objRequestBO, int id)
        {
            return objRequestDAL.UpdateRequest(objRequestBO, id);
        }

        public DataTable GetMemberNotificationDetails(RequestBO objRequestBO)
        {
            return objRequestDAL.GetMemberNotificationDetails(objRequestBO);
        }

        public object GetNon_MemberNotificationDetails(RequestBO objRequestBO)
        {
            return objRequestDAL.GetNon_MemberNotificationDetails(objRequestBO);
        }

        public int UpdateMember_Request(RequestBO objRequestBO, int id) //member update request
        {
            return objRequestDAL.UpdateMember_Request(objRequestBO, id);
        }

        public int DownloadBaptismForm(int memberid,int isparishmember)
        {
            return objRequestDAL.DownloadBaptismForm(memberid, isparishmember);
        }

        public DataTable GeneratePdfBaptism(int memberid, int isparishmember, int requsetid)
        {
            return objRequestDAL.GeneratePdfBaptism(memberid,isparishmember,requsetid);


        }

        public int UpdateNon_Member_Request(RequestBO objRequestBO, int id) //non member update request
        {
            return objRequestDAL.UpdateNon_Member_Request(objRequestBO, id);
        }

        public DataTable Get_Search_FamilyDetails(RequestBO objRequestBO, string searchstr)
        {
            return objRequestDAL.Get_Search_FamilyDetails(objRequestBO, searchstr);
        }

        //public int Delete_MemberRequest(int id)
        //{
        //    return objRequestDAL.Delete_MemberRequest(id);
        //}
    }
}