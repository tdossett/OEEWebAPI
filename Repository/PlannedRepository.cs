using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class PlannedRepository : IPlannedRepository
    {
        private OEEContext _context;

        // Constructor
        public PlannedRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All Planned's
        IEnumerable<Planned> IPlannedRepository.GetAll()
        {
            var planned = _context.Planned;

            return planned.AsEnumerable();
        }

        // Get an Planned
        public Planned Find(int id)
        {
            var planned = _context.Planned.Single(o => o.PlannedId == id);

            return planned;
        }

        // Add an Planned
        public void Add(Planned planned)
        {
            _context.Planned.Add(planned);
            _context.SaveChanges();
        }

        // Update an Planned
        public void Update(Planned planned)
        {
            var plannedToUpdate = _context.Planned.Single(o => o.PlannedId == planned.PlannedId);
            if (plannedToUpdate != null)
            {
                plannedToUpdate.Oeeid = planned.Oeeid;
                _context.SaveChanges();
            }
        }

        // Remove an Planned
        public void Remove(int id)
        {
            var plannedToRemove = _context.Planned.Single(o => o.PlannedId == id);
            if (plannedToRemove != null)
            {
                _context.Remove(plannedToRemove);
                _context.SaveChanges();
            }
        }
    }
}
