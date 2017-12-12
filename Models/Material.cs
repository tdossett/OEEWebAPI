using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Material
    {
        public int MaterialId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int? PolyWrap { get; set; }
        public int? NotStickingIml { get; set; }
        public int? CompactionRollerIssue { get; set; }
        public int? CrossedTow { get; set; }
        public int? SpliceBreak { get; set; }
        public int? TowJumpOffRoller { get; set; }
        public int? LostTow { get; set; }
        public int? TowShredding { get; set; }
        public int? SpoolChanges { get; set; }
        public int? CleanOutFod { get; set; }
        public int? TowWrapOnqRoller { get; set; }
        public DateTime? MaterialDate { get; set; }

        public virtual IdlingMinorStoppage IdlingMinorStoppage { get; set; }
    }
}
