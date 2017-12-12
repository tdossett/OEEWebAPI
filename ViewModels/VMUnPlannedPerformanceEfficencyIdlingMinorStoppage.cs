using System;

namespace OEEWebAPI.ViewModels
{
    public partial class VMUnPlannedPerformanceEfficencyIdlingMinorStoppage
    {
        public int Oeeid { get; set; }
        public int UnPlannedId { get; set; }
        public int PerformanceEfficiencyId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int ConstraintsId { get; set; }
        public int MinorStopId { get; set; }
        public int PersonalUnplannedId { get; set; }
        public int NcprogrammingId { get; set; }
        public int MaterialId { get; set; }
        public int? NoBarrel { get; set; }
        public int? NoMaterial { get; set; }
        public int? NoOperator { get; set; }
        public int? WaitingForInspection { get; set; }
        public int? ConstraintsOther { get; set; }
        public DateTime? ConstraintsDate { get; set; }
        public int? _25minute { get; set; }
        public DateTime? MinorStopDate { get; set; }
        public int? MeetingUnplanned { get; set; }
        public int? OperatorRelief { get; set; }
        public DateTime? PersonalUnplannedDate { get; set; }
        public int? NcprogramIssue { get; set; }
        public int? NcprogrammingOther { get; set; }
        public DateTime? NcprogrammingDate { get; set; }
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

    }
}
