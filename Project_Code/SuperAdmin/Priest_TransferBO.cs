using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Priest_TransferBO
    {
        private int Priest_Id;
        private int Parish_Id;
        public int PriestID
        {
            get { return Priest_Id; }
            set { Priest_Id = value; }
        }
        public int ParishID
        {
            get {return Parish_Id; }
            set { Parish_Id = value; }
        }

        
    }
}