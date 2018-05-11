using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class MemberRegisterBLL
    {
        MemberRegisterDAL objMemberRegisterDAL = new MemberRegisterDAL();
        public int InsertMemberDetails(MemberRegisterBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.InsertMemberDetails(objMemberRegisterBO);
        }

        public MemberRegisterBO Load_MemberData(MemberRegisterBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.Load_MemberData(objMemberRegisterBO);
        }
    }
}