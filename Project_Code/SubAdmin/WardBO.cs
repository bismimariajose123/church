using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class WardBO
    {
        private string WardName;
        private int Parishid;
        public string Wardname
        {
            get { return WardName; }
            set { WardName = value; }
        }
        public int Parish_id
        {
            get { return Parishid; }
            set { Parishid = value; }
        }
    }
}