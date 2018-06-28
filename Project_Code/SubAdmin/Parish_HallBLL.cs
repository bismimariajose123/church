using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class Parish_HallBLL
    {
        Parish_HallDAL objParish_HallDAL = new Parish_HallDAL();
        public Parish_HallBO GetHallNo(Parish_HallBO objParish_HallBO)
        {
            return objParish_HallDAL.GetHallNo(objParish_HallBO);
        }

        public int AddHall(Parish_HallBO objParish_HallBO)
        {
            return objParish_HallDAL.AddHall(objParish_HallBO);
        }

        public DataTable GetParishHallDetails(Parish_HallBO objParish_HallBO)
        {
            return objParish_HallDAL.GetParishHallDetails(objParish_HallBO);
        }

        public int Delete_ParishHall(int id)
        {
            return objParish_HallDAL.Delete_ParishHall(id);
        }

       public int UpdateParishHall(Parish_HallBO objParish_HallBO, int id)
        {
            return objParish_HallDAL.UpdateParishHall(objParish_HallBO,id);
        }

        public DataTable LoadMemberNotification(int parishid, int userid,int usertype)
        {
            return objParish_HallDAL.LoadMemberNotification(parishid, userid, usertype);
        }

        public Parish_HallBO GetParishHallDetails(int hallid)
        {
            return objParish_HallDAL.GetParishHallDetails(hallid);
        }

        public List<String> FillMemberDetails(int familyid,int usertype)
        {
            return objParish_HallDAL.FillMemberDetails(familyid, usertype);
        }

        public DataTable LoadGVRequest(int parishid)
        {
            return objParish_HallDAL.LoadGVRequest(parishid);
        }

        public int AddHallRequest(Parish_HallBO objParish_HallBO)
        {
            return objParish_HallDAL.AddHallRequest(objParish_HallBO);
        }

        public int UpdateRequest(Parish_HallBO objParish_HallBO, int id)
        {
            return objParish_HallDAL.UpdateRequest(objParish_HallBO,id);
        }

        public int UpdateMember_Request(Parish_HallBO objParish_HallBO, int id)
        {
            return objParish_HallDAL.UpdateMember_Request(objParish_HallBO, id);
        }

        public DataTable Search(DateTime oDate, int parishid, int eventid,int userid,int usertype)
        {
            return objParish_HallDAL.Search(oDate, parishid, eventid, userid, usertype);
        }

        public DataTable SearchEvent(int parishid, int eventid, int userid, int usertype)
        {
            return objParish_HallDAL.SearchEvent( parishid, eventid, userid, usertype);
        }
    }
}