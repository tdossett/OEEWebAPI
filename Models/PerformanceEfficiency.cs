using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class PerformanceEfficiency
    {
        public PerformanceEfficiency()
        {
            IdlingMinorStoppage = new HashSet<IdlingMinorStoppage>();
            ReducedSpeed = new HashSet<ReducedSpeed>();
        }

        public int PerformanceEfficiencyId { get; set; }
        public int? UnPlannedId { get; set; }

        public virtual ICollection<IdlingMinorStoppage> IdlingMinorStoppage { get; set; }
        public virtual ICollection<ReducedSpeed> ReducedSpeed { get; set; }
        public virtual UnPlanned UnPlanned { get; set; }
    }
}
