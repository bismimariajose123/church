using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    //Declaring  Variables
    public class Parish_BO
    {
        private string Parish_Name;
        private string Place;
        private string Username;
        private string Password;

        // Get and set values
        public string ParishName

        {
            get
            {
                return Parish_Name;
            }

            set
            {
                Parish_Name = value;
            }
        }
        public string ParishPlace

        {
            get
            {
                return Place;
            }

            set
            {
                Place = value;
            }
        }

        public string UName

        {
            get
            {
                return Username;
            }

            set
            {
                Username = value;
            }
        }
        public string Passwd

        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }



    }

}