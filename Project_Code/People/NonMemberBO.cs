using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class NonMemberBO
    {
        private int NonMember_id;
         public int NonMember_id1 { get => NonMember_id; set => NonMember_id = value; }
        public string Uname1 { get => Uname; set => Uname = value; }
        public string Pwd1 { get => Pwd; set => Pwd = value; }
        public string ContactNo1 { get => ContactNo; set => ContactNo = value; }
        public string Email1 { get => Email; set => Email = value; }
        public int To_Parishid1 { get => To_Parishid; set => To_Parishid = value; }
        public string Family_Name1 { get => Family_Name; set => Family_Name = value; }
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public string Po1 { get => Po; set => Po = value; }
        public string Dob1 { get => Dob; set => Dob = value; }
        public string Landmark1 { get => Landmark; set => Landmark = value; }
        public string FName1 { get => FName; set => FName = value; }
        public string MName1 { get => MName; set => MName = value; }
        public int IsParishMember1 { get => IsParishMember; set => IsParishMember = value; }

        private string Uname;
        private string Pwd;
        private string ContactNo;
        private string Email;
        private int To_Parishid;
        private string Family_Name;
        private string OfficialName;
        private string Po;
        private string Dob;
        private string Landmark;
        private string FName;
        private string MName;
        private int IsParishMember;

    }
}