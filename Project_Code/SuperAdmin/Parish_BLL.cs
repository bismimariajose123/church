using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Parish_BLL
    {
        Parish_DAL objParishDAL = new Parish_DAL(); // Creating object of Dataccess

        public int InsertParishDetails(Parish_BO objParishDetails_BO) // passing Bussiness object Here
        {
              try
            {
                return objParishDAL.InsertParishInformation(objParishDetails_BO); // calling Method of DataAccess
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objParishDAL = null;
            }
        }

        public DataTable GetParishNotAssignedDetails()
        {
            return objParishDAL.GetParishNotAssignedDetails();
        }

        public DataTable GetParishDetails()
        {
            return objParishDAL.GetParishInformation();
        }

        public int Delete_Parish(int id)
        {
            try
            {
               return objParishDAL.DeleteParish(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public int UpdateParish(Parish_BO objParishDetails_BO, int id)
        {
            try
            {
                return objParishDAL.UpdateParish(objParishDetails_BO,id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public DataTable Get_Search_ParishDetails(string searchstr)
        {
            return objParishDAL.Get_Search_ParishInformation(searchstr);
        }
    }

}