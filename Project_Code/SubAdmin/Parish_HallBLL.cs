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
    }
}