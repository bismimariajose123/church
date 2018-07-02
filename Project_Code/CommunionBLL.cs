using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class CommunionBLL
    {
        CommunionDAL objCommunionDAL = new CommunionDAL();
        public int AddCommunionRequest(CommunionBO objCommunionBO, int usertype, int parishid, int familyid)
        {
            return objCommunionDAL.AddCommunionRequest(objCommunionBO, usertype, parishid, familyid);
        }
    }
}