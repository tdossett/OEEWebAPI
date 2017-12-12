using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class CartMhe
    {
        public int CartMheid { get; set; }
        public int EquipmentFailureId { get; set; }
        public int? DeadBattery { get; set; }
        public int? BrokenWheels { get; set; }
        public int? TurntableMalfunction { get; set; }
        public int? Other { get; set; }
        public DateTime? CartMhedate { get; set; }

        public virtual EquipmentFailure EquipmentFailure { get; set; }
    }
}
