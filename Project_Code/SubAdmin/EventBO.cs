using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diocese.Project_Code.SubAdmin
{
    public class EventBO
    {
        private int EventId;
        private int Parishid;
        private string EventName;
        public int EventId1 { get => EventId; set => EventId = value; }
        public int Parishid1 { get => Parishid; set => Parishid = value; }
        public string EventName1 { get => EventName; set => EventName = value; }
    }
}