using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class LoginBLL
    {
        LoginDAL objLoginDAL = new LoginDAL();


        public int CheckLogin(LoginBO objLoginBO)
        {
            int result;
            DataTable dt = objLoginDAL.CheckLogin(objLoginBO);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == objLoginBO.username && dt.Rows[0][1].ToString() == objLoginBO.Pwd && Convert.ToInt32(dt.Rows[0][2].ToString()) == Convert.ToInt32(objLoginBO.Parishid))
                    {

                        result = 2;
                    }

                    else
                    {
                        result = 0;
                    }
                   
                }
                else
                {
                     result=0; 
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}