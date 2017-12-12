using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class EquipmentFailure
    {
        public EquipmentFailure()
        {
            CartMhe = new HashSet<CartMhe>();
            It = new HashSet<It>();
            Machine = new HashSet<Machine>();
        }

        public int EquipmentFailureId { get; set; }
        public int AvailabilityId { get; set; }

        public virtual ICollection<CartMhe> CartMhe { get; set; }
        public virtual ICollection<It> It { get; set; }
        public virtual ICollection<Machine> Machine { get; set; }
        public virtual Availability Availability { get; set; }
    }
}
