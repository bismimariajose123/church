using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class DeathBLL
    {
        DeathDAL objDeathDAL = new DeathDAL();
        public int addDeathREcord(DeathBO objDeathBO)
        {
            return objDeathDAL.addDeathREcord(objDeathBO);
        }

        public DataTable GetDeathDetails(int parishid)
        {
            return objDeathDAL.GetDeathDetails(parishid);
        }

        public DataTable Get_Search_DeathDetails(int parishid, string searchstr)
        {
            return objDeathDAL.Get_Search_DeathDetails(parishid, searchstr);
        }
    }
}