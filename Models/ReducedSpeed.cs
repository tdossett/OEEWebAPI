using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class ReducedSpeed
    {
        public int ReducedSpeedId { get; set; }
        public int PerformanceEfficiencyId { get; set; }
        public int? ReduceFeedrate { get; set; }
        public DateTime? ReduceSpeedDate { get; set; }

        public virtual PerformanceEfficiency PerformanceEfficiency { get; set; }
    }
}
