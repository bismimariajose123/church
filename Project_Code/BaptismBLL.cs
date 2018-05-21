using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class BaptismBLL
    {
        BaptismDAL objBaptismDAL = new BaptismDAL();
        public BaptismBO Load_MemberData(BaptismBO objBaptismBO)
        {
            return objBaptismDAL.Load_MemberData(objBaptismBO);
        }

        public int InsertBaptism_details(BaptismBO objBaptismBO)
        {
            return objBaptismDAL.InsertBaptism_details(objBaptismBO);
        }

        public int Update_bapid_MemberDetails(BaptismBO objBaptismBO)
        {
            return objBaptismDAL.Update_bapid_MemberDetails(objBaptismBO);
        }

        public int BaptismRequest(RequestBO objRequestBO)
        {
            return objBaptismDAL.BaptismRequest(objRequestBO);
        }

        public DataTable GEt_BapDetails(int id)
        {
            return objBaptismDAL.GEt_BapDetails(id);
        }
    }
}