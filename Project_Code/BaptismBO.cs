using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class BaptismBO
    {
        private int Baptism_id;
        private string BaptismName;
        public string Baptismname
        {
            get { return BaptismName; }
            set { BaptismName = value; }
        }
        private string OfficialName;
        public string Officialname
        {
            get { return OfficialName; }
            set { OfficialName = value; }
        }
        private string PersonParishName;
        public string PersonParishname
        {
            get { return PersonParishName; }
            set { PersonParishName = value; }
        }
        private string FamilyName;
        public string Familyname
        {
            get { return FamilyName; }
            set { FamilyName = value; }
        }
        private string FatherName;
        public string Fathername
        {
            get { return FatherName; }
            set { FatherName = value; }
        }
        private string MotherName;
        public string Mothername
        {
            get { return MotherName; }
            set { MotherName = value; }
        }
        private string Father_Bap_Name;
        public string Father_BapName
        {
            get { return Father_Bap_Name; }
            set { Father_Bap_Name = value; }
        }
        private string Mother_Bap_Name;
        public string Mother_BapName
        {
            get { return Mother_Bap_Name; }
            set { Mother_Bap_Name = value; }
        }
        private string DoBaptism;
        public string Do_Baptism
        {
            get { return DoBaptism; }
            set { DoBaptism = value; }
        }
        private string GFName;
        public string GodFatherName
        {
            get { return GFName; }
            set { GFName = value; }
        }
        private string GMName;
        public string GodMotherName
        {
            get { return GMName; }
            set { GMName = value; }
        }
        private string GFProof;
        public string GFatherProof
        {
            get { return GFProof; }
            set { GFProof = value; }
        }
        private string GMProof;
        public string GMotherProof
        {
            get { return GMProof; }
            set { GMProof = value; }
        }
        private string FProof;
        public string FatherProof
        {
            get { return FProof; }
            set { FProof = value; }
        }
        private string MProof;
        public string MotherProof
        {
            get { return MProof; }
            set { MProof = value; }
        }
        private int ToParish_id;
        public int To_Parish_id
        {
            get { return ToParish_id; }
            set { ToParish_id = value; }
        }
        private string Gender;
        public string gender
        {
            get { return Gender; }
            set { Gender = value; }
        }
        private string Vicar;
        public string vicar
        {
            get { return Vicar; }
            set { Vicar = value; }
        }
        private string Celebrant;
        public string celebrant
        {
            get { return Celebrant; }
            set { Celebrant = value; }
        }
        private int ParishMember;
        public int isParishMember
        {
            get { return ParishMember; }
            set { ParishMember = value; }
        }
        private int Memberid;
        public int Member_id
        {
            get { return Memberid; }
            set { Memberid = value; }
        }
        private int BaptismStatus;
        public int Baptism_Status
        {
            get { return BaptismStatus; }
            set { BaptismStatus = value; }
        }
       
        private string UrBapProof;
        public string Ur_BapProof
        {
            get { return UrBapProof; }
            set { UrBapProof = value; }
        }
        public int Baptismid
        {
            get { return Baptism_id; }
            set { Baptism_id = value; }
        }
       
    }
}