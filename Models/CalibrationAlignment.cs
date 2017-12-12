using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class CalibrationAlignment
    {
        public int CalibrationAlignmentId { get; set; }
        public int SetupAdjustmentId { get; set; }
        public int? Probe { get; set; }
        public int? SpoolChanges { get; set; }
        public int? InspectIml { get; set; }
        public DateTime? CalibrationDate { get; set; }

        public virtual SetupAdjustment SetupAdjustment { get; set; }
    }
}
