using System.Collections.Generic;
using OEEWebAPI.Interfaces;
using OEEWebAPI.Models;
using System.Linq;

namespace OEEWebAPI.Repository
{
    public class UnPlannedRepository : IUnPlannedRepository
    {
        private OEEContext _context;

        // Constructor
        public UnPlannedRepository(OEEContext context)
        {
            _context = context;
        }

        // Get All UnPlanned's
        IEnumerable<UnPlanned> IUnPlannedRepository.GetAll()
        {
            var unplanned = _context.UnPlanned;

            return unplanned.AsEnumerable();
        }

        // Get an UnPlanned
        public UnPlanned Find(int id)
        {
            var unplanned = _context.UnPlanned.Single(o => o.UnPlannedId == id);

            return unplanned;
        }

        // Add an UnPlanned
        public void Add(UnPlanned unplanned)
        {
            _context.UnPlanned.Add(unplanned);
            _context.SaveChanges();
        }

        // Update an UnPlanned
        public void Update(UnPlanned unplanned)
        {
            var unplannedToUpdate = _context.UnPlanned.Single(o => o.UnPlannedId == unplanned.UnPlannedId);
            if (unplannedToUpdate != null)
            {
                unplannedToUpdate.Oeeid = unplanned.Oeeid;
                _context.SaveChanges();
            }
        }

        // Remove an UnPlanned
        public void Remove(int id)
        {
            var unplannedToRemove = _context.UnPlanned.Single(o => o.UnPlannedId == id);
            if (unplannedToRemove != null)
            {
                _context.Remove(unplannedToRemove);
                _context.SaveChanges();
            }
        }
    }
}
