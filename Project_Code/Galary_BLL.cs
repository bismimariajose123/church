using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class Galary_BLL
    {
        GalaryDAL objGalary_DAL = new GalaryDAL();
        public DataTable Get_Priest_Images()
        {
           return objGalary_DAL.Get_Priest_Images();
        }

       

        public DataTable Get_Clicked_Priest_Detail(int priestid)
        {
            return objGalary_DAL.Get_Clicked_Priest_Detail(priestid);
        }
    }
}