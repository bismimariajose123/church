using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class SuperAdminBO
    {
        private int Superadmin_Id;
public int Superadmin_Id1 { get => Superadmin_Id; set => Superadmin_Id = value; }
        public string Username1 { get => Username; set => Username = value; }
        public string Password1 { get => Password; set => Password = value; }
        public int Priestid1 { get => Priestid; set => Priestid = value; }
        public string Date_created1 { get => Date_created; set => Date_created = value; }
        public int IsActive1 { get => IsActive; set => IsActive = value; }

        private string Username;
        private string Password;
        private int Priestid;
        private string Date_created;
        private int IsActive;
    }
}