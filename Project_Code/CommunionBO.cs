using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class CommunionBO
    {
        private int Communion_ID;
        private String FamilyName;
        private int Member_id;

        private int Parish_id;
        private String ParishofCommumion;
        private String OfficialName;
        private String BaptismName;
        private String Gender;
        private String FName;
        private String MName;
        private String BlessedBy;
        private String Parish_PriestName;
        private DateTime DO_communion;
        private String Commu_status;

        private int ParishMember;
        private String PersonsParishName;

        public int Communion_ID1 { get => Communion_ID; set => Communion_ID = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public int Member_id1 { get => Member_id; set => Member_id = value; }
        public int Parish_id1 { get => Parish_id; set => Parish_id = value; }
        public string ParishofCommumion1 { get => ParishofCommumion; set => ParishofCommumion = value; }
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public string BaptismName1 { get => BaptismName; set => BaptismName = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string FName1 { get => FName; set => FName = value; }
        public string MName1 { get => MName; set => MName = value; }
        public string BlessedBy1 { get => BlessedBy; set => BlessedBy = value; }
        public string Parish_PriestName1 { get => Parish_PriestName; set => Parish_PriestName = value; }
        public DateTime DO_communion1 { get => DO_communion; set => DO_communion = value; }
        public string Commu_status1 { get => Commu_status; set => Commu_status = value; }
        public int ParishMember1 { get => ParishMember; set => ParishMember = value; }
        public string PersonsParishName1 { get => PersonsParishName; set => PersonsParishName = value; }
    }
}