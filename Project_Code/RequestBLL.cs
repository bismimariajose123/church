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
    }
}