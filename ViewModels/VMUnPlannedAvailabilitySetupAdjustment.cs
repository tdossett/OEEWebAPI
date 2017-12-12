using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OEEWebAPI.ViewModels
{
    public class VMUnPlannedAvailabilitySetupAdjustment
    {
        public int Oeeid { get; set; }
        public int UnPlannedId { get; set; }
        public int AvailabilityId { get; set; }
        public int SetupAdjustmentId { get; set; }
        public int LoadUnloadId { get; set; }
        public int CalibrationAlignmentId { get; set; }
        public int? Load { get; set; }
        public int? Unload { get; set; }
        public int? Debag { get; set; }
        public int? InterimClean { get; set; }
        public int? PreClean { get; set; }
        public int? PostClean { get; set; }
        public int? AwaitingProgram { get; set; }
        public DateTime? LoadUnloadDate { get; set; }
        public int? Probe { get; set; }
        public int? SpoolChanges { get; set; }
        public int? InspectIml { get; set; }
        public DateTime? CalibrationDate { get; set; }
    }
}
