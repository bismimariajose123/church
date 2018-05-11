using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class LoginBLL
    {
       // LoginDAL objLoginDAL = new LoginDAL();
        LoginDAL2 objLoginDAL2 = new LoginDAL2();

        public int CheckLogin(LoginBO objLoginBO)
        {
            // return objLoginDAL.CheckLogin(objLoginBO);

            return objLoginDAL2.CheckLogin(objLoginBO);
        }
    }
}