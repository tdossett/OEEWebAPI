using System;
using System.Collections.Generic;

namespace OEEWebAPI.Models
{
    public partial class IdlingMinorStoppage
    {
        public IdlingMinorStoppage()
        {
            Constraints = new HashSet<Constraints>();
            Material = new HashSet<Material>();
            MinorStop = new HashSet<MinorStop>();
            Ncprogramming = new HashSet<Ncprogramming>();
            PersonalUnplanned = new HashSet<PersonalUnplanned>();
        }

        public int IdlingMinorStoppageId { get; set; }
        public int PerformanceEfficiencyId { get; set; }

        public virtual ICollection<Constraints> Constraints { get; set; }
        public virtual ICollection<Material> Material { get; set; }
        public virtual ICollection<MinorStop> MinorStop { get; set; }
        public virtual ICollection<Ncprogramming> Ncprogramming { get; set; }
        public virtual ICollection<PersonalUnplanned> PersonalUnplanned { get; set; }
        public virtual PerformanceEfficiency PerformanceEfficiency { get; set; }
    }
}
