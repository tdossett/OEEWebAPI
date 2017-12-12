using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class PersonalUnplanned
    {
        public int PersonalUnplannedId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int? MeetingUnplanned { get; set; }
        public int? OperatorRelief { get; set; }
        public DateTime? PersonalUnplannedDate { get; set; }

        public virtual IdlingMinorStoppage IdlingMinorStoppage { get; set; }
    }
}
