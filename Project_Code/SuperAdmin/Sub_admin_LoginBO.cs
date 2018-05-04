using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Sub_admin_LoginBO
    {
        private string Sub_Ad_uname;
        private string Sub_Ad_password;
        private int Sub_Ad_Parish_id;
        private int Priest_Id;
        public string Sub_admin_UName
        {
            get { return Sub_Ad_uname; }
            set { Sub_Ad_uname = value; }
        }
        public string Sub_Ad_PWD
        {
            get { return Sub_Ad_password; }
            set { Sub_Ad_password = value; }
        }
        public int Sub_Ad_ParishID
        {
            get { return Sub_Ad_Parish_id; }
            set { Sub_Ad_Parish_id = value; }
        }
        public int Priest_ID
        {
            get { return Priest_Id; }
            set { Priest_Id = value; }
        }
    }
}