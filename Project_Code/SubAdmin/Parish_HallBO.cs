using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class Parish_HallBO
    {
        private int Hallid;
        private string HallName;
        private int ParishId;
        private int HallNo;
        private int No_of_people;
        private int Booked_status;
        private string Rate;

        //--------------hall request Table------------
      //  private int HallRequestId; 

        private int Eventid;

        private string OfficialName;
        private DateTime RequestDate;

        private int usertype;
        private int userid;
        private int status;
        private string description;
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

        public int Hallid1 { get => Hallid; set => Hallid = value; }
        public int Eventid1 { get => Eventid; set => Eventid = value; }
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public DateTime RequestDate1 { get => RequestDate; set => RequestDate = value; }
        public int Usertype { get => usertype; set => usertype = value; }
        public int Userid { get => userid; set => userid = value; }
        public int Status { get => status; set => status = value; }
        public string Description { get => description; set => description = value; }
    }
}