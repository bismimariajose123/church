using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class LoginBO
    {
        private int Parish_ID;
        private int Family_ID;
        private string Username;
        private string Password;
        private int UserType;
        private string Name;

        public int Parishid
        {
        get { return Parish_ID; }
        set { Parish_ID = value; }
          }

        public int Familyid
        {
            get { return Family_ID; }
            set { Family_ID = value; }
        }
        public string username
        {
            get { return Username; }
            set { Username = value; }
        }
       
        public string Pwd
        {
            get { return Password; }
            set { Password = value; }
        }
        public int User_type
        {
            get { return UserType; }
            set { UserType = value; }
        }
        public string Personname
        {
            get { return Name; }
            set { Name = value; }
        }
        
        
    }
}