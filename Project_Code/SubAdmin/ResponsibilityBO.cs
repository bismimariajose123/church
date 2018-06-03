using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class ResponsibilityBO
    {
        private int Responsibilityd;
        private int Parishid;
        private string uname;
        private string pwd;
        private string DutyName;

        public int Responsibilityd1 { get => Responsibilityd; set => Responsibilityd = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public string Uname { get => uname; set => uname = value; }
        public string Pwd { get => pwd; set => pwd = value; }
        public string DutyName1 { get => DutyName; set => DutyName = value; }
    }
}