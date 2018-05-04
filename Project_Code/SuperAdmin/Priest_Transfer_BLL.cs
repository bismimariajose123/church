using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{

    public class Priest_Transfer_BLL
    {
        
        Priest_Transfer_DAL objPriestTransfer_DAL = new Priest_Transfer_DAL();
        public DataTable Priest_Parish_Ddlist()
        {
          return  objPriestTransfer_DAL.Priest_Parish_Ddlist();
        }

        

        public int Save_PreistTransfer_Details(Priest_TransferBO objPriestTransfer_BO, string designation)
        {
            return objPriestTransfer_DAL.Save_PreistTransfer_Details(objPriestTransfer_BO,designation);
        }
    }
}