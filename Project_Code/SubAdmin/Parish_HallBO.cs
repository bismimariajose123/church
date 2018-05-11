using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class Parish_HallBO
    {
        private string HallName;
        private int ParishId;
        private int HallNo;
        private int No_of_people;
        private int Booked_status;
        private string Rate;
       public string Hallname
        {
            get { return HallName; }
            set { HallName = value; }
        }
        public int parishid
        {
            get { return ParishId; }
            set { ParishId = value; }
        }
        public int hallno
        {
            get { return HallNo; }
            set { HallNo = value; }
        }
        public int People_count
        {
            get { return No_of_people; }
            set { No_of_people = value; }
        }
        public int BookesStatus
        {
            get { return Booked_status; }
            set { Booked_status = value; }
        }
        public string rate
        {
            get { return Rate; }
            set { Rate = value; }
        }
    }
}