using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OEEWebAPI.ViewModels
{
    public partial class VMUnPlannedPerformanceEfficencyIdlingReducedSpeed
    {
        public int Oeeid { get; set; }
        public int UnPlannedId { get; set; }
        public int PerformanceEfficiencyId { get; set; }
        public int ReducedSpeedId { get; set; }
        public int? ReduceFeedrate { get; set; }
        public DateTime? ReduceSpeedDate { get; set; }
    }
}
