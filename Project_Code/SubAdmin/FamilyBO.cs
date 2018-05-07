using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class FamilyBO
    {
        private string FamilyName;
        private int Ward_id;
        private int Parish_id;
        private string Username;
        private string Password;
        private int FamilyNo;
        private string Contact_No;
        private string HeadName;
        public string familyname
        {
            get { return FamilyName; }
            set { FamilyName = value; }
        }
        public int ward_id
        {
            get { return Ward_id; }
            set { Ward_id = value; }
        }
        public int parish_id
        {
            get { return Parish_id; }
            set { Parish_id = value; }
        }

        public string username
        {
            get { return Username; }
            set { Username = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public int Familyno
        {
            get { return FamilyNo; }
            set { FamilyNo = value; }
        }
        public string ContactNo
        {
            get { return Contact_No; }
            set { Contact_No = value; }
        }
        public string Headname
        {
            get { return HeadName; }
            set { HeadName = value; }
        }


    }
}