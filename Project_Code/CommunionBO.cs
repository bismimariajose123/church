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
        private int Parish_id;
        private String OfficialName;
        private String BaptismName;
        private String Gender;
        private String FName;
        private String MName;
        private DateTime DO_communion;

        private DateTime DO_Birth;
        public int Communion_ID1 { get => Communion_ID; set => Communion_ID = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
      
        public int Parish_id1 { get => Parish_id; set => Parish_id = value; }
     
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public string BaptismName1 { get => BaptismName; set => BaptismName = value; }
        public string Gender1 { get => Gender; set => Gender = value; }
        public string FName1 { get => FName; set => FName = value; }
        public string MName1 { get => MName; set => MName = value; }
    
        public DateTime DO_communion1 { get => DO_communion; set => DO_communion = value; }
       
    
        public DateTime DO_Birth1 { get => DO_Birth; set => DO_Birth = value; }
    }
}