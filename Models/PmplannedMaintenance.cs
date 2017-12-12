using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class PmplannedMaintenance
    {
        public int PmplannedMaintenanceId { get; set; }
        public int PlannedId { get; set; }
        public int? PlannedMaintenace { get; set; }
        public int? Tpm { get; set; }
        public int? Calibration { get; set; }
        public int? Testing { get; set; }
        public int? Other { get; set; }
        public DateTime? PmplannedMaintenanceDate { get; set; }

        public virtual Planned Planned { get; set; }
    }
}
