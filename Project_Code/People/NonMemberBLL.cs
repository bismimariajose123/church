using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class NonMemberBLL
    {
        NonMemberDAL objNonMemberDAl = new NonMemberDAL();

        public int RegisterNonMemberDetails(NonMemberBO objNonMemberBO)
        {
            return objNonMemberDAl.RegisterNonMemberDetails(objNonMemberBO);
        }
    }
}