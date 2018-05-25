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

        public int UpdateMember_Request(RequestBO objRequestBO, int id)
        {
            return objRequestDAL.UpdateMember_Request(objRequestBO, id);
        }

        public int DownloadBaptismForm(int memberid)
        {
            return objRequestDAL.DownloadBaptismForm(memberid);
        }

        public DataTable GeneratePdfBaptism(int memberid)
        {
            return objRequestDAL.GeneratePdfBaptism(memberid);


        }

        //public int Delete_MemberRequest(int id)
        //{
        //    return objRequestDAL.Delete_MemberRequest(id);
        //}
    }
}