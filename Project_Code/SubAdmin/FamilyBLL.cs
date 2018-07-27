using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class FamilyBLL
    {
        FamilyDAL objFamilyDAL = new FamilyDAL();
        public int AddFamily(FamilyBO objFamilyBO)
        {
            return objFamilyDAL.AddFamily(objFamilyBO);
        }

        public FamilyBO GetFamilyNo(FamilyBO objFamilyBO)
        {
            return objFamilyDAL.GetFamilyNo(objFamilyBO);
        }

        public DataTable GetWardName(FamilyBO objFamilyBO)
        {
            return objFamilyDAL.GetWardName(objFamilyBO);
        }

        public DataTable GetFamilyDetails(FamilyBO objFamilyBO)
        {
            return objFamilyDAL.GetFamilyDetails(objFamilyBO);
        }

     
        public DataTable getFamilyName(FamilyBO objFamilyBO)
        {
            return objFamilyDAL.getFamilyName(objFamilyBO);
        }

        public DataTable Get_Search_FamilyDetails(FamilyBO objFamilyBO, string searchstr)
        {
            return objFamilyDAL.Get_Search_FamilyDetails(objFamilyBO, searchstr);
        }

        public int Delete_Family(int id)
        {
            return objFamilyDAL.Delete_Family(id);
        }

        //public int UpdateWard(FamilyBO objFamilyBO, int id)
        //{
        //    return objFamilyDAL.UpdateWard(objFamilyBO, id);
        //}
    }
}