using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class Oee
    {
        public Oee()
        {
            Planned = new HashSet<Planned>();
            UnPlanned = new HashSet<UnPlanned>();
        }

        public int Oeeid { get; set; }
        public string Oeename { get; set; }

        public virtual ICollection<Planned> Planned { get; set; }
        public virtual ICollection<UnPlanned> UnPlanned { get; set; }
    }
}
