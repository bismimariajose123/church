using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class EventBLL
    {
        EventDAL objEventDAL = new EventDAL();
        public int AddEvent(EventBO objEventBO)
        {
            return objEventDAL.AddEvent(objEventBO);
        }
    }
}