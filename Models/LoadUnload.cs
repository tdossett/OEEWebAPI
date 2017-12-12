using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class LoadUnload
    {
        public int LoadUnloadId { get; set; }
        public int SetupAdjustmentId { get; set; }
        public int? Load { get; set; }
        public int? Unload { get; set; }
        public int? Debag { get; set; }
        public int? InterimClean { get; set; }
        public int? PreClean { get; set; }
        public int? PostClean { get; set; }
        public int? AwaitingProgram { get; set; }
        public DateTime? LoadUnloadDate { get; set; }

        public virtual SetupAdjustment SetupAdjustment { get; set; }
    }
}
