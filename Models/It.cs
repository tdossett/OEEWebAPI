using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class It
    {
        public int Itid { get; set; }
        public int EquipmentFailureId { get; set; }
        public int? Network { get; set; }
        public int? Server { get; set; }
        public int? Other { get; set; }
        public DateTime? Itdate { get; set; }

        public virtual EquipmentFailure EquipmentFailure { get; set; }
    }
}
