using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Availability
    {
        public Availability()
        {
            EquipmentFailure = new HashSet<EquipmentFailure>();
            SetupAdjustment = new HashSet<SetupAdjustment>();
        }

        public int AvailabilityId { get; set; }
        public int UnPlannedId { get; set; }

        public virtual ICollection<EquipmentFailure> EquipmentFailure { get; set; }
        public virtual ICollection<SetupAdjustment> SetupAdjustment { get; set; }
        public virtual UnPlanned UnPlanned { get; set; }
    }
}
