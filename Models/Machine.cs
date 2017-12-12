using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Machine
    {
        public int MachineId { get; set; }
        public int EquipmentFailureId { get; set; }
        public int? Oltissue { get; set; }
        public int? CutterIssue { get; set; }
        public int? BrokenBulb { get; set; }
        public int? BrokenSplice { get; set; }
        public int? Electrical { get; set; }
        public int? FaultStop { get; set; }
        public int? IrheaterError { get; set; }
        public int? FiberDelivery { get; set; }
        public int? CutterBlade { get; set; }
        public int? ServoFailure { get; set; }
        public int? Tensioner { get; set; }
        public int? AxisFailure { get; set; }
        public int? ClampIssue { get; set; }
        public int? ClampAirLeak { get; set; }
        public int? ClampPistonFailure { get; set; }
        public int? RestartIssue { get; set; }
        public int? RestartAirLeak { get; set; }
        public int? CutterAirLeak { get; set; }
        public int? TowJam { get; set; }
        public int? Papissue { get; set; }
        public int? ProbeIssue { get; set; }
        public int? HeadTailstock { get; set; }
        public int? MaintTroubleshooting { get; set; }
        public int? CutterReplacement { get; set; }
        public int? RollerChangeout { get; set; }
        public int? Miscuts { get; set; }
        public int? RestartFailure { get; set; }
        public int? Fod { get; set; }
        public DateTime? MachineDate { get; set; }

        public virtual EquipmentFailure EquipmentFailure { get; set; }
    }
}
