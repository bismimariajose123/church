using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.Accountant
{
    public class AccountantBO
    {
        private int Collection_SundayId;
        private long Amount;
        private int Parishid;
        private DateTime SundayCollectionDate;
        private long SC_BalanceAmount;
        public int Collection_SundayId1 { get => Collection_SundayId; set => Collection_SundayId = value; }
        public long Amount1 { get => Amount; set => Amount = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public DateTime SundayCollectionDate1 { get => SundayCollectionDate; set => SundayCollectionDate = value; }
        public long SC_BalanceAmount1 { get => SC_BalanceAmount; set => SC_BalanceAmount = value; }
      

        //Balance amount Table


        private int Balance_Id;
        private long BalanceAmount;
        private int Eventid;
        public int Balance_Id1 { get => Balance_Id; set => Balance_Id = value; }
        public long BalanceAmount1 { get => BalanceAmount; set => BalanceAmount = value; }
        public int Eventid1 { get => Eventid; set => Eventid = value; }


    }
}