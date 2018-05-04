using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Parish_Priest_BLL
    {
        Parish_Priest_DAL ObjPP_DAL = new Parish_Priest_DAL();
        public int Insert_Priest_Detail(Parish_Priest_BO objPP_BO)
        {
            return ObjPP_DAL.Insert_Priest_Information(objPP_BO);
        }

        public DataTable GetPriestDetails()
        {
            return ObjPP_DAL.Get_Priest_Information();
        }

        public DataTable GetPriest_NOT_Transfer_Details()
        {
            return ObjPP_DAL.GetPriest_NOT_Transfer_Details();
        }

        public int Delete_Parish(int id)
        {
            try { 
                  return ObjPP_DAL.Delete_Priest_Information(id);
                }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
        public DataTable Get_Search_PriestDetails(string searchstr)
        {
            return ObjPP_DAL.Get_Search_PriestInformation(searchstr);
        }
        public DataTable Get_Search_Priest_NOT_Transfer_Details(string searchstr)
        {
            return ObjPP_DAL.Get_Search_Priest_NOT_Transfer_Details(searchstr);
        }

        public int UpdatePriest(Parish_Priest_BO objPriestDetails_BO, int id)
        {
            return ObjPP_DAL.UpdatePriest(objPriestDetails_BO, id);
        }

       
    }
}