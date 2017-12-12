using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class SetupAdjustment
    {
        public SetupAdjustment()
        {
            CalibrationAlignment = new HashSet<CalibrationAlignment>();
            LoadUnload = new HashSet<LoadUnload>();
        }

        public int SetupAdjustmentId { get; set; }
        public int AvailabilityId { get; set; }

        public virtual ICollection<CalibrationAlignment> CalibrationAlignment { get; set; }
        public virtual ICollection<LoadUnload> LoadUnload { get; set; }
        public virtual Availability Availability { get; set; }
    }
}
