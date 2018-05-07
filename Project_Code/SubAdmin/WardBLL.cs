using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class WardBLL
    {
        WardDAL objWardDAL = new WardDAL();

        public int AddWard(WardBO objWardBO)
        {
            return objWardDAL.AddWard(objWardBO);
        }

        public DataTable GetWardDetails(WardBO objWardBO)
        {
            return objWardDAL.GetWardDetail(objWardBO);
        }

        public int Delete_Ward(int id)
        {
            return objWardDAL.Delete_Ward(id);
        }

        public int UpdateWard(WardBO objWardBO, int id)
        {
            return objWardDAL.UpdateWard(objWardBO, id);
        }

        public DataTable Get_Search_WardDetails(WardBO objWardBO, string searchstr)
        {
            return objWardDAL.Get_Search_WardDetails(objWardBO,searchstr);
        }
    }
}