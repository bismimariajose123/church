using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code
{
    public class DonationBO
    {
        private int DonationId;
        private string FamilyName;
        private string Persons_ParishName;
        private string OfficialName;

        private int Gender;
        private string ContactNo;
        private string Diocese;
        private int EventName;
        private int ToParishid;
        private int Memberid;
        private int IsParishMember;
        private long Amount;
        private DateTime AmountReceivedDate;

        private int TotalAmount;//variable to display total amount
        private long BalanceAmount;
        public int DonationId1 { get => DonationId; set => DonationId = value; }
        public string FamilyName1 { get => FamilyName; set => FamilyName = value; }
        public string Persons_ParishName1 { get => Persons_ParishName; set => Persons_ParishName = value; }
        public string OfficialName1 { get => OfficialName; set => OfficialName = value; }
        public int Gender1 { get => Gender; set => Gender = value; }
        public string ContactNo1 { get => ContactNo; set => ContactNo = value; }
        public string Diocese1 { get => Diocese; set => Diocese = value; }
        public int EventName1 { get => EventName; set => EventName = value; }
        public int ToParishid1 { get => ToParishid; set => ToParishid = value; }
        public int Memberid1 { get => Memberid; set => Memberid = value; }
        public int IsParishMember1 { get => IsParishMember; set => IsParishMember = value; }
        public long Amount1 { get => Amount; set => Amount = value; }
        public DateTime AmountReceivedDate1 { get => AmountReceivedDate; set => AmountReceivedDate = value; }
        public int TotalAmount1 { get => TotalAmount; set => TotalAmount = value; }
        public long BalanceAmount1 { get => BalanceAmount; set => BalanceAmount = value; }
    }
}