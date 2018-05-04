using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Sub_admin_LoginBLL
    {
        Sub_admin_LoginDAL obj_Sub_admin_LoginDAL = new Sub_admin_LoginDAL();
        public int Add_sub_admin_login(Sub_admin_LoginBO obj_Sub_admin_LoginBO)
        {
            return obj_Sub_admin_LoginDAL.Add_sub_admin_login(obj_Sub_admin_LoginBO);
        }
    }
}
