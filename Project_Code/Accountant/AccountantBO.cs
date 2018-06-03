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
        public int Collection_SundayId1 { get => Collection_SundayId; set => Collection_SundayId = value; }
        public long Amount1 { get => Amount; set => Amount = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public DateTime SundayCollectionDate1 { get => SundayCollectionDate; set => SundayCollectionDate = value; }
    }
}