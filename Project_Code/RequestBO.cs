using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class RequestBO
    {
        private int Request_Id;
        public int Request_Id1 { get => Request_Id; set => Request_Id = value; }

        private string Event_Name;
        public string Event_Name1 { get => Event_Name; set => Event_Name = value; }

        private int Memberid;
        public int Memberid1 { get => Memberid; set => Memberid = value; }

        private int requestStatus;
        public int RequestStatus { get => requestStatus; set => requestStatus = value; }

        private string RequestDate;
        public string RequestDate1 { get => RequestDate; set => RequestDate = value; }

        private string RequestTime;
        public string RequestTime1 { get => RequestTime; set => RequestTime = value; }
        public string RequestStatus_Description1 { get => RequestStatus_Description; set => RequestStatus_Description = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public string ProposedDateOfBap1 { get => ProposedDateOfBap; set => ProposedDateOfBap = value; }
        public string ProposedTimeOfBap1 { get => ProposedTimeOfBap; set => ProposedTimeOfBap = value; }
        public int IsParishMember { get => isParishMember; set => isParishMember = value; }

        private string RequestStatus_Description;

        private int Parishid;
        private string ProposedDateOfBap;
        private string ProposedTimeOfBap;
        private int isParishMember;

    }
}