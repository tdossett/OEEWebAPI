using System;

namespace OEEWebAPI.ViewModels
{
    public partial class VMUnPlannedAvailabilityEquipmentFailure
    {
        public int Oeeid { get; set; }
        public int UnPlannedId { get; set; }
        public int AvailabilityId { get; set; }
        public int EquipmentFailureId { get; set; }
        public int CartMheid { get; set; }
        public int MachineId { get; set; }
        public int Itid { get; set; }
        public int? DeadBattery { get; set; }
        public int? BrokenWheels { get; set; }
        public int? TurntableMalfunction { get; set; }
        public int? CartMHEOther { get; set; }
        public DateTime? CartMhedate { get; set; }
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
        public int? Network { get; set; }
        public int? Server { get; set; }
        public int? ITOther { get; set; }
        public DateTime? Itdate { get; set; }
    }
}
