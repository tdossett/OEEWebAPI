using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class PersonalPanned
    {
        public int PersonalPannedId { get; set; }
        public int PlannedId { get; set; }
        public int? Break { get; set; }
        public int? MeetingPlanned { get; set; }
        public int? ShiftChanged { get; set; }
        public int? Training { get; set; }
        public DateTime? PlannedDate { get; set; }

        public virtual Planned Planned { get; set; }
    }
}
