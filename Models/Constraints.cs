using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Constraints
    {
        public int ConstraintsId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int? NoBarrel { get; set; }
        public int? NoMaterial { get; set; }
        public int? NoOperator { get; set; }
        public int? WaitingForInspection { get; set; }
        public int? Other { get; set; }
        public DateTime? ConstraintsDate { get; set; }

        public virtual IdlingMinorStoppage IdlingMinorStoppage { get; set; }
    }
}
