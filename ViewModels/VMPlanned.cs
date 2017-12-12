using System;

namespace OEEWebAPI.ViewModels
{
    public partial class VMPlanned
    {
        public int Oeeid { get; set; }
        public int PlannedId { get; set; }
        public int PmplannedMaintenanceId { get; set; }
        public int PersonalPannedId { get; set; }
        public int PlannedDowntimeId { get; set; }
        public int? PlannedMaintenace { get; set; }
        public int? Tpm { get; set; }
        public int? Calibration { get; set; }
        public int? Testing { get; set; }
        public int? Other { get; set; }
        public DateTime? PmplannedMaintenanceDate { get; set; }
        public int? Break { get; set; }
        public int? MeetingPlanned { get; set; }
        public int? ShiftChanged { get; set; }
        public int? Training { get; set; }
        public DateTime? PlannedDate { get; set; }
        public int? NoWorkScheduled { get; set; }
        public DateTime? PlannedDownTimeDate { get; set; }
    }
}
