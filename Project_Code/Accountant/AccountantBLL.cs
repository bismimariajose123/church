using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.Accountant
{
    public class AccountantBLL
    {
        AccountantDAL objAccountantDAL = new AccountantDAL();
        public int AddSundayCollection(AccountantBO objAccountantBO)     //ADD SUNDAY COLLECTION TO COLLECTION_SUNDAY_TABLE

        {
            return objAccountantDAL.AddSundayCollection(objAccountantBO);
        }
    }
}