using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class SuperAdminBLL
    {
        SuperAdminDAL objSuperAdminDAL = new SuperAdminDAL();

        public int AddSuperAdmin(SuperAdminBO objSuperAdminBO)
        {
            return objSuperAdminDAL.AddSuperAdmin(objSuperAdminBO);
        }
    }
}