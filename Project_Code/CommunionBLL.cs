using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class CommunionBLL
    {
        CommunionDAL objCommunionDAL = new CommunionDAL();
        public int AddCommunionRequest(CommunionBO objCommunionBO,int parishid)
        {
            return objCommunionDAL.AddCommunionRequest(objCommunionBO,parishid);
        }

        public int Delete_CommunionDetails(int id)
        {
            return objCommunionDAL.Delete_CommunionDetails(id);
        }

        public DataTable Get_SearchCommunionDetails(CommunionBO objCommunionBO)
        {
            return objCommunionDAL.Get_SearchCommunionDetails(objCommunionBO);
        }

        public DataTable Load_data(int parishid)
        {
            return objCommunionDAL.Load_data(parishid);
        }

        public int count_of_Male(int parishid)
        {
            return objCommunionDAL.count_of_Male(parishid);
        }

        public string getPriestname(int parishid)
        {
            return objCommunionDAL.getPriestname(parishid);
        }

        public int count_of_Female(int parishid)
        {
            return objCommunionDAL.count_of_Female(parishid);
        }
    }
}