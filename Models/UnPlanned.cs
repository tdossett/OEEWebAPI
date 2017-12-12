using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class UnPlanned
    {
        public UnPlanned()
        {
            Availability = new HashSet<Availability>();
            PerformanceEfficiency = new HashSet<PerformanceEfficiency>();
        }

        public int UnPlannedId { get; set; }
        public int Oeeid { get; set; }

        public virtual ICollection<Availability> Availability { get; set; }
        public virtual ICollection<PerformanceEfficiency> PerformanceEfficiency { get; set; }
        public virtual Oee Oee { get; set; }
    }
}
