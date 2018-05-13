using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class MemberBLL
    {
        MemberDAL objMemberRegisterDAL = new MemberDAL();
        public int InsertMemberDetails(MemberBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.InsertMemberDetails(objMemberRegisterBO);
        }

        public MemberBO Load_MemberData(MemberBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.Load_MemberData(objMemberRegisterBO);
        }

        public DataTable Get_Member_Details(MemberBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.Get_Member_Details(objMemberRegisterBO);
        }

        public DataTable Get_Search_MemberDetails(string searchstr, MemberBO objMemberRegisterBO)
        {
            return objMemberRegisterDAL.Get_Search_MemberDetails(searchstr, objMemberRegisterBO);
        }

        //public string GetStatus(MemberBO objMemberRegisterBO)
        //{
        //    MemberBO obj=objMemberRegisterDAL.GetStatus(objMemberRegisterBO);
        //    string status = string.Empty;
        //    if(obj.Registered_Status!=0 )
        //    {
        //        status = "all registered";
        //    }
        //    else if(obj.Baptism_id==0 && obj.Marriedstatus==0)//newborn
        //    {
        //        status = "bnil";
        //    }
        //    else if(obj.Baptism_id==0 && obj.Marriage_id==0 && obj.Marriedstatus!=0)
        //    {
        //        status = "no b and m";
        //    }
        //    else if(obj.Marriedstatus != 0 && obj.Baptism_id !=0 && obj.Marriage_id == 0)
        //    {
        //        status = "mnil";
        //    }
        //        return status;
        //}
    }
}