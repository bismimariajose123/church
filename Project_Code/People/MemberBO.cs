using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.People
{
    public class MemberBO
    {
        private int Member_ID;
        private int Parish_id;
        private int Family_id;
        private int Relation_id;
        private string OfficialName;
        private string BaptismName;
        private string ContactNo;
        private string Occupation;
        private string Email;
        private string DOB;
        private string Landmark;
        private string FatherName;
        private string MotherName;
        private int MarriedStatus;
        private int ParishMember;
        private string PO;
        private string ImagePath;
        private string WifesOfficialName;
        private string WifesBapName;
         private int Baptismid;
        private int Marriageid;
        private int RegisteredStatus;
        private string familyname;
        private string Nativeparishname;
        public int Memberid
        {
            get { return Member_ID; }
            set { Member_ID = value; }
        }
        public int Parishid
        {
            get { return Parish_id; }
            set { Parish_id = value; }
        }
        public int Familyid
        {
            get { return Family_id; }
            set { Family_id = value; }
        }
        public int Relationid
        {
            get { return Relation_id; }
            set { Relation_id = value; }
        }
        public string Officialname
        {
              get{return OfficialName; }
              set{ OfficialName = value;}
        }

        public string Baptismname
        {
              get{return BaptismName;}
              set{ BaptismName=value;}
         }

         public string Contactno
        {
              get{return ContactNo; }
              set{ ContactNo = value;}
         }
         public string occupation
        {
              get{return Occupation; }
              set{ Occupation = value;}
         }
          public string email
        {
              get{return Email; }
              set{ Email = value;}
         }
          public string dob
        {
              get{return DOB; }
              set{ DOB = value;}
         }
          public string landmark
        {
              get{return Landmark ;}
              set{Landmark =value;}
         }
          public string Fathername
         {
              get{return FatherName; }
              set{ FatherName = value;}
          }

        public string Mothername
        {
            get { return MotherName; }
            set { MotherName = value; }
        }

        public int Marriedstatus
        {
            get { return MarriedStatus; }
            set { MarriedStatus = value; }
        }
        public int Parishmember
        {
            get { return ParishMember; }
            set { ParishMember = value; }
        }
        public string po
        {
            get { return PO; }
            set { PO = value; }
        }
        public string Imagepath
        {
            get { return ImagePath; }
            set { ImagePath = value; }
        }
        public string WifesOfficialname
        {
            get { return WifesOfficialName; }
            set { WifesOfficialName = value; }
        }
        public string WifesBapname
        {
            get { return WifesBapName; }
            set { WifesBapName = value; }
        }
        public int Baptism_id
        {
            get { return Baptismid; }
            set { Baptismid = value; }
        }
        public int Marriage_id
        {
            get { return Marriageid; }
            set { Marriageid = value; }
        }
        public int Registered_Status
        {
            get { return RegisteredStatus; }
            set { RegisteredStatus = value; }
        }
        public string FamilyName
        {
            get { return familyname; }
            set { familyname = value; }
        }
        public string NativeParishName
        {
            get { return Nativeparishname; }
            set { Nativeparishname = value; }
        }
    }
}