using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class IdlingMinorStoppageRepository : IIdlingMinorStoppageRepository
    {
        private OEEContext _context;

        // Constructor
        public IdlingMinorStoppageRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All  IdlingMinorStoppage's
        IEnumerable<IdlingMinorStoppage> IIdlingMinorStoppageRepository.GetAll()
        {
            var idlingminorstoppage = _context.IdlingMinorStoppage;

            return idlingminorstoppage.AsEnumerable();
        }

        // Get an IdlingMinorStoppage
        public IdlingMinorStoppage Find(int id)
        {
            var idlingminorstoppage = _context.IdlingMinorStoppage.Single(o => o.IdlingMinorStoppageId == id);

            return idlingminorstoppage;
        }

        // Add an IdlingMinorStoppage
        public void Add(IdlingMinorStoppage idlingminorstoppage)
        {
            _context.IdlingMinorStoppage.Add(idlingminorstoppage);
            _context.SaveChanges();
        }

        // Update an IdlingMinorStoppage
        public void Update(IdlingMinorStoppage idlingminorstoppage)
        {
            var idlingminorstoppageToUpdate = _context.IdlingMinorStoppage
                .Single(o => o.IdlingMinorStoppageId == idlingminorstoppage.IdlingMinorStoppageId);
            if (idlingminorstoppageToUpdate != null)
            {
                idlingminorstoppageToUpdate.PerformanceEfficiencyId = idlingminorstoppage.PerformanceEfficiencyId;
                _context.SaveChanges();
            }
        }

        // Remove an IdlingMinorStoppage
        public void Remove(int id)
        {
            var idlingminorstoppageToRemove = _context.IdlingMinorStoppage
                .Single(o => o.IdlingMinorStoppageId == id);
            if (idlingminorstoppageToRemove != null)
            {
                _context.Remove(idlingminorstoppageToRemove);
                _context.SaveChanges();
            }
        }
    }
}
