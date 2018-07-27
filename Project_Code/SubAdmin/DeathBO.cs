using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class DeathBO
    {
        private int Death_ID;

        private int Member_id;

        private int Parish_id;

        private String OfficialName;
        private String DO_Death;
        private String Do_Funeral;
        private String FuneralTime;
        private int Gender;

        public int Death_ID1 { get => Death_ID; set => Death_ID = value; }
        public int Member_id1 { get => Member_id; set => Member_id = value; }
        public int Parish_id1 { get => Parish_id; set => Parish_id = value; }
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public string DO_Death1 { get => DO_Death; set => DO_Death = value; }
        public string Do_Funeral1 { get => Do_Funeral; set => Do_Funeral = value; }
        public string FuneralTime1 { get => FuneralTime; set => FuneralTime = value; }
        public int Gender1 { get => Gender; set => Gender = value; }
    }
}