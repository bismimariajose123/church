using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ResponsibilityBLL
    {
        ResponsibilityDAL objResponsibilityDAL = new ResponsibilityDAL();

        public int AddResponsibility(ResponsibilityBO objResponsibilityBO)   //ADD RESPONSIBILITY(1)
        {
            return objResponsibilityDAL.AddResponsibility(objResponsibilityBO);
        }
    }
}