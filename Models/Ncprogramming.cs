using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Ncprogramming
    {
        public int NcprogrammingId { get; set; }
        public int IdlingMinorStoppageId { get; set; }
        public int? NcprogramIssue { get; set; }
        public int? Other { get; set; }
        public DateTime? NcprogrammingDate { get; set; }

        public virtual IdlingMinorStoppage IdlingMinorStoppage { get; set; }
    }
}
