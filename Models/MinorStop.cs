using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class MinorStop
    {
        public int MinorStopId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int? _25minute { get; set; }
        public DateTime? MinorStopDate { get; set; }

        public virtual IdlingMinorStoppage IdlingMinorStoppage { get; set; }
    }
}
