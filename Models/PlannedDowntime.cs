using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class PlannedDowntime
    {
        public int PlannedDowntimeId { get; set; }
        public int PlannedId { get; set; }
        public int? NoWorkScheduled { get; set; }
        public DateTime? PlannedDownTimeDate { get; set; }

        public virtual Planned Planned { get; set; }
    }
}
