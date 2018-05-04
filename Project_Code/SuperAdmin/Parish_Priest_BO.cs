using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SuperAdmin
{
    public class Parish_Priest_BO
    {
        private string Parish_Priest_Name;
        private string Parish_Priest_Image;
        private string Phone_No;
        private string OrdinationDate;
        private string Native_Place;
        private string Designation;
        private int Current_Parish_id;
        public string PPName
        {
            get {return Parish_Priest_Name;}
            set { Parish_Priest_Name = value; }
           
        }
        public string PPImage
        {
            get { return Parish_Priest_Image; }
            set { Parish_Priest_Image = value; }
        }
        public string Contact
        {
            get { return Phone_No; }
            set { Phone_No = value; }

        }
        public string Ordination_Date
        {
            get { return OrdinationDate; }
            set { OrdinationDate = value; }

        }
        public string NativePlace
        {
            get { return Native_Place; }
            set { Native_Place = value; }

        }
        public string P_Designation
        {
            get { return Designation; }
            set { Designation = value; }
        }
        public int Current_Parishid
        {
            get { return Current_Parish_id; }
            set { Current_Parish_id = value; }
        }
    }
}