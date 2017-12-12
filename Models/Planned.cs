using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Planned
    {
        public Planned()
        {
            PersonalPanned = new HashSet<PersonalPanned>();
            PlannedDowntime = new HashSet<PlannedDowntime>();
            PmplannedMaintenance = new HashSet<PmplannedMaintenance>();
        }

        public int PlannedId { get; set; }
        public int Oeeid { get; set; }

        public virtual ICollection<PersonalPanned> PersonalPanned { get; set; }
        public virtual ICollection<PlannedDowntime> PlannedDowntime { get; set; }
        public virtual ICollection<PmplannedMaintenance> PmplannedMaintenance { get; set; }
        public virtual Oee Oee { get; set; }
    }
}
